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

        public (bool invalidFound, long val) invalidVal(int preample)
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

        public long extremesInWindowSum(long sum)
        {
            int a = 0;
            int b = 1;

            while (true || b >= _data.Count) {
                while (_data.GetRange(a, b - a).Sum() < sum && b < _data.Count) {
                    b++;
                }
                while (_data.GetRange(a, b - a).Sum() > sum && a < b) {
                    a++;
                }
                if (_data.GetRange(a, b - a).Sum() == sum) {
                    break;
                }
            }
            return _data.GetRange(a, b - a).Min() + _data.GetRange(a, b - a).Max();
        }
    }
}