using System;

namespace Day6
{
    class main
    {
        static void Main(string[] args)
        {
            if (args.Length == 0) {
                Console.WriteLine("You must supply one argument, file name.");

            }
            else if (!System.IO.File.Exists(args[0])) {
                Console.WriteLine("Invalid filename");
            }
            else {
                var seats = new Questionnaire(args[0]);
                Console.WriteLine("Task 1: sum of all unique yes: " +
                    seats.sumAllUniqueYesPerGroup());
                Console.WriteLine("Task 2: sum of all common yes: " +
                    seats.sumCommonYesPerGroup());
            }
        }
    }
}
