using Day8.Parser;
using System.Collections.Generic;

namespace Day8
{
    public class Program
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

        private List<Program.Command> _program;

        public Program(string file)
        {
            _program = ParseSource.readFile(file);
        }
        public List<Program.Command> get { get => _program; }

    }
}