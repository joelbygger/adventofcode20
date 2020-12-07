using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Day4
{
    public class Passport
    {
        private readonly List<string> _passports;

        public Passport(StreamReader sr)
        {
            _passports = new List<string>();
            _passports = readFile(sr);

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

        public int countValid()
        {
            int sum = 0;
            //Regex mainFormat = new Regex(@"(ecl:)?(pid:)?(eyr:)?(hcl:)?(byr:)?(iyr:)?(hgt:)?");
            //var h = mainFormat.Matches(i);

            foreach (var passport in _passports) {
                if (
                    passport.Contains("ecl") &&
                    passport.Contains("pid") &&
                    passport.Contains("eyr") &&
                    passport.Contains("hcl") &&
                    passport.Contains("byr") &&
                    passport.Contains("iyr") &&
                    passport.Contains("hgt")) {
                    /*if(passport.Contains("cid"))*/
                    {
                        sum++;
                    }
                }
            }

            return sum;
        }
    }
}
