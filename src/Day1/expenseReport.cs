using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseReport
{
    public static class ExpenseReport
    {
        static public int? multiplyValsWithSum2020(System.IO.StreamReader sr, int noVals)
        {

            var found = findValsWithSum2020(readFile(sr), noVals);
            if (found.sumFound) {
                return found.vals.Aggregate((a, b) => a * b);
            }
            return null;
        }

        static private List<int> readFile(System.IO.StreamReader sr)
        {
            List<int> expenses = new List<int>();
            while (!sr.EndOfStream) {
                expenses.Add(Convert.ToInt32(sr.ReadLine()));
            }
            return expenses;
        }

        /**
         * Compare all elements to each other until enough (input param) are found.
         * This is a dynamic version of
         *   for(i;i<len;i++) { for(j=i+1;j<len;j++) {list[i] + list[j] }}
         * but me pretending I know CS.
         */
        static private (bool sumFound, List<int> vals) findValsWithSum2020(List<int> expenses, int noVals, List<int>? vals = null)
        {
            bool found = false;

            vals = vals == null ? new List<int>() : vals;

            for (int i = 0; i < expenses.Count && !found; i++) {
                vals.Add(expenses[i]);

                if (noVals > 1) {
                    var ret = findValsWithSum2020(expenses.Skip(i + 1).ToList(), noVals - 1, vals);
                    found = ret.sumFound;
                }
                else {
                    found = vals.Sum() == 2020;
                }

                if (!found) {
                    vals.RemoveAt(vals.Count - 1);
                }
            }

            return (found, vals);
        }
    }
}
