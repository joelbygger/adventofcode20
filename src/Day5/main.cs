using System;

namespace Day5
{
    class main
    {
        static void Main(string[] args)
        {
            if (args.Length != 1) {
                Console.WriteLine("You must supply one argument, file name.");
            }
            else if (!System.IO.File.Exists(args[0])) {
                Console.WriteLine("Invlid filename.");
            }
            else {
                Console.WriteLine("Task 1: Max seat ID: " + new PlaneSeats(args[0]).calcMaxId());
                Console.WriteLine("Task 2: med: " + new PlaneSeats(args[0]).findEmptySeat());
            }
            return;
        }
    }
}
