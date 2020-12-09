using System;
using System.IO;
using System.Linq;

namespace Day6
{
    public class Questionnaire
    {
        private readonly string _answers;

        public Questionnaire(string file)
        {
            /* 1. Empty lines are group separators.
             * 2. Newlines within group removed.
             * 3. Remove duplicates.
             * 4. Count occurences on each index.*/
            _answers = File.ReadAllText(file);
        }

        public int sumAllUniqueYesPerGroup()
        {
            return _answers
                .Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries)
                .Select(l => l.Replace("\r\n", ""))
                .Select(l => l.Distinct().ToList().Count)
                .Sum();
        }

        public int sumCommonYesPerGroup()
        {
            /* 1. An array split into groups.
             * 2. Each group split into individuals.
             * 3.In each group, find common answers
             *  a. Aggregate is like ForAll, but starts w. 2 values from input, then takes
             *     one from input and the other from return from called function.
             *  b. Intersect returns array with common things, which we propagetes to next comparison.
             *  c. Save length of array (?) of common answers
             * 4. Execute the linq with Sum, sum it all up. */
            var sum = _answers
                .Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries)
                .Select(rawGroup => rawGroup.Split("\r\n", StringSplitOptions.RemoveEmptyEntries))
                .Select(group => group.Aggregate((curr, next) => {
                    var hej = curr.Intersect(next);
                    return new String(hej.ToArray());
                })
                    .Count())
                .Sum();

            return sum;
        }
    }
}