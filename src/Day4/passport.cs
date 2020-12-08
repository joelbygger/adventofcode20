using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Day4
{
    public class Passport
    {
        private readonly List<string> _passports;

        public Passport(StreamReader sr)
        {
            _passports = new List<string>(readFile(sr));

            List<string> readFile(StreamReader sr)
            {
                StringBuilder sb = new StringBuilder();
                string line;
                List<string> passports = new List<string>();

                while (!sr.EndOfStream) {
                    line = sr.ReadLine();
                    if (line != "") {
                        sb.AppendFormat("{0} ", line);
                    }
                    else {
                        passports.Add(sb.ToString().TrimEnd(' '));
                        sb.Clear();
                    }
                }
                passports.Add(sb.ToString().TrimEnd(' '));
                return passports;
            }
        }

        public int countValid(bool useStrictRules)
        {
            int sum = 0;
            (string rules, int count) rules;

            if (useStrictRules) {
                rules = createStrictRules();
            }
            else {
                rules = createSimpleRules();
            }
            Regex mainRegex = new Regex(rules.rules);

            foreach (var passport in _passports) {
                sum += mainRegex.Matches(passport).Count == rules.count ? 1 : 0;
            }

            return sum;
        }

        private (string, int) createStrictRules()
        {
            // Possible /s* should be removed
            // I guess this pattern / method allows same tab to appear several times, might not be ok?
            string[] rules = {
            // [1920-2002]
            @"(\bbyr:\s*(19([2-9][0-9])|(200[0-2]))\b){1}",
            // [2010-2020]
            @"(\biyr:\s*20((1[0-9])|(20))\b){1}",
            // [2020-2030]
            @"(\beyr:\s*20((2[0-9])|(30))\b){1}",
            // [59-76]in or [150-193]cm
            @"(\bhgt:\s*((((59)|(6[0-9])|(7[0-6]))in)|((1(([5-8][0-9])|(9[0-3])))cm)){1})",
            // # followed by 6 digits / chars
            @"(\bhcl:\s*#([0-9,a-f]{6})\b){1}",
            // exactly one of: amb blu brn gry grn hzl oth
            @"(\becl:\s*(amb|blu|brn|gry|grn|hzl|oth)\b){1}",
            // 9 digits
            @"(\bpid:\s*\d{9}\b){1}"};

            //string cid = new Regex(@"(\bcid:\s*\S*\b){1})"; // Match anything.

            return (joinRuleGroups(rules), rules.Length);
        }

        private (string, int) createSimpleRules()
        {
            string[] rules = {
            @"(byr:)",
            @"(iyr:)",
            @"(eyr:)",
            @"(hgt:)",
            @"(hcl:)",
            @"(ecl:)",
            @"(pid:)"};

            return (joinRuleGroups(rules), rules.Length);
        }

        private string joinRuleGroups(string[] rules)
        {
            StringBuilder sb = new StringBuilder();
            const char eitherOr = '|';

            foreach (var rule in rules) {
                sb.AppendFormat("{0}{1}", rule, eitherOr);
            }

            // The last alternator added in loop must be removed.
            return sb.ToString().TrimEnd(eitherOr);
        }
    }
}
