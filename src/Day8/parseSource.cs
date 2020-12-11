using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day8.Parser
{
    public static class ParseSource
    {
        public static List<Program.Command> readFile(string file)
        {
            var opCodeConversion = new Dictionary<string, Program.OpCodes>(){
                {"acc", Program.OpCodes.acc},
                {"jmp", Program.OpCodes.jmp},
                {"nop", Program.OpCodes.nop}
            };

            var program = new List<Program.Command>();
            var raw = File.ReadAllLines(file);
            foreach(var a in raw) {
                var l = a.Split(" ");
                program.Add(new Program.Command(opCodeConversion[l[0]], int.Parse(l[1])));
            }
            return program;
        }
    }
}