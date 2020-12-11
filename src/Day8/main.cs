using System;

namespace Day8
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
                var prgm = new Program(args[0]);
                var exec = new Executor(prgm.get);
                Console.WriteLine("Task 1: last acc val: " +
                    exec.run());/*
                Console.WriteLine("Task 2: sum of all common yes: " +
                    seats.sumCommonYesPerGroup());*/
            }
        }
    }
}
