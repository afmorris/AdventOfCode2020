using System;
using System.IO;
using System.Linq;

namespace day03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code: Day 3");

            string[] input = File.ReadAllLines("input.txt");

            int totalHeight = input.Length;
            int initialWidth = input[0].Length;
            int minWidth = totalHeight * 7;
            int multiplier = (minWidth / initialWidth) + 1;

            for (int i = 0; i < input.Length; i++)
            {
                input[i] = string.Concat(Enumerable.Repeat(input[i], multiplier));
            }

            long first = TreeCount(1, 1, input);
            long second = TreeCount(3, 1, input);
            long third = TreeCount(5, 1, input);
            long fourth = TreeCount(7, 1, input);
            long fifth = TreeCount(1, 2, input);

            Console.WriteLine(first * second * third * fourth * fifth);
        }

        private static long TreeCount(int xOffset, int yOffset, string[] input)
        {
            int x = 0;
            long output = 0;
            for (int i = 0; i < input.Length; i += yOffset)
            {
                char spot = input[i][x];
                if (spot == '#')
                {
                    output++;
                }

                x += xOffset;
            }

            return output;
        }
    }
}
