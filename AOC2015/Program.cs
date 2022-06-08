﻿// See https://aka.ms/new-console-template for more information
using AOC2015;

#region Day1
/*
Console.WriteLine(Day1.Part1());
Console.WriteLine(Day1.Part2());
*/
#endregion

#region Day2
/*
Console.WriteLine(Day2.Part1());
Console.WriteLine(Day2.Part2());
*/
#endregion

#region Day3
/*
Console.WriteLine(Day3.Part1());
Console.WriteLine(Day3.Part2());
*/
#endregion

#region Day4
Console.Write("secret : ");
var secret = Console.ReadLine();
while (!string.IsNullOrEmpty(secret))
{
    Console.WriteLine("5 zeroes: ");
    Console.WriteLine(Day4.Part1(secret));
    Console.WriteLine("6 zeroes: ");
    Console.WriteLine(Day4.Part2(secret));
    Console.Write("secret : ");
    secret = Console.ReadLine();
}
#endregion