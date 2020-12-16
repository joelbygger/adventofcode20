using System.Collections.Generic;
using System.IO;

namespace Day8.Parser
{
    public static class ParseSource
    {
        public static List<Program.Instruction> readFile(string file)
        {
            var opCodeConversion = new Dictionary<string, Program.OpCodes>(){
                {"acc", Program.OpCodes.acc},
                {"jmp", Program.OpCodes.jmp},
                {"nop", Program.OpCodes.nop}
            };

            var program = new List<Program.Instruction>();
            var raw = File.ReadAllLines(file);
            foreach (var a in raw) {
                var l = a.Split(" ");
                program.Add(new Program.Instruction(opCodeConversion[l[0]], int.Parse(l[1])));
            }
            return program;
        }
    }
}