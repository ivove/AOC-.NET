using AOChelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    internal class Day4
    {
        internal static int Part1(string secret)
        {
            var number = -1;
            var found = false;
            while (!found)
            {
                number++;
                var hash = Helper.CreateMD5($"{secret}{number}");
                if (hash.StartsWith("00000")) { found = true; }
            }
            return number;
        }

        internal static int Part2(string secret)
        {
            var number = -1;
            var found = false;
            while (!found)
            {
                number++;
                var hash = Helper.CreateMD5($"{secret}{number}");
                if (hash.StartsWith("000000")) { found = true; }
            }
            return number;
        }
    }
}
