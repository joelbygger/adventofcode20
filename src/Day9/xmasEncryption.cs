using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day9
{
    public class XMASencryption
    {
        private readonly List<long> _data;

        public XMASencryption(string file)
        {
            _data = File.ReadAllLines(file)
                .Select(l => long.Parse(l))
                .ToList();
        }

        public (bool invalidFound, long val) findInvalidVal(int preample)
        {
            int i = preample - 1; // Minus 1 to account for first rounds increment.
            var valOk = true;
            
            while (i < _data.Count && valOk) {
                valOk = false;
                i++;

                for (int a = i - preample; a < (i - 1) && !valOk; a++) {
                    for (int b = i - preample + 1; b < i && !valOk; b++) {
                        if (_data[i] == _data[a] + _data[b]) {
                            valOk = true;
                        }
                    }
                }
            }

            return (!valOk, _data[i]);
        }
    }
}