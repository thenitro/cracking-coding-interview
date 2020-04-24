using System;
using System.Collections.Generic;
using System.Linq;

namespace CrackingCodingInterview.RecursionAndDp
{
    public class Task88
    {
        public Task88()
        {
            Console.WriteLine(string.Join(" ", Solution("aabbccddee")));
        }

        private List<string> Solution(string str)
        {
            var result = new List<string>();
            var dict = BuildDict(str);

            SolutionHelper(dict, string.Empty, str.Length, result);
            
            return result;
        }

        private void SolutionHelper(Dictionary<char, int> dict, string prefix, int remaining, List<string> result)
        {
            if (remaining == 0)
            {
                result.Add(prefix);
                return;
            }

            var keys = dict.Keys.ToArray();
            foreach (var c in keys)
            {
                var count = dict[c];
                if (count > 0)
                {
                    dict[c] = count - 1;
                    SolutionHelper(dict, prefix + c, remaining - 1, result);
                    dict[c] = count;
                }
            }
        }

        private Dictionary<char, int> BuildDict(string str)
        {
            var result = new Dictionary<char, int>();

            foreach (var c in str)
            {
                result[c] = result.ContainsKey(c) ? result[c] + 1 : 1;
            }
            
            return result;
        }
    }
}