using AOChelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    internal class Day3
    {
        internal static int Part1(bool test = false)
        {
            var line = Helper.ReadOneLine(3, test);
            var currentX = 0;
            var currentY = 0;
            var coord = $"{currentX},{currentY}";
            var grid = new Dictionary<string, int>();
            grid.Add(coord, 1);
            foreach (var c in line)
            {
                if (c == '>') { currentX++; }
                else if (c == '<') { currentX--; }
                else if (c == '^') { currentY++; }
                else if (c == 'v') { currentY--; }
                coord = $"{currentX},{currentY}";
                if (grid.ContainsKey(coord))
                {
                    grid[coord]++;
                }
                else
                {
                    grid.Add(coord, 1);
                }
            }
            return grid.Count;
        }

        internal static int Part2(bool test = false)
        {
            var line = Helper.ReadOneLine(3, test);
            var santaX = 0;
            var santaY = 0;
            var roboX = 0;
            var roboY = 0;
            var santaTurn = true;
            var coord = $"{santaX},{santaY}";
            var grid = new Dictionary<string, int>();
            grid.Add(coord, 2);
            foreach (var c in line)
            {
                if (santaTurn)
                {
                    if (c == '>') { santaX++; }
                    else if (c == '<') { santaX--; }
                    else if (c == '^') { santaY++; }
                    else if (c == 'v') { santaY--; }
                    coord = $"{santaX},{santaY}";
                    santaTurn = false;
                } else
                {
                    if (c == '>') { roboX++; }
                    else if (c == '<') { roboX--; }
                    else if (c == '^') { roboY++; }
                    else if (c == 'v') { roboY--; }
                    coord = $"{roboX},{roboY}";
                    santaTurn = true;
                }
                if (grid.ContainsKey(coord))
                {
                    grid[coord]++;
                }
                else
                {
                    grid.Add(coord, 1);
                }
            }
            return grid.Count;
        }
    }
}
