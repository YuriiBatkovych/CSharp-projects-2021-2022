using System;
using System.Collections.Generic;
using System.Linq;

namespace CW04_3
{
    class Program
    {
        static void Main(string[] args)
        {
      
            List<string> cities = new List<string>();

            string input = RemoveEmptyCharsFromStart(Console.ReadLine());

            while (!input.Equals("X"))
            {
                cities.Add(input);
                input = RemoveEmptyCharsFromStart(Console.ReadLine());
            }

            Dictionary<char, IGrouping<char, string>> groupedCities = cities.OrderBy(x => x)
                                                                            .GroupBy(x => x[0])
                                                                            .ToDictionary(x=>x.Key,  x => x);

            input = RemoveEmptyCharsFromStart(Console.ReadLine());

            while(!input.Equals("STOP"))
            {
                if (groupedCities.ContainsKey(input[0]))
                {
                    var last = groupedCities[input[0]].Last();

                    foreach (var item in groupedCities[input[0]])
                    {
                        Console.Write(item);
                        if (last != item)
                            Console.Write(", ");
                    }
                }
                else
                    Console.Write("PUSTE");

                Console.WriteLine();
                input = RemoveEmptyCharsFromStart(Console.ReadLine());

            }
        }

        static string RemoveEmptyCharsFromStart(string s)
        {
            int i = 0;
            while (i < s.Length && s[i] == ' ') i++;

            s = s.Substring(i);
            if (s.Length > 0) return s;
            else return "non defined city";
        }
    }
}
