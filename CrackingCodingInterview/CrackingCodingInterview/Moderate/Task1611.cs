using System;
using System.Collections.Generic;
using System.Linq;

namespace CrackingCodingInterview.Moderate
{
    public class Task1611
    {
        public Task1611()
        {
            Console.WriteLine(string.Join(",", Solution(5, 10, 100)));
        }

        private int[] Solution(int shortest, int longest, int k)
        {
            var result = new HashSet<int>();
            var memo = new HashSet<string>();

            SolutionHelper(shortest, longest, k, 0, result, memo);

            return result.ToArray();
        }

        private void SolutionHelper(int shortest, int longest, int k, int total, HashSet<int> result, HashSet<string> memo)
        {
            if (k == 0)
            {
                if (!result.Contains(total))
                {
                    result.Add(total);
                }
                
                return;
            }

            var key = k + "_" + total;
            if (memo.Contains(key))
            {
                return;
            }
            
            SolutionHelper(shortest, longest, k - 1, total + shortest, result, memo);
            SolutionHelper(shortest, longest, k - 1, total + longest, result, memo);

            memo.Add(key);
        }
    }
}