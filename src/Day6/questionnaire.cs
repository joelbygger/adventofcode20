using System;
using System.IO;
using System.Linq;

namespace Day6
{
    public class Questionnaire
    {
        private readonly int _answers;

        public Questionnaire(string file)
        {
            /* 1. Empty lines are group separators.
             * 2. Newlines within group removed.
             * 3. Remove duplicates.
             * 4. Count occurences on each index.*/
            _answers = File.ReadAllText(file)
                .Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries)
                .Select(l => l.Replace("\r\n", ""))
                .Select(l => l.Distinct())
                //.ToArray()
                .Select(l => l.ToList().Count)
                .Sum();
        }

        public int yesCnt()
        {
            return _answers;
        }
    }
}