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

        public struct Instruction
        {
            public OpCodes op { get; set; }
            public int arg { get; set; }

            public Instruction(OpCodes opCode, int opArg) : this()
            {
                op = opCode;
                arg = opArg;
            }
        }

        private readonly List<Program.Instruction> _program;

        public Program(string file)
        {
            _program = ParseSource.readFile(file);
        }
        public List<Instruction> get { get => _program; }

        public IEnumerable<List<Instruction>> getModified(OpCodes curr, OpCodes replacer)
        {
            var tmp = _program.ToArray();
            /*var modify = from instr in _program
                         where instr.op == curr
                         select instr;*/
            /*var modify = tmp.Where(instr => instr.op == curr);
            foreach (var instr in modify) {
                instr.op = replacer;
                //yield return _program;
                instr.op = curr;
            }*/
            /*foreach (ref var instr in tmp) {
                if (instr.op == curr) {
                    instr.op = replacer;
                    //yield return _program;
                    instr.op = curr;
                }
            }*/
            for (int i = 0; i < tmp.Length; i++) {
                if (tmp[i].op == curr) {
                    tmp[i].op = replacer;
                    yield return new List<Instruction>(tmp);
                    tmp[i].op = curr;
                }
            }
        }
    }
}