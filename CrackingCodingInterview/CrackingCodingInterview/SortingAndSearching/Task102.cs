using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.SortingAndSearching
{
    public class Task102
    {
        public Task102()
        {
            Console.WriteLine(string.Join(",", Solution(new string[]
            {
                "cake",
                "abc",
                "eakc",
                "acb",
                "ekca",
                "bca",
                "ekac",
            })));
        }

        public string[] Solution(string[] input)
        {
            var sorted = new Dictionary<string, string>();

            foreach (var s in input)
            {
                var arr = s.ToCharArray();
                Array.Sort(arr);
                sorted[s] = new string(arr);
            }
            
            Array.Sort(input, (s, s1) => sorted[s].CompareTo(sorted[s1]));

            return input;
        }
    }
}