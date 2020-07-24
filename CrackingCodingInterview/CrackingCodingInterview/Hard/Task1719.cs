using System;
using System.Linq;

namespace CrackingCodingInterview.Hard
{
    public class Task1719
    {
        public Task1719()
        {
            Console.WriteLine(26 == Solution(new [] { 0, 0, 4, 0, 0, 6, 0, 0, 3, 0, 5, 0, 1, 0, 0, 0 }));
        }

        private int Solution(int[] array)
        {
            var maxHeight = array.Max();
            var histogram = new int[maxHeight, array.Length];
            var result = 0;

            for (var i = 0; i < array.Length; i++)
            {
                for (var j = maxHeight - 1; j > maxHeight - array[i] - 1; j--)
                {
                    histogram[j, i] = 1;
                }
            }
            
            for (var j = 0; j < maxHeight; j++)
            {
                var start = -1;
                var end = -1;
                
                for (var i = 0; i < array.Length; i++)
                {
                    if (histogram[j, i] == 1 && start == -1)
                    {
                        start = i;
                    } 
                    else if (histogram[j, i] == 1)
                    {
                        end = i;
                    }
                }
                
                if (start != -1 && end != -1)
                {
                    for (var k = start; k < end; k++)
                    {
                        if (histogram[j, k] == 0)
                        {
                            result++;
                        }
                    }
                }
            }
            
            return result;
        }
    }
}