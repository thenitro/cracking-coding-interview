using System;
using System.Collections.Generic;

namespace Algorithms.RandomTests.CrackingCodingInterview
{
    /**
     * Is word a permutation of palindrome
     */
    public class Task14
    {
        public Task14()
        {
            Console.WriteLine(true == Solution("Tact Coa"));
            Console.WriteLine(true == Solution("Tact Ca"));
        }

        private bool Solution(string str)
        {
            str = str.ToLower();
            
            var dict = new Dictionary<char, int>();

            foreach (var c in str)
            {
                if (c == ' ')
                {
                    continue;
                }
                
                dict[c] = dict.ContainsKey(c) ? dict[c] + 1 : 1;
            }
            
            var cantBeNotEven = str.Length % 2 != 0;
            
            foreach (var kv in dict)
            {
                if (kv.Value % 2 != 0)
                {
                    if (cantBeNotEven)
                    {
                        return false;
                    }
                    
                    cantBeNotEven = true;
                }
            }

            return true;
        }
    }
}