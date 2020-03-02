using System;

namespace CrackingCodingInterview.BitManipulation
{
    public class Task54
    {
        public Task54()
        {
            Console.WriteLine(NextSmaller(50));
            Console.WriteLine(NextBigger(50));
        }

        private int NextSmaller(int N)
        {
            var amountOfBits = PopCount(N);
            
            for (var i = N - 1; i > 0; i--)
            {
                if (PopCount(i) == amountOfBits)
                {
                    return i;
                }
            }

            return -1;
        }
        
        private int NextBigger(int N)
        {
            var amountOfBits = PopCount(N);
            
            for (var i = N + 1; i < int.MaxValue; i++)
            {
                if (PopCount(i) == amountOfBits)
                {
                    return i;
                }
            }

            return -1;
        }

        private int PopCount(int n)
        {
            var count = 0;
            
            while (n > 0)
            {
                n &= n - 1;
                count++;
            }

            return count;
        }
    }
}