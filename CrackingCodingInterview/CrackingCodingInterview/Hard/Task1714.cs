using System;
using System.Collections.Concurrent;
using System.Xml;

namespace CrackingCodingInterview.Hard
{
    public class Task1714
    {
        public Task1714()
        {
            Console.WriteLine(string.Join(",", Solution(new[] {1, 8, 3, 4, 5, 9, 2, 3, 4, 5, 6, 7}, 4)));
        }

        private int[] Solution(int[] array, int k)
        {
            if (k <= 0 || k > array.Length)
            {
                return null;
            }

            var threshold = Rank(array, k - 1);
            var smallest = new int[k];
            var count = 0;

            foreach (var a in array)
            {
                if (a < threshold)
                {
                    smallest[count] = a;
                    count++;
                }
            }

            while (count < k)
            {
                smallest[count] = threshold;
                count++;
            }

            return smallest;
        }

        private int Rank(int[] array, int k)
        {
            return Rank(array, k, 0, array.Length - 1);
        }

        private int Rank(int[] array, int k, int start, int end)
        {
            var pivot = array[new Random().Next(start, end)];
            var partition = Partition(array, start, end, pivot);
            var leftSize = partition.LeftSize;
            var middleSize = partition.MiddleSize;

            if (k < leftSize)
            {
                return Rank(array, k, start, start + leftSize - 1);
            } 
            else if (k < leftSize + middleSize)
            {
                return pivot;
            }
            else
            {
                return Rank(array, k - leftSize - middleSize, start + leftSize + middleSize, end);
            }
        }

        private PartitionResult Partition(int[] array, int start, int end, int pivot)
        {
            var left = start;
            var right = end;
            var middle = start;

            while (middle <= right)
            {
                if (array[middle] < pivot)
                {
                    Swap(array, middle, left);
                    middle++;
                    left++;
                } 
                else if (array[middle] > pivot)
                {
                    Swap(array, middle, right);
                    right--;
                } 
                else if (array[middle] == pivot)
                {
                    middle++;
                }
            }
            
            return new PartitionResult(left - start, right - left + 1);
        }

        private void Swap(int[] array, int a, int b)
        {
            var tmp = array[a];
            array[a] = array[b];
            array[b] = tmp;
        }

        private class PartitionResult
        {
            public int LeftSize;
            public int MiddleSize;

            public PartitionResult(int left, int middle)
            {
                LeftSize = left;
                MiddleSize = middle;
            }
        }
    }
}