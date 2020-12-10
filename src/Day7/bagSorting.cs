using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day7
{
    using RulesStorage = Dictionary<string, Dictionary<string, int>>;

    public class BagSorting
    {
        private readonly RulesStorage _bagRules;

        public BagSorting(string file)
        {
            _bagRules = new RulesStorage();

            var cleanList = File.ReadAllText(file)
                .Replace("bags", "bag")
                .Replace("bag.", "")
                .Replace("bag", "")
                .ToLower()
                .Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            var outerBag = cleanList
                .Select(rule => rule.Split(" contain "))
                .GroupBy(x => x[0].Trim(), x => x[1]);
            var splitInnerBags = outerBag
                .Select(x => x.First().Split(", ").GroupBy(y => x.Key, y => y));
            // Executes/ unpacks one level of linq. Not quite sure what best approach is besides this.
            var allBags = splitInnerBags
                .Select(x => x.First());

            // Place all rules in dict.
            foreach (var bag in allBags) {
                var bagContent = new Dictionary<string, int>();
                foreach (var content in bag) {
                    if (!content.Contains("no other")) {
                        var key = content.Substring(content.IndexOf(" ")).Trim();
                        var valStr = content.Substring(0, content.IndexOf(" ")).Trim();
                        var val = int.Parse(valStr);
                        bagContent.Add(key, val);
                    }
                }
                _bagRules.Add(bag.Key, bagContent);
            }
        }

        public int bagColorsThatCanContainGolden()
        {
            const string goal = "shiny gold";
            var bags = bagsContainingColor(goal).Distinct().ToList();
            bags.Remove(goal);
            return bags.Count();
        }

        private List<string> bagsContainingColor(string color)
        {
            var res = new List<string>();
            res.Add(color);

            foreach (var bag in _bagRules) {
                foreach (var content in bag.Value) {
                    if (content.Key == color) {
                        res.AddRange(bagsContainingColor(bag.Key));
                    }
                }
            }
            return res;
        }
    }
}