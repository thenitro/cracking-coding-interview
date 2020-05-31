using System;

namespace CrackingCodingInterview.Moderate
{
    public class Task167
    {
        public Task167()
        {
            Console.WriteLine(10 == Solution(1, 10));
            Console.WriteLine(-1 == Solution(-1, -3));
        }
        
        private int Solution(int a, int b)
        {
            var c = a - b;

            var sa = Sign(a);
            var sb = Sign(b);
            var sc = Sign(c);

            var useSignOfA = sa ^ sb;
            var useSignOfC = Flip(sa ^ sb);

            var k = useSignOfA * sa + useSignOfC * sc;
            var q = Flip(k);

            return a * k + b * q;
        }

        private int Sign(int a)
        {
            return Flip((a >> 31) & 0x1);
        }

        private int Flip(int a)
        {
            return 1 ^ a;
        }
    }
}