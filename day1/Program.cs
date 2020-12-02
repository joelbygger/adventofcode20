using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public class ExpenseReport
    { 
        static public Tuple<int, int>? FindValsWithSum2020(System.IO.StreamReader sr)
        {
            List<int> expenses = new List<int>();
            Tuple<int, int>? ret = null;

            while (!sr.EndOfStream)
            {
                expenses.Add(Convert.ToInt32(sr.ReadLine()));
                for (int i = 0; i < expenses.Count - 1; i++)
                {
                    for (int j = i + 1; j < expenses.Count; j++)
                    {
                        if (expenses[i] + expenses[j] == 2020)
                        {
                            return new Tuple<int, int>(expenses[i], expenses[j]);
                        }
                    }
                }
            }
            return ret;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 1)
            {
                if (System.IO.File.Exists(args[0]))
                {
                    Console.WriteLine("Exists");
                    using (var sr = new System.IO.StreamReader(args[0]))
                    {
                        Tuple<int, int>? vals = ExpenseReport.FindValsWithSum2020(sr);
                        if (vals != null)
                        {
                            Console.WriteLine("Mupltiplied: " + vals.Item1 * vals.Item2);
                        }
                        else
                        {
                            Console.WriteLine("No valid vals found.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid filename.");
                }
            }
            else
            {
                Console.WriteLine("You must supply one argument, an input file on ASCII format!");
            }
        }
    }
}
