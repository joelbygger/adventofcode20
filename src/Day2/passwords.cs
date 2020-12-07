using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day2
{
    using PasswordDB = List<(int min, int max, string chr, string pass)>;

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
                    min: Convert.ToInt32(aPass[1]),
                    max: Convert.ToInt32(aPass[2]),
                    chr: aPass[3],
                    pass: aPass[4]));
            }
        }

        public int countValidTask1()
        {
            /*int sum 0;
            foreach (var pass in _passwords) {
                Regex rgx = new Regex(pass.chr);
                var cnt = rgx.Matches(pass.pass).Count;
                if (cnt <= pass.max && cnt >= pass.min) {
                    sum++;
                }
            }
            return sum;*/
            var valids = from pass in _passwords
                         where pass.pass.Count(c => c == pass.chr[0]) <= pass.max
                         where pass.pass.Count(c => c == pass.chr[0]) >= pass.min
                         select pass;
            return valids.Count();
        }

        public int countValidTask2()
        {
            int sum = 0;
            foreach (var pass in _passwords) {
                if (pass.pass.Substring(pass.min - 1, 1).Equals(pass.chr) ^
                    (pass.pass.Length >= pass.max &&
                    pass.pass.Substring(pass.max - 1, 1).Equals(pass.chr))) {
                    sum++;
                }
            }
            return sum;
        }

        // Would be cool to have a using directive for this type, don't know how to do that.
        private bool isValid((int min, int max, string chr, string pass) pass)
        {
            Regex rgx = new Regex(pass.chr);
            var cnt = rgx.Matches(pass.pass).Count;
            return (cnt <= pass.max && cnt >= pass.min);
        }

        private readonly PasswordDB _passwords;
    }
}
