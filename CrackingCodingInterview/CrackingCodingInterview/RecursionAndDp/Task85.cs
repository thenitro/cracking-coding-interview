using System;

namespace CrackingCodingInterview.RecursionAndDp
{
    public class Task85
    {
        public Task85()
        {
            Console.WriteLine(25 == Solution(5, 5));
        }

        private int Solution(int a, int b)
        {
            var bigger = a < b ? b : a;
            var smaller = a < b ? a : b;

            var memo = new int[smaller + 1];

            return SolutionHelper(smaller, bigger, memo);
        }
        
        private int SolutionHelper(int smaller, int bigger, int[] memo)
        {
            if (smaller == 0)
            {
                return 0;
            } 
            else if (smaller == 1)
            {
                return bigger;
            }
            else if (memo[smaller] > 0)
            {
                return memo[smaller];
            }

            var s = smaller >> 1;

            var side1 = SolutionHelper(s, bigger, memo);
            var side2 = side1;

            if (smaller % 2 == 1)
            {
                side2 = SolutionHelper(smaller - s, bigger, memo);
            }

            memo[smaller] = side1 + side2;
            return memo[smaller];
        }
    }
}