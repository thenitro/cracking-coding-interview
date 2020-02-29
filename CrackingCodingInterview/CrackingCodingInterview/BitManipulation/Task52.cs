using System;
using System.Text;

namespace CrackingCodingInterview.BitManipulation
{
    public class Task52
    {
        public Task52()
        {
            Console.WriteLine(Solve(0.72));
        }

        private string Solve(double number)
        {
            if (number >= 1 || number <= 0)
            {
                return "ERROR";
            }

            var binary = new StringBuilder();
                binary.Append(".");

            while (number > 0)
            {
                if (binary.Length >= 32)
                {
                    return "ERROR";
                }

                var r = number * 2;
                
                Console.WriteLine(r + " " + number);

                if (r >= 1)
                {
                    binary.Append(1);
                    number = r - 1;
                }
                else
                {
                    binary.Append(0);
                    number = r;
                }
            }

            return binary.ToString();
        }
    }
}