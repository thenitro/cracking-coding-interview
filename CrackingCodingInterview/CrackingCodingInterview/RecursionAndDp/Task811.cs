using System;

namespace CrackingCodingInterview.RecursionAndDp
{
    public class Task811
    {
        public Task811()
        {
            Console.WriteLine(4 == MySolution(10));
        }

        private int MySolution(int N)
        {
            var coins = new int[] {1, 5, 10, 25};
            var dp = new int[N + 1];
                dp[0] = 1;

            for (var i = 0; i < coins.Length; i++)
            {
                for (var j = coins[i]; j <= N; j++)
                {
                    dp[j] += dp[j - coins[i]];
                }
            }
                
            return dp[N];
        }
    }
}