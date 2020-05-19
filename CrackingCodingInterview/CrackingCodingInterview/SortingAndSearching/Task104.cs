using System;

namespace CrackingCodingInterview.SortingAndSearching
{
    public class Task104
    {
        public Task104()
        {
            var input = new int[] {1, 2, 3, 4, 5, 6, -1, -1, -1, -1};
            var input1 = new int[] {1, -1, -1, -1, -1};
            
            Console.WriteLine(5 == Solution(input, 6));
            Console.WriteLine(0 == Solution(input1, 1));
            Console.WriteLine(-1 == Solution(input1, 2));
        }

        private int Solution(int[] array, int value)
        {
            var length = FindLength(array);

            var lo = 0;
            var hi = length;

            while (lo <= hi)
            {
                var mid = (lo + hi) / 2;
                var middle = array[mid];
                
                if (middle > value || middle == -1)
                {
                    hi = mid - 1;
                } 
                else if (middle < value)
                {
                    lo = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }

        private int FindLength(int[] array)
        {
            var index = 1;

            while (array[index] != -1)
            {
                index *= 2;
            }

            return index;
        }
    }
}