using System;

namespace CrackingCodingInterview.Moderate
{
    public class Task1617
    {
        public Task1617()
        {
            Console.WriteLine(5 == Solution(new []{ -8, 3, -2, 4, -10 }));
        }

        private int Solution(int[] array)
        {
            var dp = new int[array.Length];
                dp[0] = array[0];

            for (var i = 1; i < array.Length; i++)
            {
                dp[i] = Math.Max(array[i], array[i] + dp[i - 1]);

                Console.WriteLine(string.Join(",", dp));
            }

            var sum = int.MinValue;

            for (var i = 0; i < dp.Length; i++)
            {
                sum = Math.Max(dp[i], sum);
            }

            return sum;
        }
    }
}