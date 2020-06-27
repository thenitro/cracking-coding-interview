using System;

namespace CrackingCodingInterview.Hard
{
    public class Task1706
    {
        public Task1706()
        {
            Console.WriteLine(9 == Solution(25));
        }

        private int Solution(int number)
        {
            var count = 0;
            var len = number.ToString().Length;

            for (var digit = 0; digit < len; digit++)
            {
                Console.WriteLine(number + " " + digit + " " + Count2sInRangeAtDigit(number, digit));
                count += Count2sInRangeAtDigit(number, digit);
            }
            
            return count;
        }

        private int Count2sInRangeAtDigit(int number, int d)
        {
            var powerOf10 = Math.Pow(10, d);
            var nextPowerOf10 = powerOf10 * 10;
            var right = number % powerOf10;

            var roundDown = number - number % nextPowerOf10;
            var roundUp = roundDown + nextPowerOf10;

            var digit = (number / powerOf10) % 10;
            if (digit < 2)
            {
                return (int)roundDown / 10;
            } 
            else if (digit == 2)
            {
                return (int)(roundDown / 10 + right + 1);
            }
            else
            {
                return (int)roundUp / 10;
            }
        }
    }
}