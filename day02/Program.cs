using System;
using System.IO;

namespace day02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code: Day 2");

            string[] input = File.ReadAllLines("input.txt");

            int correct = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var dashIndex = input[i].IndexOf('-');
                var spaceIndex = input[i].IndexOf(' ');
                var colonIndex = input[i].IndexOf(':');

                var min = int.Parse(input[i].Substring(0, dashIndex));
                var max = int.Parse(input[i].Substring(dashIndex + 1, spaceIndex - dashIndex - 1));
                var letter = char.Parse(input[i].Substring(colonIndex - 1, 1));
                var password = input[i].Substring(colonIndex + 2);

                var test1 = password[min - 1] == letter;
                var test2 = password[max - 1] == letter;
                if ((test1 && !test2) || (!test1 && test2))
                {
                    correct++;
                }
            }

            Console.WriteLine(correct);
        }
    }
}
