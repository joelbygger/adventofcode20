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
                Console.WriteLine("Task 1: sum of all yes: " +
                    new Questionnaire(args[0]).yesCnt());
            }
        }
    }
}
