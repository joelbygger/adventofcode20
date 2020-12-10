using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day8
{
    public static class ParseProgram
    {
        public enum OpCodes
        {
            acc,
            jmp,
            nop
        }

        public struct Command
        {
            public OpCodes op { get; }
            public int arg { get; }

            public Command(OpCodes opCode, int opArg) : this()
            {
                op = opCode;
                arg = opArg;
            }
        }

        public static List<Command> readFile(string file)
        {
            var opCodeConversion = new Dictionary<string, OpCodes>(){
                {"acc", OpCodes.acc},
                {"jmp", OpCodes.jmp},
                {"nop", OpCodes.nop}
            };

            var program = new List<Command>();
            var raw = File.ReadAllLines(file);
            foreach(var a in raw) {
                var l = a.Split(" ");
                program.Add(new Command(opCodeConversion[l[0]], int.Parse(l[1])));
            }
            return program;
        }
    }
}