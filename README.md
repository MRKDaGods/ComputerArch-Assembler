# Computer Architecture Project Assembler

This is a simple assembler for assembling a custom ISA into a format readable by ModelSim.

## Instruction Bits Details (16-32)
| Field        | Bits   | Description                   |
|--------------|--------|-------------------------------|
| Opcode       | 0-4    | Operation code                |
| Source 1     | 5-7    | First source register         |
| Source 2     | 8-10   | Second source register        |
| Destination  | 11-13  | Destination register          |
| Reserved     | 14-15  | Reserved bits (size)          |
| Immediate    | 16-31  | Immediate value or extension  |

## ISA
| Code | Instruction | Description            | Arguments                                                   |
|------|-------------|------------------------|-------------------------------------------------------------|
| 00000| NOP         | No Operation           | None                                                        |
| 00001| NOT         | Bitwise NOT            | Register                                                    |
| 00010| NEG         | Negate                 | Register                                                    |
| 00011| INC         | Increment              | Register                                                    |
| 00100| DEC         | Decrement              | Register                                                    |
| 00101| OUT         | Output                 | Register                                                    |
| 00110| IN          | Input                  | Register                                                    |
| 00111| MOV         | Move                   | Register, Register                                          |
| 01000| SWAP        | Swap                   | Register, Register                                          |
| 01001| ADD         | Add                    | Register, Register, Register                                |
| 01010| ADDI        | Add Immediate          | Register, Register, Immediate                                |
| 01011| SUB         | Subtract               | Register, Register, Register                                |
| 01100| SUBI        | Subtract Immediate     | Register, Register, Immediate                                |
| 01101| AND         | Bitwise AND            | Register, Register, Register                                |
| 01110| OR          | Bitwise OR             | Register, Register, Register                                |
| 01111| XOR         | Bitwise XOR            | Register, Register, Register                                |
| 10000| CMP         | Compare                | Register, Register                                          |
| 10001| PUSH        | Push to Stack          | Register                                                    |
| 10010| POP         | Pop from Stack         | Register                                                    |
| 10011| LDM         | Load from Memory       | Register, Immediate                                         |
| 10100| LDD         | Load from Device       | Register, OffsetRegister                                    |
| 10101| STD         | Store to Device        | Register, OffsetRegister                                    |
| 10110| PROTECT     | Protect Memory         | Register                                                    |
| 10111| FREE        | Free Memory            | Register                                                    |
| 11000| JZ          | Jump if Zero           | Register                                                    |
| 11001| JMP         | Jump                   | Register                                                    |
| 11010| CALL        | Call Subroutine        | Register                                                    |
| 11011| RET         | Return from Subroutine | None                                                        |
| 11100| RTI         | Return from Interrupt  | None                                                        |
| 11101| RESET       | Reset                  | None                                                        |
| 11110| INTERRUPT   | Interrupt              | None                                                        |



## Demo
![image](https://github.com/MRKDaGods/ComputerArch-Assembler/assets/25166537/06a012e5-5c2b-4f51-becd-d8313d3c0e88)
