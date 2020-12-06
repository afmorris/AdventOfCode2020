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
            int minWidth = totalHeight * 3;
            int multiplier = (minWidth / initialWidth) + 1;

            for (int i = 0; i < input.Length; i++)
            {
                input[i] = string.Concat(Enumerable.Repeat(input[i], multiplier));
            }

            int xOffset = 0;
            int noTree = 0;
            int tree = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char spot = input[i][xOffset];
                if (spot == '.')
                {
                    noTree++;
                }
                else if (spot == '#')
                {
                    tree++;
                }

                xOffset += 3;
            }

            Console.WriteLine(tree);
        }
    }
}
