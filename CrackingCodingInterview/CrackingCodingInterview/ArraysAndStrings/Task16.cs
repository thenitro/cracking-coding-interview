using System;
using System.Text;

namespace Algorithms.RandomTests.CrackingCodingInterview
{
    public class Task16
    {
        public Task16()
        {
            Console.WriteLine("a2b1c5a3" == Solution("aabcccccaaa"));
        }

        private string Solution(string str)
        {
            var result = new StringBuilder();
            
            for (var i = 0; i < str.Length; i++)
            {
                var count = 1;
                
                result.Append(str[i]);
                
                while (i < str.Length - 1 && str[i] == str[i + 1])
                {
                    count++;
                    i++;
                }

                result.Append(count);
            }

            return result.ToString();
        }
    }
}