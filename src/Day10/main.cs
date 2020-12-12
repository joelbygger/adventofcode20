using System;

namespace Day10
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
                var adapter = new AdapterSorting(args[0]);
                Console.WriteLine("Task 1: sum: " + adapter.getSum1and3StepInChain());
            }
        }
    }
}
