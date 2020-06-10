using System;
using System.Linq;

namespace CrackingCodingInterview.Moderate
{
    public class Task1621
    {
        public Task1621()
        {
            Console.WriteLine(string.Join(",", Solution(new [] { 4, 1, 2, 1, 1, 2 }, new [] { 3, 6, 3, 3 })));
        }

        private int[] Solution(int[] arrayA, int[] arrayB)
        {
            var sumA = arrayA.Sum();
            var sumB = arrayB.Sum();

            var diff = Math.Abs(sumB - sumA);
            if (diff == 0)
            {
                return new int[0];
            }

            for (var i = 0; i < arrayA.Length; i++)
            {
                for (var j = 0; j < arrayB.Length; j++)
                {
                    var a = arrayA[i];
                    var b = arrayB[j];

                    var newSumA = sumA - a + b;
                    var newSumB = sumB - b + a;

                    if (newSumA == newSumB)
                    {
                        return new[] {a, b};
                    }
                }
            }
            
            return null;
        }
    }
}