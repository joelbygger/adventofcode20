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
            /*public OpCodes OpCodes { get; }
            public int V { get; }*/
        }

        public static List<Command> readFile(string file)
        {
            var opCodeConversion = new Dictionary<string, OpCodes>(){
                {"acc", OpCodes.acc},
                {"jmp", OpCodes.jmp},
                {"nop", OpCodes.nop}
            };

            /*using var sr = new System.IO.StreamReader(file);
            while (!sr.EndOfStream) {
                var prgm = sr.ReadLine()
                    //.Split(" ")
                    *//*.GroupBy(x => (
                        op: opCodeConversion[x.Ke],
                        arg: x[1]))*//*
                    .GroupBy(l => (
                        op: opCodeConversion[l.Substring(0, l.IndexOf(" ")).Trim()],
                        arg: l.Substring(l.IndexOf(" "))
                    
                    ;*//*.Select(l => (
                        op: opCodeConversion[l.Key],
                        arg: l[1])*/
                /*op: opCodeConversion[l.Substring(0, l.IndexOf(" ")).Trim()],
                arg: l.Substring(l.IndexOf(" "))*//*
                Console.WriteLine("");
            }*/

            Console.WriteLine("");

            var program = new List<Command>();
            var raw = File.ReadAllLines(file);
            foreach(var a in raw) {
                var l = a.Split(" ");
                program.Add(new Command(opCodeConversion[l[0]], int.Parse(l[1])));
                /*var x = (op: opCodeConversion[l[0]],
                        arg: int.Parse(l[1]));*/
            }
            /*var a = from line in prgm
                .Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                    .Select(l => (
                        op: opCodeConversion[l.Substring(0, l.IndexOf(" ")).Trim()],
                        arg: l.Substring(l.IndexOf(" "))
                    ));*/

            /*var prgm = File.ReadAllText(file)
                .Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
                .Split(" " , StringSplitOptions.RemoveEmptyEntries)
                .Select(l => (
                    op: opCodeConversion[l[0]],
                    arg: l[1]
                ));*/
            return program;
        }
    }
}