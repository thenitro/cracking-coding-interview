using System;

namespace CrackingCodingInterview.RecursionAndDp
{
    public class Task83
    {
        public Task83()
        {
            var array = new int[] { -40, -20, -1, 1, 2, 3, 5, 7, 9, 12, 13 };
            
            Console.WriteLine(7 == Solution(array));
        }

        private int Solution(int[] array)
        {
            var start = 0;
            var end = array.Length;

            while (start < end)
            {
                var middle = start + (end - start) / 2;

                if (middle == array[middle])
                {
                    return middle;
                } 
                
                if (array[middle] > middle)
                {
                    end = middle;
                }
                else
                {
                    start = middle + 1;
                }
            }

            return -1;
        }
    }
}