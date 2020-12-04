using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Day2
{
    using PasswordDB = List<(int minTimes, int maxTimes, string chr, string pass)>;

    public class Passwords
    {
        public Passwords(System.IO.StreamReader sr)
        {
            _passwords = new PasswordDB();

            Regex dbFormat = new Regex(@"(\d+)-(\d+) (.): (.*)");
            string line;
            //while (!sr.EndOfStream) {
            //foreach (string line in sr.ReadLine()) {
            //string line = sr.ReadLine();
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
            foreach(var pass in _passwords) {
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

        /*
        static public int? work2(string fileName)
        {
            // LINQ instead https://docs.microsoft.com/en-us/dotnet/api/system.io.file.readlines?view=net-5.0 ?
            Regex rgx = new Regex(@"(\d+)-(\d+) (.): (.*)");

            var store = new List<(int minTimes, int maxTimes, string chr, string pass)>();

            var hej = System.IO.File.ReadLines(fileName);
            var hej2 = System.IO.File.ReadAllLines(fileName);

            var apa = from line1 in System.IO.File.ReadAllLines(fileName)
                      from found0 in rgx.Split(line1)
                      from found1 in found0
                      select new {
                          a = found1
                      }
                      into he
                      select new { c = he };


            foreach (var itm in apa) {
                Console.WriteLine(" - " + itm.c);
            }
            return 0;
        }*/

        private PasswordDB _passwords;
    }
}
