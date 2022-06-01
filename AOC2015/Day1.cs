using AOChelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    internal class Day1
    {
        internal static int Part1(bool test = false)
        {
            var line = Helper.ReadOneLine(1,test);
            var floor = 0;
            foreach(var c in line)
            {
                if (c == '(') { floor++; }
                else if (c == ')') { floor--; }
            }
            return floor;
        }

        internal static int Part2(bool test = false)
        {
            var line = Helper.ReadOneLine(1,test);
            int floor = 0;
            var pos = 1;
            while (floor >= 0)
            {
                var c = line[pos-1];
                if (c == '(') { floor++; }
                else if (c == ')') { floor--; }
                if (floor >= 0) { pos++; }
            }
            return pos;
        }
    }
}
