using AOChelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    internal class Day2
    {
        internal static int Part1(bool test = false)
        {
            int result = 0;
            var lines = Helper.ReadMultipleLines(2, test);
            foreach(var line in lines)
            {
                var parts = line.Split('x');
                var l = int.Parse(parts[0]);
                var w = int.Parse(parts[1]);
                var h = int.Parse(parts[2]);
                var side1 = l * w;
                var side2 = w * h;
                var side3 = h * l;
                var smallest = side1;
                if (side2< smallest) { smallest = side2; }
                if (side3< smallest) { smallest = side3; }
                result +=((2*side1)+(2*side2)+(2*side3)+smallest);
            }
            return result;
        }

        internal static int Part2(bool test = false)
        {
            int result = 0;
            var lines = Helper.ReadMultipleLines(2, test);
            foreach (var line in lines)
            {
                var parts = line.Split('x');
                var l = int.Parse(parts[0]);
                var w = int.Parse(parts[1]);
                var h = int.Parse(parts[2]);
                var p1 = l + l + w + w;
                var p2 = l + l + h + h;
                var p3 = h + h + w + w;
                var smallest = p1;
                if (p2 < smallest) { smallest = p2; }
                if (p3 < smallest) { smallest = p3; }
                result += ((smallest) + (l*w*h));
            }
            return result;
        }
    }
}
