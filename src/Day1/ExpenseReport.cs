using System;
using System.Collections.Generic;

namespace ExpenseReport
{
    public class ExpenseReport
    {
        static public int? multiplyValsWithSum2020(System.IO.StreamReader sr)
        {
            Tuple<int, int>? vals = findValsWithSum2020(readFile(sr));
            int? res = null;
            if (vals != null) {
                res = vals.Item1 * vals.Item2;
            }
            return res;
        }

        static private List<int> readFile(System.IO.StreamReader sr)
        {
            List<int> expenses = new List<int>();
            while (!sr.EndOfStream) {
                expenses.Add(Convert.ToInt32(sr.ReadLine()));
            }
            return expenses;
        }

        static private Tuple<int, int>? findValsWithSum2020(List<int> expenses)
        {
            Tuple<int, int>? ret = null;

            for (int i = 0; i < expenses.Count - 1; i++) {
                for (int j = i + 1; j < expenses.Count; j++) {
                    if (expenses[i] + expenses[j] == 2020) {
                        return new Tuple<int, int>(expenses[i], expenses[j]);
                    }
                }
            }

            return ret;
        }
    }
}
