using System;

namespace CrackingCodingInterview.BitManipulation
{
    public class Task51
    {
        public Task51()
        {
            Console.WriteLine(Convert.ToString(Solution(0b0100_0000_0000, 0b0000_0001_0011, 2, 6), 2));
        }

        public int Solution(int N, int M, int i, int j)
        {
            Console.WriteLine(Convert.ToString(N, 2) + " " + Convert.ToString(M, 2));

            var allOnes = ~0;

            Console.WriteLine(Convert.ToString(allOnes, 2));

            var left = allOnes << (j + 1);
            
            Console.WriteLine("left " + Convert.ToString(left, 2));
            
            var right = ((1 << i) - 1);
            
            Console.WriteLine("right " + Convert.ToString(right, 2));

            var mask = left | right;
            
            Console.WriteLine(Convert.ToString(mask, 2));

            var nCleared = N & mask;
            
            Console.WriteLine(Convert.ToString(nCleared, 2));

            var mShifted = M << i;
            
            Console.WriteLine(Convert.ToString(mShifted, 2));

            var result = nCleared | mShifted;
            
            Console.WriteLine(Convert.ToString(result, 2));
            
            return result;
        }
    }
}