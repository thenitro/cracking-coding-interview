using System;

namespace CrackingCodingInterview.Hard
{
    public class Task1703
    {
        public Task1703()
        {
            Console.WriteLine(string.Join(",", Solution(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9}, 4)));
        }

        private int[] Solution(int[] array, int m)
        {
            var result = new int[m];
            
            for (var i = 0; i < m; i++)
            {
                result[i] = array[i];
            }

            for (var i = m; i < array.Length; i++)
            {
                var k = new Random().Next(i);
                if (k < m)
                {
                    result[k] = array[i];
                }
            }

            return result;
        }
    }
}