using System;

namespace CrackingCodingInterview.Moderate
{
    public class Task169
    {
        public Task169()
        {
            Console.WriteLine(5 == Minus(10, 5));
            Console.WriteLine(15 == Minus(10, -5));
            
            Console.WriteLine(12 == Multiply(3, 4));
            Console.WriteLine(-12 == Multiply(3, -4));
            Console.WriteLine(12 == Multiply(-3, -4));
            Console.WriteLine(0 == Multiply(1, 0));
            
            Console.WriteLine(4 == Divide(12, 3));
            Console.WriteLine(-4 == Divide(12, -3));
            Console.WriteLine(-4 == Divide(-12, 3));
            Console.WriteLine(4 == Divide(-12, -3));
        }

        private int Negate(int a)
        {
            var result = 0;
            var newSign = a > 0 ? 1 : -1;
            var delta = newSign;

            while (a != 0)
            {
                var diff = (a + delta > 0) != (a > 0);
                if (a + delta != 0 && diff)
                {
                    delta = newSign;
                }
                
                a += delta;
                result += delta;
                delta += delta;
            }

            return result;
        }

        private int Minus(int a, int b)
        {
            return a + Negate(b);
        }

        private int Multiply(int a, int b)
        {
            if (a < b)
            {
                return Multiply(b, a);
            }

            var sum = 0;

            for (var i = Abs(b); i > 0; i = Minus(i, 1))
            {
                sum += a;
            }

            if (b < 0)
            {
                sum = Negate(sum);
            }
            
            return sum;
        }

        private int Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(b));
            }

            var absA = Abs(a);
            var absB = Abs(b);

            var product = 0;
            var x = 0;

            while (product + absB <= absA)
            {
                product += absB;
                x++;
            }

            if ((a < 0 && b < 0) || (a > 0 && b > 0))
            {
                return x;
            }
            else
            {
                return Negate(x);
            }
        }

        private int Abs(int a)
        {
            if (a < 0)
            {
                return Negate(a);
            }

            return a;
        }
    }
}