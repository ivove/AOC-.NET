using AOChelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    internal class Day5
    {
        internal static int Part1(bool test = false)
        {
            var number = 0;
            var lines = Helper.ReadMultipleLines(5, test);
            foreach (var line in lines)
            {
                if (IsNice(line)) { number++; }
            }
            return number;
        }

        internal static int Part2(bool test = false)
        {
            int number = 0;
            var lines = Helper.ReadMultipleLines(5, test);
            foreach (var line in lines)
            {
                if (IsNice2(line)) { number++; }
            }
            return number;
        }

        internal static bool IsNice(string input)
        {
            char prev = ' ';
            var doubles = false;
            var forbidden = false;
            string vowels = "aeiou";
            var vowelCount = 0;
            foreach (var c in input)
            {
                if (vowels.Contains(c))
                {
                    vowelCount++;
                }
                if (c == prev) { doubles = true; }
                if (prev == 'a' && c == 'b') { forbidden = true; }
                else if (prev == 'c' && c == 'd') { forbidden = true; }
                else if (prev == 'p' && c == 'q') { forbidden = true; }
                else if (prev == 'x' && c == 'y') { forbidden = true; }
                prev = c;
            }
            if (forbidden) { return false; }
            if (!doubles) { return false; }
            if (vowelCount < 3) { return false; }
            return true;
        }

        internal static bool IsNice2(string input)
        {
            var hasPair = false;
            var repeat = false;
            var pairs = new List<string>();
            var prev = ' ';
            var pprev = ' ';
            foreach (var c in input)
            {
                if (pairs.Contains($"{prev}{c}") && $"{pprev}{prev}" != $"{prev}{c}" ) { hasPair = true; }
                pairs.Add($"{prev}{c}");
                if (c == pprev) { repeat = true; }
                pprev = prev;
                prev = c;
            }
            return (hasPair && repeat);
        }
    }
}
