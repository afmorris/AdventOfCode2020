using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day04
{
    class Program
    {
        static int numCorrect = 0;
        static int numFailTest = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code: Day 4");

            string[] input = File.ReadAllLines("input.txt");

            var passports = new List<Dictionary<string, string>>();
            var passport = new Dictionary<string, string>();
            var correctPassports = new List<Dictionary<string, string>>();
            var invalidPassports = new List<Dictionary<string, string>>();
            
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == "")
                {
                    passports.Add(passport);
                    passport = new Dictionary<string, string>();
                }
                else
                {
                    var items = input[i].Split(" ");
                    foreach (var item in items)
                    {
                        var kvpString = item.Split(":");
                        passport.Add(kvpString[0], kvpString[1]);
                    }
                }
            }

            int correct = 0;
            foreach (var p in passports)
            {
                var byr = IsValid(p, "byr", x => {
                    if (x.Length == 4)
                    {
                        int num = 0;
                        if (int.TryParse(x, out num))
                        {
                            if (num >= 1920 && num <= 2002)
                            {
                                return true;
                            }
                        }
                    }

                    return false;
                });

                var iyr = IsValid(p, "iyr", x => {
                    if (x.Length == 4)
                    {
                        int num = 0;
                        if (int.TryParse(x, out num))
                        {
                            if (num >= 2010 && num <= 2020)
                            {
                                return true;
                            }
                        }
                    }

                    return false;
                });

                var eyr = IsValid(p, "eyr", x => {
                    if (x.Length == 4)
                    {
                        int num = 0;
                        if (int.TryParse(x, out num))
                        {
                            if (num >= 2020 && num <= 2030)
                            {
                                return true;
                            }
                        }
                    }

                    return false;
                });

                var hgt = IsValid(p, "hgt", x => {
                    var lastTwo = x.Substring(Math.Max(0, x.Length - 2));
                    if (lastTwo == "cm")
                    {
                        var number = x.Substring(0, x.IndexOf(lastTwo));
                        int num = 0;
                        if (int.TryParse(number, out num))
                        {
                            if (num >= 150 && num <= 193)
                            {
                                return true;
                            }
                        }
                    }
                    else if (lastTwo == "in")
                    {
                        var number = x.Substring(0, x.IndexOf(lastTwo));
                        int num = 0;
                        if (int.TryParse(number, out num))
                        {
                            if (num >= 59 && num <= 76)
                            {
                                return true;
                            }
                        }
                    }

                    return false;
                });

                var hcl = IsValid(p, "hcl", x => {
                    if (x[0] == '#')
                    {
                        if (x.Length == 7)
                        {
                            var hex = x.Substring(1);
                            int output;
                            if (int.TryParse(hex, System.Globalization.NumberStyles.HexNumber, null, out output))
                            {
                                return true;
                            }
                        }
                    }

                    return false;
                });

                var ecl = IsValid(p, "ecl", x => {
                    if (x == "amb" || x == "blu" || x == "brn" || x == "gry" || x == "grn" || x == "hzl" || x == "oth")
                    {
                        return true;
                    }

                    return false;
                });

                var pid = IsValid(p, "pid", x => {
                    int num = 0;
                    if (int.TryParse(x, out num))
                    {
                        return x.Length == 9;
                    }

                    return false;
                });

                if (byr && iyr && eyr && hgt && hcl && ecl && pid)
                {
                    correct++;
                    correctPassports.Add(p);
                }
                else
                {

                }
            }

            Console.WriteLine(correct);
        }

        private static bool IsValid(Dictionary<string, string> passport, string key, Func<string, bool> test)
        {
            if (passport.ContainsKey(key))
            {
                var value = passport[key];
                return test(value);
            }

            return false;
        }
    }
}
