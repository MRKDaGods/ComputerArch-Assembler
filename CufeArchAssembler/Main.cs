using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace MRK
{
    public partial class Main : Form
    {
        private class Synthesize
        {
            private readonly Main _main;

            public Synthesize(Main main)
            {
                _main = main;

                // 0 all cbs
                foreach (var cb in _main.gbSynthesize.Controls.OfType<ComboBox>())
                {
                    cb.SelectedIndex = 0;

                    // handler
                    cb.SelectedIndexChanged += (o, e) => BuildInstruction();
                }

                _main.tbImm.Text = "0";
                _main.tbImm.TextChanged += (o, e) => BuildInstruction();

                _main.cbUnsigned.CheckedChanged += (o, e) => BuildInstruction();
                _main.cbHex.CheckedChanged += (o, e) => BuildInstruction();

                _main.lSynthOutput.Click += (o, e) => {
                    var txt = _main.lSynthOutput.Text;

                    if (txt != "Invalid")
                    {
                        txt = txt.Substring(2, 8);
                        Clipboard.SetText(txt);
                        
                        _main.Log(LogLevel.Info, $"Copied {txt} to clipboard");
                    }
                };

                BuildInstruction();
            }

            private void BuildInstruction()
            {
                ushort imm = 0;

                bool assignedImm = false;

                var numberStyle = _main.cbHex.Checked ? NumberStyles.HexNumber : NumberStyles.Integer;
                if (!_main.cbUnsigned.Checked && short.TryParse(_main.tbImm.Text, numberStyle, null, out short num))
                {
                    imm = (ushort)num;
                    assignedImm = true;
                }
                else if (_main.cbUnsigned.Checked && ushort.TryParse(_main.tbImm.Text, numberStyle, null, out ushort unum))
                {
                    imm = unum;
                    assignedImm = true;
                }

                if (!assignedImm)
                {
                    _main.Log(LogLevel.Error, $"Invalid imm value {_main.tbImm.Text}");
                    _main.lSynthOutput.Text = "Invalid";
                    return;
                }

                var instruction = Instruction.Assemble(
                    (InstructionOpCode)_main.cbOpcode.SelectedIndex,
                    (byte)_main.cbSrc1.SelectedIndex,
                    (byte)_main.cbSrc2.SelectedIndex,
                    (byte)_main.cbDst.SelectedIndex,
                    (byte)_main.cbRes.SelectedIndex,
                    imm
                );

                // done
                var str = ConvertInstructionToString(instruction);
                _main.lSynthOutput.Text = $"0x{str.Item1}{new string(' ', 24)}0b{str.Item2}";
            }
        }

        private enum LogLevel
        {
            Info,
            Warn,
            Error
        }

        [SuppressMessage("CodeQuality", "IDE0052:Remove unread private members")]
        private readonly Synthesize _synthesize; /* unused */

        private string? _memoryPath;

        private readonly List<Instruction> _assembledInstructions;

        private static Main? Instance { get; set; }

        public Main()
        {
            Instance = this;

            InitializeComponent();

            bAssemble.Click += OnAssembleClick;
            bGenerate.Click += OnGenerateClick;

            _synthesize = new Synthesize(this);

            _memoryPath = null;

            _assembledInstructions = new();
        }

        private void OnGenerateClick(object? sender, EventArgs e)
        {
            if (_assembledInstructions.Count == 0) return;

            if (new InputStringForm(_memoryPath, path => _memoryPath = path).ShowDialog() == DialogResult.OK)
            {
                int len = 0;
                string data = "";

                // predicted instruction rel addr
                ushort codePosition = 0;

                foreach (var instruction in _assembledInstructions)
                {
                    var deltaAddr = instruction.RelativeAddress - codePosition;
                    if (deltaAddr > 0)
                    {
                        while (deltaAddr-- > 0)
                        {
                            // add nops
                            data += " 0000 ";
                            len++;
                        }
                    }

                    codePosition = (ushort)(instruction.RelativeAddress + instruction.Definition.Size / 2);

                    var asm = instruction.Assembly;
                    var hex = ConvertInstructionToString(asm, instruction.Definition.Size).Item1;

                    len++;

                    if (hex.Length > 4)
                    {
                        hex = string.Concat(hex.AsSpan(4), " ", hex.AsSpan(0, 4)); // little endian
                        len++;
                    }

                    data += $" {hex} ";
                }

                data = data.Remove(data.Length - 1);

                var cmd = $"mem load -skip 0 -filltype value -filldata {{{data}}} -fillradix hexadecimal -startaddress 0 -endaddress {len - 1} {_memoryPath}";
                Clipboard.SetText(cmd);

                LogInfo($"Copied cmd to clipboard \"{cmd}\"");
            }
        }

        private void OnAssembleClick(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbCode.Text)) return;

            LogInfo("\r\n\r\n--------ASSEMBLE--------\r\n");

            var parser = new Parser(tbCode.Text, cbStrict.Checked);

            try
            {
                // clear output
                tbOutput.Clear();

                _assembledInstructions.Clear();

                // start!
                parser.Parse();

                LogInfo($"Done parsing, instruction count={parser.Instructions.Count}\r\nAssembling...");

                ushort codeStartPosition = 0;

                foreach (var instruction in parser.Instructions)
                {
                    // is org?
                    if (instruction.Definition.OpCode == InstructionOpCode.DIRECTIVE_ORG)
                    {
                        //tbOutput.AppendText($"=>> 0x{codeStartPosition:X2} > 0x{instruction.Immediate:X2}\r\n");
                        codeStartPosition = instruction.Immediate;
                        continue;
                    }

                    instruction.RelativeAddress = codeStartPosition; // to use later

                    // increment codeStartPosition
                    codeStartPosition += (ushort)(instruction.Definition.Size / 2);

                    // assemble
                    _assembledInstructions.Add(instruction);
                }

                // sort by relative address
                _assembledInstructions.Sort((x, y) => x.RelativeAddress.CompareTo(y.RelativeAddress));

                foreach (var instruction in _assembledInstructions)
                {
                    var str = ConvertInstructionToString(instruction.Assembly, instruction.Definition.Size);

                    tbOutput.AppendText($"{instruction.RelativeAddress:X4}: {parser.InstructionLineMap[instruction].ToUpper()}\r\n" +
                        $"0x{str.Item1}{new string('\t', instruction.Definition.Size == 2 ? 2 : 1)}{str.Item2}\r\n\r\n");
                }

                lStatus.BackColor = Color.Green;
                lStatus.Text = $"Success - Assembled {parser.Instructions.Count} instructions";
            }
            catch (Exception ex)
            {
                if (ex is ParserException pex)
                {
                    LogError($"ParserException (line={pex.Line} pos={pex.Pos}) {pex.Message}");
                }
                else
                {
                    LogError(ex.ToString());
                }

                lStatus.BackColor = Color.Red;
                lStatus.Text = $"Error - Check logs";
            }
        }

        private void Log(LogLevel level, string msg)
        {
            tbConsole.AppendText($"[{level.ToString().ToUpper()}] {msg}\r\n");
        }

        public static void LogInfo(string msg)
        {
            Instance?.Log(LogLevel.Info, msg);
        }

        public static void LogError(string msg)
        {
            Instance?.Log(LogLevel.Error, msg);
        }

        private static (string, string) ConvertInstructionToString(uint instruction, int sz = 4)
        {
            var hex = Convert.ToString(instruction, 16).PadLeft(sz * 2, '0').ToUpper();
            var bin = Convert.ToString(instruction, 2)
                .PadLeft(sz * 8, '0').Reverse().ToArray();

            var spacedBin = "";
            for (int i = 0; i < bin.Length; i++)
            {
                spacedBin += bin[i];

                if (i == 4 || i == 7 || i == 10 || i == 13 || i == 15)
                {
                    spacedBin += ' ';
                }
            }

            // reverse
            spacedBin = new string(spacedBin.Reverse().ToArray()).Trim();

            return (hex, spacedBin);
        }
    }
}
