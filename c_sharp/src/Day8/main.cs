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
                Console.WriteLine("Task 1: last acc val: " +
                    new Executor(prgm.get).run().accumulator);

                foreach (var prgmVer in prgm.getModified(Program.OpCodes.jmp, Program.OpCodes.nop)) {
                    var res = new Executor(prgmVer).run();
                    if (!res.infiniteLoop) {
                        Console.WriteLine("Task 2: las acc val: " + res);
                        break;
                    }
                }
            }
        }
    }
}
