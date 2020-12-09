using System;
using System.Collections.Generic;
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
                .Select(l => l.Distinct())
                .Select(l => l.ToList().Count)
                .Sum();
        }

        public int sumCommonYesPerGroup()
        {
            List<List<string>> groups = answersByGroup();

            int sum = 0;
            foreach (var group in groups) {
                var cmnYes = new Dictionary<char, int>();
                foreach (var individ in group) {
                    foreach (var q in individ) {
                        if (cmnYes.ContainsKey(q)) {
                            cmnYes[q] = cmnYes[q] + 1;
                        }
                        else {
                            cmnYes.Add(q, 1);
                        }
                    }
                }

                sum += cmnYes.AsEnumerable()
                    .Where(q => q.Value >= group.Count())
                    .Select(q => 1)
                    .Sum();
            }

            return sum;
        }

        private List<List<string>> answersByGroup()
        {
            var groups = new List<List<string>>();
            var strReader = new StringReader(_answers);
            string line;

            groups.Add(new List<string>());

            while ((line = strReader.ReadLine()) != null) {
                if (line != "") {
                    groups.Last().Add(line);
                }
                else {
                    groups.Add(new List<string>());
                }
            }

            return groups;
        }
    }
}