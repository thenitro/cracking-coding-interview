using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.RecursionAndDp
{
    public class Task87
    {
        public Task87()
        {
            Console.WriteLine(string.Join(",", Solution("abcde")));
        }

        private List<string> Solution(string input)
        {
            var result = new List<string>();

            SolutionHelper(input, 0, result, new List<char>(), new HashSet<int>());
            
            return result;
        }

        private void SolutionHelper(string input, int index, List<string> result, List<char> tmp, HashSet<int> memo)
        {
            if (tmp.Count == input.Length)
            {
                result.Add(new string(tmp.ToArray()));
                Console.WriteLine(new string(tmp.ToArray()));
            }
            
            if (index >= input.Length)
            {
                return;
            }
            
            for (var i = 0; i < input.Length; i++)
            {
                if (memo.Contains(input[i]))
                {
                    continue;
                }
                
                tmp.Add(input[i]);
                memo.Add(input[i]);
                SolutionHelper(input, i, result, tmp, memo);
                tmp.RemoveAt(tmp.Count - 1);
                memo.Remove(input[i]);
            }
        }
    }
}