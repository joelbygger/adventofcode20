using System;
using System.Collections.Generic;

namespace Day8
{
    using PrgmList = List<Program.Instruction>;
    public class Executor
    {
        private readonly PrgmList _prgm;
        private int _accum;

        public Executor(PrgmList prgm)
        {
            _prgm = prgm;
            _accum = 0;
        }

        public (int accumulator, bool infiniteLoop) run()
        {
            int index = 0;
            bool endOnInfiniteLoop = false;
            var visited = new HashSet<int>();

            while (true) {
                int nxtIndex = 0;
                visited.Add(index);

                switch (_prgm[index].op) {
                    case Program.OpCodes.acc:
                        (nxtIndex, _accum) = acc(index, _prgm[index], _accum);
                        break;
                    case Program.OpCodes.jmp:
                        nxtIndex = jmp(index, _prgm[index]);
                        break;
                    case Program.OpCodes.nop:
                        nxtIndex = nop(index);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Shouldn't be here, should we?");
                }

                if (nxtIndex > _prgm.Count - 1 || nxtIndex < 0) {
                    endOnInfiniteLoop = false;
                    break;
                }

                if (visited.Contains(nxtIndex)) {
                    endOnInfiniteLoop = true;
                    break;
                }
                index = nxtIndex;
            }

            return (accumulator: _accum, infiniteLoop: endOnInfiniteLoop);
        }

        private static (int, int) acc(int i, Program.Instruction cmd, int accumulator)
        {
            return (++i, accumulator += cmd.arg);
        }

        private static int jmp(int i, Program.Instruction cmd)
        {
            return i + cmd.arg;
        }

        private static int nop(int i)
        {
            return ++i;
        }
    }
}