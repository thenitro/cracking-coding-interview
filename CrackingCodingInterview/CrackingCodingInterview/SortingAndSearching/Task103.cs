using System;

namespace CrackingCodingInterview.SortingAndSearching
{
    public class Task103
    {
        public Task103()
        {
            Console.WriteLine(Solution(new int[] {15, 16, 19, 20, 25, 1, 3, 4, 5, 7, 10, 14}, 5));
            Console.WriteLine(Solution(new int[] { 11, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 11));
            Console.WriteLine(Solution(new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 1 }, 1));
        }

        private int Solution(int[] array, int value)
        {
            return Solution(array, value, 0, array.Length - 1);
        }

        private int Solution(int[] array, int value, int left, int right)
        {
            var mid = (left + right) / 2;

            if (array[mid] == value)
            {
                return mid;
            }

            if (right < left)
            {
                return -1;
            }

            if (array[left] < array[mid])
            {
                if (value >= array[left] && value < array[mid])
                {
                    return Solution(array, value, left, mid - 1);
                }
                else
                {
                    return Solution(array, value, mid + 1, right);
                }
            }
            else if (array[mid] < array[left])
            {
                if (value > array[mid] && value <= array[right])
                {
                    return Solution(array, value, mid + 1, right);
                }
                else
                {
                    return Solution(array, value, left, mid - 1);
                }
            }
            else if (array[left] == array[mid])
            {
                if (array[mid] != array[right])
                {
                    return Solution(array, value, mid + 1, right);
                }
                else
                {
                    var result = Solution(array, value, left, mid - 1);
                    if (result == -1)
                    {
                        return Solution(array, value, mid + 1, right);
                    }
                    else
                    {
                        return result;
                    }
                }
            }

            return -1;
        }
    }
}