using System;

namespace Day4
{
    class main
    {
        static void Main(string[] args)
        {
            // Sanity checks.
            if (args.Length != 1) {
                Console.WriteLine("You must supply one argument, a file name.");
                return;
            }
            if (!System.IO.File.Exists(args[0])) {
                Console.WriteLine("Invalid filename.");
                return;
            }

            // Do the magic.
            using var sr = new System.IO.StreamReader(args[0]);
            var passports = new Passport(sr);
            Console.WriteLine("Task 1: valid passports: " + passports.countValid(false));
            Console.WriteLine("Task 2: valid passports: " + passports.countValid(true));
        }
    }
}
