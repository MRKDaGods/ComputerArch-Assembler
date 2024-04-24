using System.Reflection;
using static MRK.Main;

namespace MRK
{
    public class ParserException(int line, int pos, string msg) : Exception(msg)
    {
        public int Line { get; init; } = line;
        public int Pos { get; init; } = pos;
    }

    public class Parser
    {
        private readonly string _code;
        private int _pos;
        private int _line;
        private readonly bool _strict;

        private bool _recordBuffer;
        private string _recordedBuffer;
        private int _recordLastPos;

        private bool IsPosInvalid => _pos >= _code.Length || _pos < 0;
        private bool RecordBuffer
        {
            get => _recordBuffer;

            set {
                _recordBuffer = value;

                if (_recordBuffer)
                {
                    _recordedBuffer = string.Empty; // clear
                    _recordLastPos = -1;
                }
            }
        }

        public List<Instruction> Instructions { get; init; }
        public Dictionary<Instruction, string> InstructionLineMap { get; init; }

        public Parser(string code, bool strict)
        {
            _code = code.Trim().Replace("\r\n", "\n") + '\n';

            var lines = _code.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];

                int commentStart = line.IndexOf('#');
                if (commentStart != -1)
                {
                    line = line.Remove(commentStart);
                }

                lines[i] = line.Trim();
            }

            _code = string.Join('\n', lines);

            _pos = 0;
            _line = 0;

            _strict = strict;

            _recordBuffer = false;
            _recordedBuffer = string.Empty;
            _recordLastPos = -1;

