using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.RecursionAndDp
{
    public class Task81
    {
        public Task81()
        {
            Console.WriteLine(1 == SolutionRecursive(1));
            Console.WriteLine(2 == SolutionRecursive(2));
            Console.WriteLine(4 == SolutionRecursive(3));
            Console.WriteLine(7 == SolutionRecursive(4));
            
            Console.WriteLine(1 == SolutionMemo(1));
            Console.WriteLine(2 == SolutionMemo(2));
            Console.WriteLine(4 == SolutionMemo(3));
            Console.WriteLine(7 == SolutionMemo(4));
            
            Console.WriteLine(1 == SolutionDp(1));
            Console.WriteLine(2 == SolutionDp(2));
            Console.WriteLine(4 == SolutionDp(3));
            Console.WriteLine(7 == SolutionDp(4));
        }

        private int SolutionRecursive(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            if (n < 0)
            {
                return 0;
            }
            
            return SolutionRecursive(n - 1) + SolutionRecursive(n - 2) + SolutionRecursive(n - 3);
        }
        
        private int SolutionMemo(int n)
        {
            return SolutionMemoHelper(n, new Dictionary<int, int>());
        }

        private int SolutionMemoHelper(int n, Dictionary<int, int> memo)
        {
            if (memo.ContainsKey(n))
            {
                return memo[n];
            }
            
            if (n == 0)
            {
                return 1;
            }

            if (n < 0)
            {
                return 0;
            }
            
            memo[n] = SolutionRecursive(n - 1) + SolutionRecursive(n - 2) + SolutionRecursive(n - 3); 
            
            return memo[n];
        }

        private int SolutionDp(int n)
        {
            var dp = new int[Math.Max(n + 1, 3)];
                dp[0] = 1;
                dp[1] = 1;
                dp[2] = 2;

            for (var i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2] + dp[i - 3];
            }

            return dp[n];
        }
    }
}