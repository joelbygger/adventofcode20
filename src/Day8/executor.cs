using System;
using System.Collections.Generic;

namespace Day8
{
    using PrgmList = List<ParseProgram.Command>;
    public class Executor
    {
        private readonly PrgmList _prgm;
        private int _accum;

        public Executor(PrgmList prgm)
        {
            _prgm = prgm;
            _accum = 0;
        }

        public int run()
        {
            int index = 0;
            var visited = new HashSet<int>();

            while (true) {
                int nxtIndex = 0;
                visited.Add(index);

                switch (_prgm[index].op) {
                    case ParseProgram.OpCodes.acc:
                        (nxtIndex, _accum) = acc(index, _prgm[index], _accum);
                        break;
                    case ParseProgram.OpCodes.jmp:
                        nxtIndex = jmp(index, _prgm[index]);
                        break;
                    case ParseProgram.OpCodes.nop:
                        nxtIndex = nop(index);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Shouldn't be here, should we?");
                }

                if(nxtIndex > _prgm.Count) {
                    throw new IndexOutOfRangeException("Well this is weird.");
                }

                if(visited.Contains(nxtIndex)) {
                    break;
                }
                index = nxtIndex;
            }

            return _accum;
        }

        private static (int, int) acc(int i, ParseProgram.Command cmd, int accumulator)
        {
            return (++i, accumulator += cmd.arg);
        }

        private static int jmp(int i, ParseProgram.Command cmd)
        {
            return i + cmd.arg;
        }

        private static int nop(int i)
        {
            return ++i;
        }
    }
}