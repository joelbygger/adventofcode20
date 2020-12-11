using System;

namespace Day9
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
                Console.WriteLine("NOTE preamble different (hardcoded) fir example and real code!\n");

                bool foundInvalid = false;
                long val = 0; 
                (foundInvalid, val) = new XMASencryption(args[0]).findInvalidVal(25);
                Console.WriteLine("Task 1: found invalid: {0} and was val: {1}.",
                    foundInvalid, val);
            }
        }
    }
}
