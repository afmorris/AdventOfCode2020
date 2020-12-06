using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code: Day 4");

            string[] input = File.ReadAllLines("input.txt");

            var passports = new List<List<Dictionary<string, string>>>();
            var passport = new List<Dictionary<string, string>>();
            
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == "")
                {
                    passports.Add(passport);
                    passport = new List<Dictionary<string, string>>();
                }
                else
                {
                    var items = input[i].Split(" ");
                    foreach (var item in items)
                    {
                        var kvpString = item.Split(":");
                        var kvp = new Dictionary<string, string>();
                        kvp.Add(kvpString[0], kvpString[1]);
                        passport.Add(kvp);
                    }
                }
            }

            int correct = 0;
            foreach (var p in passports)
            {
                var byr = p.Any(x => x.ContainsKey("byr"));
                var iyr = p.Any(x => x.ContainsKey("iyr"));
                var eyr = p.Any(x => x.ContainsKey("eyr"));
                var hgt = p.Any(x => x.ContainsKey("hgt"));
                var hcl = p.Any(x => x.ContainsKey("hcl"));
                var ecl = p.Any(x => x.ContainsKey("ecl"));
                var pid = p.Any(x => x.ContainsKey("pid"));
                var cid = p.Any(x => x.ContainsKey("cid"));

                if (byr && iyr && eyr && hgt && hcl && ecl && pid)
                {
                    correct++;
                }
            }

            Console.WriteLine(correct);
        }
    }
}
