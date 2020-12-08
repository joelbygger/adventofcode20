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
                    rawNo: Convert.ToInt32(s, 2) // Same as using formula row*8 + col.
                ))
                .ToList();

            // Sorting will made task 1 & 2 easier.
            _seats.Sort(delegate ((int row, int column, int rawNo) x, (int row, int column, int rawNo) y) {
                return x.rawNo.CompareTo(y.rawNo);
            });
        }
        public int calcMaxId()
        {
            return _seats.Last().rawNo;
        }

        public int findEmptySeat()
        {
            for (int i = 1; i < _seats.Count() - 1; i++) {
                int prev = _seats[i - 1].rawNo;

                if (_seats[i].rawNo != prev + 1) {
                    if (_seats[i].rawNo + 1 == _seats[i + 1].rawNo) {
                        return _seats[i].rawNo - 1;
                    }
                    else {
                        Console.WriteLine("Should not happen? " + _seats[i].rawNo);
                    }
                }
            }
            return 0;
        }
    }
}