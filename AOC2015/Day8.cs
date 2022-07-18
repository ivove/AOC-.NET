using AOChelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    internal class Day8
    {
        internal static int Part1(bool test = false)
        {
            var lines = Helper.ReadMultipleLines(8, test);
            int result = 0;
            foreach(var line in lines)
            {
                result += CountChars(line);
                result -= CountMemoryChars(line);
                if (test)
                {
                    //Console.WriteLine($"{line} / {line} -> {CountChars(line)} -- {CountMemoryChars(line)}");
                }
            }
            return result;
        }

        private static int CountChars(string input)
        {
            return input.Length;
        }

        private static int CountMemoryChars(string input)
        {
            input = input.Substring(1, input.Length - 2);
            var output = "";
            if (input != "")
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] != '\\')
                    {
                        output += input[i];
                    }
                    else
                    {
                        if (input[i+1]== '\\')
                        {
                            output += "\\";
                            i++;
                        }
                        else if (input[i+1]=='\"')
                        {
                            output += "\"";
                            i++;
                        }
                        else if (input[i + 1] == 'x')
                        {
                            output += "#";
                            i += 3;
                        }
                    }
                }
            }
            //Console.WriteLine($" --> {input} --> {output}");
            return output.Length;
        }

        internal static int Part2(bool test = false)
        {
            var lines = Helper.ReadMultipleLines(8, test);
            int result = 0;
            foreach (var line in lines)
            {
                var newLine = Encode(line);
                result += CountChars(newLine);
                result -= CountChars(line);
                if (test)
                {
                    Console.WriteLine($"{line} ==> {newLine} -> {CountChars(line)} -- {CountChars(newLine)}");
                }
            }
            return result;
        }

        private static string Encode(string input)
        {
            var output = "\"";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\"')
                {
                    output += "\\\"";
                }
                else if (input[i] == '\\')
                {
                    output += "\\\\";
                }
                else
                {
                    output += input[i];
                }
            }
            output += "\"";
            return output;
        }
    }
}
