using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day2
{
    using PasswordDB = List<(int minTimes, int maxTimes, string chr, string pass)>;

    public class Passwords
    {
        public Passwords(System.IO.StreamReader sr)
        {
            _passwords = new PasswordDB();

            // Read file and populate local storage.
            Regex dbFormat = new Regex(@"(\d+)-(\d+) (.): (.*)");
            string line;
            while ((line = sr.ReadLine()) != null) {
                string[] aPass = dbFormat.Split(line);
                // First and last index in found array is empty stirng, due to how Split works...
                _passwords.Add((
                    minTimes: Convert.ToInt32(aPass[1]),
                    maxTimes: Convert.ToInt32(aPass[2]),
                    chr: aPass[3],
                    pass: aPass[4]));
            }
        }

        public int countValid()
        {
            int sum = 0;
            foreach (var pass in _passwords) {
                Console.WriteLine(pass);
                sum += isValid(pass) ? 1 : 0;

                Console.WriteLine("Sum: " + sum);
            }
            return sum;
        }

        // Would be cool to have a using directive for this type, don't know how to do that.
        private bool isValid((int minTimes, int maxTimes, string chr, string pass) pass)
        {
            Regex rgx = new Regex(pass.chr);
            var cnt = rgx.Matches(pass.pass).Count;
            return (cnt <= pass.maxTimes && cnt >= pass.minTimes);
        }

        private readonly PasswordDB _passwords;
    }
}
