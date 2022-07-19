using AOChelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    internal class Day9
    {
        internal static int Part1(bool test = false)
        {
            var lines = Helper.ReadMultipleLines(9, test);
            var cities = new List<string>();
            var distances = new Dictionary<string, int>();
            foreach (var line in lines)
            {
                var items = line.Split(' ');
                var from = items[0];
                var to = items[2];
                if (!cities.Contains(items[0])) { cities.Add(from); }
                if (!cities.Contains(items[2])) { cities.Add(to); }
                var distance = int.Parse(items[4]);
                distances.Add($"{from}|{to}", distance);
                distances.Add($"{to}|{from}",distance);

            }
            var routes = new List<string>();
            Helper.Permute(cities, routes);
            var min = int.MaxValue;
            foreach(var route in routes)
            {
                // Console.WriteLine($"{route} - {GetDistance(route,distances)}");
                var distance = GetDistance(route, distances);
                if (distance < min) { min = distance; }
            }
            return min;
        }

        internal static int Part2(bool test = false)
        {
            var lines = Helper.ReadMultipleLines(9, test);
            var cities = new List<string>();
            var distances = new Dictionary<string, int>();
            foreach (var line in lines)
            {
                var items = line.Split(' ');
                var from = items[0];
                var to = items[2];
                if (!cities.Contains(items[0])) { cities.Add(from); }
                if (!cities.Contains(items[2])) { cities.Add(to); }
                var distance = int.Parse(items[4]);
                distances.Add($"{from}|{to}", distance);
                distances.Add($"{to}|{from}", distance);

            }
            var routes = new List<string>();
            Helper.Permute(cities, routes);
            var max = 0;
            foreach (var route in routes)
            {
                // Console.WriteLine($"{route} - {GetDistance(route,distances)}");
                var distance = GetDistance(route, distances);
                if (distance > max) { max = distance; }
            }
            return max;
        }

        private static int GetDistance(string route,Dictionary<string,int> distances)
        {
            var dist = 0;
            var steps = route.Split('|');
            for (var i = 1; i < steps.Length; i++)
            {
                var step = steps[i];
                var previous = steps[i - 1];
                dist += distances[$"{previous}|{step}"];
            }
            return dist;
        }
    }
}
