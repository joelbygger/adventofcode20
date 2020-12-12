using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day10
{
    public class AdapterSorting
    {
        public List<int> _adapters;

        public AdapterSorting(string file)
        {
            _adapters = File.ReadAllLines(file)
                .Select(l => int.Parse(l))
                .ToList();
        }

        public int getSum1and3StepInChain()
        {
            int res = 0;
            int curr = 0;
            int desired = 0;
            var steps = new List<int>();

            int step = 1;
            while (_adapters.Count > 0 && step <= 3) {
                desired = curr + step;

                if (_adapters.Remove(desired)) {
                    steps.Add(desired - curr);
                    curr = desired;
                    step = 1;
                }
                else {
                    step++;
                }
            }

            if (step > 3) {
                Console.WriteLine("Darkness");
            }
            else if (_adapters.Count == 0) {
                var oneStep = steps.FindAll(x => x == 1).Count();
                var threeStep = steps.FindAll(x => x == 3).Count() + 1; // +1 for device itself.
                res = oneStep * threeStep;
                Console.WriteLine("1: {0}, 3: {1}", oneStep, threeStep);
            }

            return res;
        }

    }
}