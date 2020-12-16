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
            var exp = new ExpenseReport.ExpenseReport(sr);

            int? sum = exp.multiplyValsWithSum2020(2);
            if (sum != null) {
                Console.WriteLine("Task1: Mupltiplied: " + sum);
            }
            else {
                Console.WriteLine("Task1: No valid vals found.");
            }

            sum = exp.multiplyValsWithSum2020(3);
            if (sum != null) {
                Console.WriteLine("Task2: Mupltiplied: " + sum);
            }
            else {
                Console.WriteLine("Task2: No valid vals found.");
            }
        }
    }
}
