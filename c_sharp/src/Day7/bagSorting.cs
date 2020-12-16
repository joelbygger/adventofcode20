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

        public int bagsThatCanContain(string goal)
        {
            var bags = bagsContainingBag(goal).Distinct().ToList();
            bags.Remove(goal);
            return bags.Count();
        }

        private List<string> bagsContainingBag(string bagColor)
        {
            var res = new List<string>();
            res.Add(bagColor);

            foreach (var bag in _bagRules) {
                foreach (var content in bag.Value) {
                    if (content.Key == bagColor) {
                        res.AddRange(bagsContainingBag(bag.Key));
                    }
                }
            }
            return res;
        }

        public int bagsInBag(string bagColor)
        {
            int res = 0;
            foreach (var bag in _bagRules[bagColor]) {
                res += bag.Value + bag.Value * bagsInBag(bag.Key);
            }
            return res;
        }
    }
}