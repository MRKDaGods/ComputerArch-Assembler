namespace MRK
{
    public enum InstructionOpCode
    {
        NOP,
        NOT,
        NEG,
        INC,
        DEC,
        OUT,
        IN,
        MOV,
        SWAP,
        ADD,
        ADDI,
        SUB,
        SUBI,
        AND,
        OR,
        XOR,
        CMP,
        PUSH,
        POP,
        LDM,
        LDD,
        STD,
        PROTECT,
        FREE,
        JZ,
        JMP,
        CALL,
        RET,
        RTI,
        RESET,
        INTERRUPT,

        MAX
    }

    public enum InstructionOperand
    {
        None,
        Register,       //Rx
        Immediate,      //1234
        OffsetRegister  //1234(Rx)
    }

    public class InstructionDefinition(InstructionOpCode opcode, uint flags, params InstructionOperand[] operands)
    {
        public InstructionOpCode OpCode { get; init; } = opcode;
        public uint RegisterFlags { get; init; } = flags;
        public InstructionOperand[] Operands { get; init; } = operands;
        public int Size => Operands
            .Any(x => x == InstructionOperand.OffsetRegister || 
                                    x == InstructionOperand.Immediate) ? 4 : 2;

        // add all
        public static InstructionDefinition NOP => new(InstructionOpCode.NOP, 0x0);
        public static InstructionDefinition NOT => new(InstructionOpCode.NOT, 0x2, InstructionOperand.Register);
        public static InstructionDefinition NEG => new(InstructionOpCode.NEG, 0x2, InstructionOperand.Register);
        public static InstructionDefinition INC => new(InstructionOpCode.INC, 0x2, InstructionOperand.Register);
        public static InstructionDefinition DEC => new(InstructionOpCode.DEC, 0x2, InstructionOperand.Register);
        public static InstructionDefinition OUT => new(InstructionOpCode.OUT, 0x2, InstructionOperand.Register);
        public static InstructionDefinition IN => new(InstructionOpCode.IN, 0x2, InstructionOperand.Register);
        public static InstructionDefinition MOV => new(InstructionOpCode.MOV, 0x2, InstructionOperand.Register, InstructionOperand.Register);
        public static InstructionDefinition SWAP => new(InstructionOpCode.SWAP, 0x2, InstructionOperand.Register, InstructionOperand.Register);
        public static InstructionDefinition ADD => new(InstructionOpCode.ADD, 0x12, InstructionOperand.Register, InstructionOperand.Register, InstructionOperand.Register);
        public static InstructionDefinition ADDI => new(InstructionOpCode.ADDI, 0x2, InstructionOperand.Register, InstructionOperand.Register, InstructionOperand.Immediate);
        public static InstructionDefinition SUB => new(InstructionOpCode.SUB, 0x12, InstructionOperand.Register, InstructionOperand.Register, InstructionOperand.Register);
        public static InstructionDefinition SUBI => new(InstructionOpCode.SUBI, 0x2, InstructionOperand.Register, InstructionOperand.Register, InstructionOperand.Immediate);
        public static InstructionDefinition AND => new(InstructionOpCode.AND, 0x12, InstructionOperand.Register, InstructionOperand.Register, InstructionOperand.Register);
        public static InstructionDefinition OR => new(InstructionOpCode.OR, 0x12, InstructionOperand.Register, InstructionOperand.Register, InstructionOperand.Register);
        public static InstructionDefinition XOR => new(InstructionOpCode.XOR, 0x12, InstructionOperand.Register, InstructionOperand.Register, InstructionOperand.Register);
        public static InstructionDefinition CMP => new(InstructionOpCode.CMP, 0x4, InstructionOperand.Register, InstructionOperand.Register);
        public static InstructionDefinition PUSH => new(InstructionOpCode.PUSH, 0x2, InstructionOperand.Register);
        public static InstructionDefinition POP => new(InstructionOpCode.POP, 0x2, InstructionOperand.Register);
        public static InstructionDefinition LDM => new(InstructionOpCode.LDM, 0x2, InstructionOperand.Register, InstructionOperand.Immediate);
        public static InstructionDefinition LDD => new(InstructionOpCode.LDD, 0x2, InstructionOperand.Register, InstructionOperand.OffsetRegister);
        public static InstructionDefinition STD => new(InstructionOpCode.STD, 0x2, InstructionOperand.Register, InstructionOperand.OffsetRegister);
        public static InstructionDefinition PROTECT => new(InstructionOpCode.PROTECT, 0x0, InstructionOperand.Register);
        public static InstructionDefinition JZ => new(InstructionOpCode.JZ, 0x2, InstructionOperand.Register);
        public static InstructionDefinition JMP => new(InstructionOpCode.JMP, 0x2, InstructionOperand.Register);
        public static InstructionDefinition CALL => new(InstructionOpCode.CALL, 0x2, InstructionOperand.Register);
        public static InstructionDefinition RET => new(InstructionOpCode.RET, 0x0);
        public static InstructionDefinition RTI => new(InstructionOpCode.RTI, 0x0);
        public static InstructionDefinition RESET => new(InstructionOpCode.RESET, 0x0);
        public static InstructionDefinition INTERRUPT => new(InstructionOpCode.INTERRUPT, 0x0);
    }

    public class Instruction(InstructionDefinition definition)
    {
        public InstructionDefinition Definition { get; init; } = definition;
        public byte Src1 { get; set; }
        public byte Src2 { get; set; }
        public byte Dst { get; set; }
        public byte Reserved { get; set; }
        public ushort Immediate { get; set; }

        public static uint Assemble(InstructionOpCode opcode, byte src1, byte src2, byte dst, byte res, ushort imm)
        {
            static uint cast(object num) => Convert.ToUInt32(num);

            return cast(imm) << 16 |
                    cast(res) << 14 |
                    cast(dst) << 11 |
                    cast(src2) << 8 |
                    cast(src1) << 5 |
                    cast(opcode);
        }

        public static uint Assemble(Instruction instruction)
        {
            return Assemble(
                instruction.Definition.OpCode,
                instruction.Src1,
                instruction.Src2,
                instruction.Dst,
                instruction.Reserved,
                instruction.Immediate);
        }
    }
}
