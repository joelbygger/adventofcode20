using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day5
{
    public static class PlaneSeats
    {
        public static int calcMaxId(string file)
        {
            return File.ReadAllText(file)
                .Replace('L', '0')
                .Replace('R', '1')
                .Replace('F', '0')
                .Replace('B', '1')
                .Split(System.Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => (
                    row: Convert.ToInt32(s.Substring(0, 7), 2),
                    column: Convert.ToInt32(s.Substring(7), 2)
                ))
                .Select(aaa => aaa.row * 8 + aaa.column).Max();


            /*string[] tmp = File.ReadAllText(file)
                .Replace('L', '0')
                .Replace('R', '1')
                .Replace('F', '0')
                .Replace('B', '1')
                .Split('\n');*/
            /*var apa = from s in tmp
                select(s => new {
                    Convert.ToInt32(s.Substring(0, 7), 2),
                    Convert.ToInt32(s.Substring(7), 2)
                });*/
            /*var 
            var column = Convert.ToInt32(tmp.Substring(7), 2);*/
        }
    }
}