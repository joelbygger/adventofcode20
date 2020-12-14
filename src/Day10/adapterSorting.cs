using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day10
{
    public class AdapterSorting
    {
        private readonly List<int> _adapters;
        private readonly Dictionary<int, int> _cache;

        public AdapterSorting(string file)
        {
            _cache = new Dictionary<int, int>();

            _adapters = File.ReadAllLines(file)
                .Select(l => int.Parse(l))
                .ToList();
            _adapters.Add(_adapters.Max() + 3); // Our device.
            _adapters.Add(0);
        }

        // Function destroys member variable.
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

            // First adapter is never removed.
            if (_adapters.Count == 1 && _adapters[0] == 0) {
                var oneStep = steps.FindAll(x => x == 1).Count();
                var threeStep = steps.FindAll(x => x == 3).Count();
                res = oneStep * threeStep;
                Console.WriteLine("1: {0}, 3: {1}", oneStep, threeStep);
            }
            else if (step > 3) {
                Console.WriteLine("Darkness");
            }

            return res;
        }

        public int getMaxAdapterJolt()
        {
            return _adapters.Max();
        }

        // Stolen from https://github.com/SaahilClaypool/aoc_2020.
        public long findAdapterCombinations(int val)
        {
            _adapters.Sort();
            _adapters.Reverse();
            var subtreeCounts = new Dictionary<long, long>();

            foreach (var jolt in _adapters) {
                var possibleNext = _adapters.Where(j => j > jolt && j <= jolt + 3);
                subtreeCounts[jolt] = possibleNext.Select(n => subtreeCounts[n]).Sum();
                if (subtreeCounts[jolt] == 0) subtreeCounts[jolt] = 1;
            }
            return subtreeCounts[0];
        }
    }
}