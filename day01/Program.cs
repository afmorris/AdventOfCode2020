using System;
using System.Globalization;
using System.IO;

namespace day01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code: Day 1");

            var input = File.ReadAllLines("input.txt");
            
            for (int i = 0; i < input.Length; i++)
            {
                int record = int.Parse(input[i]);

                for (int j = i + 1; j < input.Length - 1; j++)
                {
                    int secondRecord = int.Parse(input[j]);

                    for (int k = j + 1; k < input.Length - 2; k++)
                    {
                        int thirdRecord = int.Parse(input[k]);

                        if (record + secondRecord + thirdRecord == 2020)
                        {
                            Console.WriteLine(record * secondRecord * thirdRecord);
                            break;
                        }
                    }
                }
            }
        }
    }
}
