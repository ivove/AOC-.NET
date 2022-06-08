using AOChelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    internal class Day6
    {
        internal static int Part1(bool test = false)
        {
            bool[,] lights = new bool[1000, 1000];
            var on = 0;
            var lines = Helper.ReadMultipleLines(6, test);
            foreach (var line in lines)
            {
                var parts = line.Split(' ');
                if(parts[0] == "turn")
                {
                    var value = true;
                    if (parts[1]=="off") { value = false; }
                    var x1 = int.Parse(parts[2].Split(',')[0]);
                    var y1 = int.Parse(parts[2].Split(',')[1]);
                    var x2 = int.Parse(parts[4].Split(',')[0]);
                    var y2 = int.Parse(parts[4].Split(',')[1]);
                    for (int x = x1; x <= x2; x++)
                    {
                        for (int y = y1; y <= y2; y++)
                        {
                            lights[x, y] = value;
                        }
                    }
                }
                else
                {
                    var x1 = int.Parse(parts[1].Split(',')[0]);
                    var y1 = int.Parse(parts[1].Split(',')[1]);
                    var x2 = int.Parse(parts[3].Split(',')[0]);
                    var y2 = int.Parse(parts[3].Split(',')[1]);
                    for (int x = x1; x <= x2; x++)
                    {
                        for (int y = y1; y <= y2; y++)
                        {
                            lights[x,y] = !lights[x,y];
                        }
                    }
                }
            }
            for (int x = 0; x < 1000; x++)
            {
                for (int y = 0; y < 1000; y++)
                {
                    if (lights[x, y]) { on++; }
                }
            }
            return on;
        }

        internal static int Part2(bool test = false)
        {
            int[,] lights = new int[1000, 1000];
            var on = 0;
            var lines = Helper.ReadMultipleLines(6, test);
            foreach (var line in lines)
            {
                var parts = line.Split(' ');
                if (parts[0] == "turn")
                {
                    var value = 1;
                    if (parts[1] == "off") { value = -1; }
                    var x1 = int.Parse(parts[2].Split(',')[0]);
                    var y1 = int.Parse(parts[2].Split(',')[1]);
                    var x2 = int.Parse(parts[4].Split(',')[0]);
                    var y2 = int.Parse(parts[4].Split(',')[1]);
                    for (int x = x1; x <= x2; x++)
                    {
                        for (int y = y1; y <= y2; y++)
                        {
                            lights[x, y] += value;
                            if (lights[x, y]<0) { lights[x, y] = 0; }
                        }
                    }
                }
                else
                {
                    var x1 = int.Parse(parts[1].Split(',')[0]);
                    var y1 = int.Parse(parts[1].Split(',')[1]);
                    var x2 = int.Parse(parts[3].Split(',')[0]);
                    var y2 = int.Parse(parts[3].Split(',')[1]);
                    for (int x = x1; x <= x2; x++)
                    {
                        for (int y = y1; y <= y2; y++)
                        {
                            lights[x, y] += 2;
                        }
                    }
                }
            }
            for (int x = 0; x < 1000; x++)
            {
                for (int y = 0; y < 1000; y++)
                {
                    on+=lights[x, y];
                }
            }
            return on;
        }
    }
}
