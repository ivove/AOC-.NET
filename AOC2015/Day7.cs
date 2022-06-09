using AOChelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    internal class Day7
    {
        internal static int Part1(bool test = false)
        {
            var wires = new Dictionary<string, int>();
            var instructions = Helper.ReadMultipleLines(7, test);
            int i = 0;
            while (instructions.Count > 0)
            {
                var line = instructions[i];
                var done = CanDo(line,wires);
                if (done)
                {
                    var parts = line.Split(' ');
                    if (parts.Length == 3)
                    {
                        wires.Add(parts[2], GetValue(parts[0],wires));                        
                    }
                    else if (parts.Length == 4)
                    {
                        if (!wires.ContainsKey(parts[3])) { wires.Add(parts[3], 0); }
                        wires[parts[3]] = ~wires[parts[1]];
                    }
                    else if (parts.Length == 5)
                    {
                        var opp = parts[1];
                        if (!wires.ContainsKey(parts[4])) { wires.Add(parts[4], 0); }
                        if (opp == "AND")
                        {
                            wires[parts[4]] = GetValue(parts[0],wires) & GetValue(parts[2],wires);
                        }
                        else if (opp == "OR")
                        {
                            wires[parts[4]] = GetValue(parts[0], wires) | GetValue(parts[2], wires);
                        }
                        else if (opp == "LSHIFT")
                        {
                            wires[parts[4]] = GetValue(parts[0], wires) << GetValue(parts[2], wires);
                        }
                        else if (opp == "RSHIFT")
                        {
                            wires[parts[4]] = GetValue(parts[0], wires) >> GetValue(parts[2], wires);
                        }
                    }
                    instructions.Remove(line);
                }
                i++;
                if (i>=instructions.Count) { i = 0; }
            }
            return wires["a"];
        }

        internal static int Part2(bool test = false)
        {
            var wires = new Dictionary<string, int>();
            var instructions = Helper.ReadMultipleLines(7, test);
            int i = 0;
            while (instructions.Count > 0)
            {
                var line = instructions[i];
                var done = CanDo(line, wires);
                if (done)
                {
                    var parts = line.Split(' ');
                    if (parts.Length == 3)
                    {
                        if (parts[2] != "b")
                        {
                            wires.Add(parts[2], GetValue(parts[0], wires));
                        }
                        else
                        {
                            wires.Add(parts[2], 16076);
                        }
                    }
                    else if (parts.Length == 4)
                    {
                        if (!wires.ContainsKey(parts[3])) { wires.Add(parts[3], 0); }
                        wires[parts[3]] = ~wires[parts[1]];
                    }
                    else if (parts.Length == 5)
                    {
                        var opp = parts[1];
                        if (!wires.ContainsKey(parts[4])) { wires.Add(parts[4], 0); }
                        if (opp == "AND")
                        {
                            wires[parts[4]] = GetValue(parts[0], wires) & GetValue(parts[2], wires);
                        }
                        else if (opp == "OR")
                        {
                            wires[parts[4]] = GetValue(parts[0], wires) | GetValue(parts[2], wires);
                        }
                        else if (opp == "LSHIFT")
                        {
                            wires[parts[4]] = GetValue(parts[0], wires) << GetValue(parts[2], wires);
                        }
                        else if (opp == "RSHIFT")
                        {
                            wires[parts[4]] = GetValue(parts[0], wires) >> GetValue(parts[2], wires);
                        }
                    }
                    instructions.Remove(line);
                }
                i++;
                if (i >= instructions.Count) { i = 0; }
            }
            return wires["a"];
        }

        private static bool CanDo(string instruction,Dictionary<string,int> wires)
        {
            var canDo = false;
            var parts = instruction.Split(' ');
            if (parts.Length == 3)
            {
                if (int.TryParse(parts[0], out int value)) { canDo = true; }
                else
                {
                    if (wires.ContainsKey(parts[0])) { canDo = true; }
                }
            }
            else if (parts.Length == 4)
            {
                if (wires.ContainsKey(parts[1])) { canDo = true; }
            }
            else if (parts.Length == 5)
            {
                if (wires.ContainsKey(parts[0]) && wires.ContainsKey(parts[2])) { canDo = true; }
                else if (int.TryParse(parts[0], out int value) && wires.ContainsKey(parts[2])) { canDo = true; }
                else if (int.TryParse(parts[2], out int value1) && wires.ContainsKey(parts[0])) { canDo = true; }
                else if (int.TryParse(parts[0], out int value2) && int.TryParse(parts[2], out int value3)) { canDo = true; }
            }
                return canDo;
        }
        private static int GetValue(string part,Dictionary<string,int> wires)
        {
            if (int.TryParse(part, out int value)) { return value; }
            else { return wires[part]; }
        }
    }
}
