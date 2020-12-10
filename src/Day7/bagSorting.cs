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
        private readonly RulesStorage _bagRulesRev;

        public BagSorting(string file)
        {
            _bagRules = new RulesStorage();
            _bagRulesRev = new RulesStorage();

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
            /*var allBags = splitInnerBags
                .GroupBy(x => x.First().First().First().)*/
            /*var allBags = splitInnerBags
                .Select(x => x.First()
                              .Select(y => y.ToDictionary(z => y.Substring(y.IndexOf(" ")),
                                                          z => y.Substring(0, y.IndexOf(" ")))));*/
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




            // reveresed.
            /*var sum0 = recurseBags3("shiny gold");
            Console.WriteLine("sum0: " + sum0.Count);
            var sum1 = sum0.Distinct().ToList();
            Console.WriteLine("sum1: " + sum1.Count);
            foreach (var a in sum1) {
                Console.WriteLine("sum1: " + a);
            }*/

            /*var sum = 0;
            foreach (var bag in _bagRules["shiny gold"]) {
                sum += recurseBags2(bag.Key);
            }
            Console.WriteLine("sum: " + sum);*/

            /*//_bagRulesRev.Add("shiny_gold", new Dictionary<string, int>());
            var bagContent2 = new Dictionary<string, int>();
            foreach (var bag in allBags) {
                foreach (var content in bag) {
                    *//*if (!content.Contains("no other")) {
                        var key = content.Substring(content.IndexOf(" ")).Trim();
                        var valStr = content.Substring(0, content.IndexOf(" ")).Trim();
                        var val = int.Parse(valStr);
                        if (key == "shiny gold") {
                            bagContent2.Add(bag.Key, val);
                        }
                    }*//*
                }
            }
            //_bagRulesRev["shiny gold"] = bagContent2;*/
        }

        private List<string> recurseBags3(string colour)
        {
            var res = new List<string>();

            if (_bagRules[colour].Count() == 0) {
                //Console.WriteLine("end: " + colour);
                //res.Add(colour);
            }
            else {
                foreach (var bag in _bagRules[colour]) {
                    //Console.WriteLine("call: " + bag.Key);
                    var tmp = recurseBags3(bag.Key);
                    //res.Concat(tmp);
                    res.AddRange(tmp);
                    res.Add(bag.Key);
                }
            }
            return res;
        }
        private int recurseBags2(string colour)
        {
            int sum = 0;
            foreach (var bag in _bagRules) {
                if (bag.Key != "shiny gold") {
                    foreach (var content in bag.Value) {
                        if (content.Key == colour) {
                            sum += recurseBags2(content.Key);
                        }
                    }
                }
                else {
                    Console.WriteLine("wizza");
                }
            }
            return 1;
        }

        private List<string> recCpy(string goal)
        {
            var res = new List<string>();
            res.Add(goal);

            foreach (var bag in _bagRules) {
                foreach (var content in bag.Value) {
                    if (content.Key == goal) {
                        res.AddRange(recCpy(bag.Key));
                    }
                }
            }
            return res;
        }

        public int outerColorsThatCanContainGolden()
        {
            /*foreach (var bag in _bagRules) {
                //if (bag.Key != "shiny gold") {
                    foreach (var content in bag.Value) {
                        sum += recurseBags(content.Key);
                    }
                //}
                //else {
                //    Console.WriteLine("wizza");
                //}
            }*/
            const string goal = "shiny gold";
            var sum0 = recCpy(goal);
            var sum1 = sum0.Distinct().ToList();
            sum1.Remove(goal);
            Console.WriteLine("sum1: " + sum1.Count);

            Console.WriteLine("sum0: " + sum0.Count);
            foreach (var a in sum0) {
                //    Console.WriteLine("sum0: " + a);
            }
            foreach (var a in sum1) {
                //Console.WriteLine("sum1: " + a);
            }
            return sum1.Count;
        }

        private int recurseBags(string colour)
        {
            int found = 0;
            if (_bagRules[colour].Values != null) {
                foreach (var content in _bagRules[colour]) {
                    if (content.Key == "shiny gold") {
                        found += 1;
                    }
                    else {
                        found += recurseBags(content.Key);
                    }
                }
            }
            return found;
        }
    }
}