using System;

namespace CrackingCodingInterview.BitManipulation
{
    public class Task56
    {
        public Task56()
        {
            Console.WriteLine(2 == Solution(0b_0001_1101, 0b_0000_1111));
        }

        private int Solution(int a, int b)
        {
            var xor = a ^ b;

            Console.WriteLine(Convert.ToString(xor, 2));

            return PopCount(xor);
        }

        private int PopCount(int N)
        {
            var count = 0;

            while (N > 0)
            {
                N &= N - 1;
                count++;
            }

            return count;
        }
    }
}