            Instructions = [];
            InstructionLineMap = [];
        }

        public void Parse()
        {
            LogInfo("Parser starting...");

            Instructions.Clear();
            InstructionLineMap.Clear();

            while (!IsPosInvalid)
            {
                // read instr

                // start recording
                RecordBuffer = true;

                string instruction;
                try
                {
                    instruction = ReadText();
                }
                catch (ParserException)
                {
                    // exit gracefully if we're still finding an instruction
                    break;
                }

                if (instruction.Length == 0)
                {
                    continue;
                }

                LogInfo($"Finding definition for ({instruction})");

                // find instruction def
                var definition = GetInstructionDefinition(instruction);
                if (definition == null)
                {
                    LogError($"Unknown instruction ({instruction})");

                    // ignore unknown instructions?
                    if (_strict)
                    {
                        throw new ParserException(_line, _pos, $"Unknown instruction ({instruction})");
                    }
                    
                    // skip to new line
                    SkipTill('\n');
                    continue;
                }

                var instObj = new Instruction(definition)
                {
                    // assign reserved
                    // res=0 for 16bit, 1 for 32bit
                    Reserved = (byte)(definition.Size == 8 ? 1 : 0)
                };

                // read operands
                for (int i = 0; i < definition.Operands.Length; i++)
                {
                    var operand = definition.Operands[i];

                    // read babe
                    switch (operand)
                    {
                        case InstructionOperand.Register:
                            var reg = ReadOperandRegister();
                            AssignRegister(instObj, reg, i);

                            break;

                        case InstructionOperand.Immediate:
                            var imm = ReadOperandImmediate();
                            instObj.Immediate = imm;

                            break;

                        case InstructionOperand.OffsetRegister:
                            var offset = ReadOperandOffsetRegister();
                            instObj.Immediate = offset.Item1;
                            instObj.Src1 = offset.Item2;

                            LogInfo($"Processed offset {(short)offset.Item1}(R{offset.Item2})");

                            break;
                    }
                }

                Instructions.Add(instObj);

                // turn off recording
                RecordBuffer = false;

                // line map
                InstructionLineMap[instObj] = _recordedBuffer.Trim();

                // skip till newline
                SkipTill('\n');
            }
        }

        private InstructionDefinition? GetInstructionDefinition(string instruction)
        {
            return typeof(InstructionDefinition)
                .GetProperties(BindingFlags.Public | BindingFlags.Static)
                .FirstOrDefault(p => p.Name.Equals(instruction, StringComparison.CurrentCultureIgnoreCase))
                ?.GetValue(null) as InstructionDefinition;
        }

        private void AssignRegister(Instruction instruction, byte reg, int operandIdx)
        {
            uint flag = (instruction.Definition.RegisterFlags >> (2 * operandIdx)) & 0x3;
            switch (flag)
            {
                case 0:
                    instruction.Src1 = reg; 
                    break;

                case 1:
                    instruction.Src2 = reg;
                    break;

                case 2:
                    instruction.Dst = reg;
                    break;
            }

            LogInfo($"Processed register flag 0x{flag} for R{reg}");
        }

        // ======================= Utils =======================

        private char Read(bool ignoreNewLine = false, bool ignoreSpace = false, params char[] ignoreChars)
        {
            char c;
            do
            {
                if (IsPosInvalid)
                {
                    throw new ParserException(_line, _pos, "Cannot read past buffer");
                }

                c = _code[_pos++];

                if (RecordBuffer)
                {
                    // dont record pos twice
                    if (_recordLastPos != _pos - 1)
                    {
                        _recordedBuffer += c;
                        _recordLastPos = _pos - 1;
                    }
                }

                // comment?
                if (c == '#')
                {
                    SkipTill('\n');
                }

                if (c == '\n')
                {
                    _line++;
                }
            }
            while ((ignoreSpace && c == ' ') ||
                    c == '\t' ||
                    (c == '\n' && ignoreNewLine) ||
                    ignoreChars.Contains(c));

            return c;
        }

        private void SkipTill(char c)
        {
            while (Read(c != '\n') != c)
            {
                if (IsPosInvalid)
                {
                    // err
                    throw new ParserException(_line, _pos, $"Reached EOF before finding {c}");
                }
            }
        }

        private char ReadProper()
        {
            return Read(true, true, ',');
        }

        private string ReadText()
        {
            string buf = "";
            for (char c = ReadProper(); char.IsLetter(c) && !IsPosInvalid; c = Read())
            {
                buf += c;
            }

            // go back
            _pos--;

            return buf;
        }

        private string ReadIdentifier()
        {
            bool canReadNum = false;

            string buf = "";
            for (char c = ReadProper(); !IsPosInvalid && ((canReadNum && char.IsDigit(c)) || char.IsLetter(c)); c = Read())
            {
                if (char.IsLetter(c))
                {
                    canReadNum |= true;
                }

                buf += c;
            }

            // go back
            _pos--;

            return buf;
        }

        private string ReadNumber()
        {
            string buf = "";

            bool prefix = true;

            for (char c = ReadProper(); !IsPosInvalid && char.IsDigit(c) || (prefix && c == '-'); c = Read())
            {
                // turn off prefix
                prefix = false;

                buf += c;
            }

            // go back
            _pos--;

            return buf;
        }

        private byte ReadOperandRegister(bool silent = false)
        {
            if (!silent)
            {
                LogInfo("Reading operand register");
            }
            
            //Rx
            var identifier = ReadIdentifier();
            LogInfo("Identifier=" + identifier);

            if (!identifier.StartsWith("R", StringComparison.CurrentCultureIgnoreCase) ||
                identifier.Length != 2 ||
                !byte.TryParse(identifier.AsSpan(1), out byte reg) ||
                reg > 7)
            {
                throw new ParserException(_line, _pos, $"Invalid register ({identifier})");
            }

            return reg;
        }

        private ushort ReadOperandImmediate()
        {
            LogInfo("Reading operand immediate");

            var number = ReadNumber();
            LogInfo("Number=" + number);

            if (!int.TryParse(number, out int res) || res < short.MinValue || res > ushort.MaxValue)
            {
                throw new ParserException(_line, _pos, $"Invalid number ({number})");
            }

            return (ushort)res;
        }

        private (ushort, byte) ReadOperandOffsetRegister()
        {
            LogInfo("Reading operand offset reg");

            // read 16bit signed

            var number = ReadNumber();
            LogInfo("Number=" + number);

            if (!short.TryParse(number, out short res))
            {
                throw new ParserException(_line, _pos, $"Invalid short ({number})");
            }

            SkipTill('(');

            // read register
            var reg = ReadOperandRegister();

            SkipTill(')');

            return ((ushort)res, reg);
        }
    }
}
