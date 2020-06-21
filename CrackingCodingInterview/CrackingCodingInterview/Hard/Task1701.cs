using System;

namespace CrackingCodingInterview.Hard
{
    public class Task1701
    {
        public Task1701() 
        {
            Console.WriteLine(4 == Add(2, 2));
            Console.WriteLine(2 == Add(4, -2));
        }

        private int Add(int a, int b)
        {
            while (b != 0)
            {
                var sum = a ^ b;
                var carry = (a & b) << 1;

                a = sum;
                b = carry;
            }

            return a;
        }
    }
}