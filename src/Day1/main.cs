using System;

namespace Day1
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
            int? sum = ExpenseReport.ExpenseReport.multiplyValsWithSum2020(sr);
            if (sum != null) {
                Console.WriteLine("Mupltiplied: " + sum);
            }
            else {
                Console.WriteLine("No valid vals found.");
            }
        }
    }
}
