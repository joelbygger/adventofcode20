using System;

namespace Day7
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
                var bags = new BagSorting(args[0]);
                Console.WriteLine("Task 1: sum of bags that can contain color: " +
                    bags.bagsThatCanContain("shiny gold"));
                Console.WriteLine("Task 2: sum of bags inside bag with color: " +
                    bags.bagsInBag("shiny gold"));
            }
        }

    }
}
