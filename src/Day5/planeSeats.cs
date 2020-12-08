using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day5
{
    public class PlaneSeats
    {
        private readonly List<(int row, int column, int rawNo)> _seats;
        public PlaneSeats(string file)
        {
            _seats = File.ReadAllText(file)
                .Replace('L', '0')
                .Replace('R', '1')
                .Replace('F', '0')
                .Replace('B', '1')
                .Split(System.Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => (
                    row: Convert.ToInt32(s.Substring(0, 7), 2),
                    column: Convert.ToInt32(s.Substring(7), 2),
                    rawNo: Convert.ToInt32(s, 2)
                ))
                .ToList();
        }
        public int calcMaxId()
        {
            return _seats
                .Select(s => calcSeatID(s)).Max();
        }

        public int findEmptySeat()
        {
            //List<string> seatNo = _rawSeats
            /*var seatNo = _seats
                //.ForEach(delegate(string s) { return new Convert.ToInt32(s.Substring(0, 7), 2); });
                .Select(s => Convert.ToInt32(s, 2))
                .ToList();*/

            var cpy = _seats;
            cpy.Sort(delegate((int row, int column, int rawNo) x, (int row, int column, int rawNo) y) {
                return x.rawNo.CompareTo(y.rawNo);
            });

            for (int i = 1; i < cpy.Count() - 1; i++) {
                int prev = cpy[i - 1].rawNo;

                if (cpy[i].rawNo != prev + 1) {
                    if (cpy[i].rawNo + 1 == cpy[i + 1].rawNo) {
                        return cpy[i].rawNo - 1;
                    }
                    else {
                        Console.WriteLine("Should not happen? " + cpy[i].rawNo);
                    }
                }
            }
            return 0;
        }

        private static int calcSeatID((int row, int column, int rawNo) s)
        {
            return s.row * 8 + s.column; // Same as rawNo.
        }
    }
}