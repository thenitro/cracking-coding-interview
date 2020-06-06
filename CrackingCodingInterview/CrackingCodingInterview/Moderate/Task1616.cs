using System;

namespace CrackingCodingInterview.Moderate
{
    public class Task1616
    {
        public Task1616()
        {
            Console.WriteLine(string.Join(",", Solution(new [] { 1, 2, 4, 7, 10, 11, 7, 12, 6, 7, 16, 18, 19 })));
            Console.WriteLine(string.Join(",", Solution(new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })));
            Console.WriteLine(string.Join(",", Solution(new [] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 })));
        }

        private int[] Solution(int[] array)
        {
            var leftSubarray = FindLeft(array);
            if (leftSubarray >= array.Length - 1)
            {
                return new[] {-1, -1};
            }

            var rightSubarray = FindRight(array);
            
            var midMin = int.MaxValue;
            var midMax = int.MinValue;

            for (var i = leftSubarray + 1; i < rightSubarray; i++)
            {
                midMin = Math.Min(midMin, array[i]);
                midMax = Math.Max(midMax, array[i]);
            }

            var leftIndex = FindLeftIndex(array, leftSubarray, midMin);
            var rightIndex = FindRightIndex(array, rightSubarray, midMax);
            
            return new [] { leftIndex, rightIndex };
        }

        private int FindLeft(int[] array)
        {
            for (var i = 1; i < array.Length; i++)
            {
                if (array[i] < array[i - 1])
                {
                    return i - 1;
                }
            }
            
            return array.Length - 1;
        }

        private int FindRight(int[] array)
        {
            for (var i = array.Length - 2; i >= 0; i--)
            {
                if (array[i] > array[i + 1])
                {
                    return i + 1;
                }
            }

            return 0;
        }

        private int FindLeftIndex(int[] array, int leftSubarray, int min)
        {
            for (var i = leftSubarray - 1; i >= 0; i--)
            {
                if (array[i] < min)
                {
                    return i + 1;
                }
            }

            return 0;
        }

        private int FindRightIndex(int[] array, int rigthSubarray, int max)
        {
            for (var i = rigthSubarray; i < array.Length; i++)
            {
                if (array[i] >= max)
                {
                    return i - 1;
                }
            }

            return array.Length - 1;
        }
    }
}