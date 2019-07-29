using System;
using System.Collections.Generic;

namespace Algorithms.RandomTests.CrackingCodingInterview
{
    public class Task15
    {
        public Task15()
        {
            Console.WriteLine(true == Solution("pale", "ple"));
            Console.WriteLine(true == Solution("pales", "pale"));
            Console.WriteLine(true == Solution("pale", "bale"));
            Console.WriteLine(false == Solution("pale", "bake"));
            Console.WriteLine(false == Solution("paaale", "pale"));
            Console.WriteLine(true == Solution("paaale", "paale"));
        }

        private bool Solution(string a, string b)
        {
            if (Math.Abs(a.Length - b.Length) > 1)
            {
                return false;
            }

            var dictA = new Dictionary<char, int>();
            foreach (var c in a)
            {
                dictA[c] = dictA.ContainsKey(c) ? dictA[c] + 1 : 1;
            }
            
            var dictB = new Dictionary<char, int>();
            foreach (var c in b)
            {
                dictB[c] = dictB.ContainsKey(c) ? dictB[c] + 1 : 1;
            }

            foreach (var c in a)
            {
                if (!dictB.ContainsKey(c))
                {
                    continue;
                }

                dictB[c] -= 1;
                
                if (dictB[c] <= 0)
                {
                    dictB.Remove(c);
                }
            }
            
            foreach (var c in b)
            {
                if (!dictA.ContainsKey(c))
                {
                    continue;
                }

                dictA[c] -= 1;
                
                if (dictA[c] <= 0)
                {
                    dictA.Remove(c);
                }
            }

            var count = 0;

            foreach (var v in dictA.Values)
            {
                count += v;
            }
            
            foreach (var v in dictB.Values)
            {
                count += v;
            }

            return count <= 2;
        }
    }
}