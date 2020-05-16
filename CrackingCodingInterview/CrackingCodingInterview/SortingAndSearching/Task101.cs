using System;

namespace CrackingCodingInterview.SortingAndSearching
{
    public class Task101
    {
        public Task101()
        {
            var A = new int[10] {0, 3, 4, 6, 8, -1, -1, -1, -1, -1};
            var B = new int[5] {1, 2, 5, 7, 9};

            Console.WriteLine(string.Join(",", Solution(A, B)));
            
            var A1 = new int[10] {1, 2, 5, 7, 9, -1, -1, -1, -1, -1};
            var B1 = new int[5] {0, 3, 4, 6, 8};

            Console.WriteLine(string.Join(",", Solution(A1, B1)));
        }

        private int[] Solution(int[] A, int[] B)
        {
            var i = 0;
            var j = 0;

            if (A[i] > B[j])
            {
                MoveToRight(i, A);
                A[i] = B[j];
                j++;
            }

            while (i < A.Length && j < B.Length)
            {
                if (A[i] < B[j] && (A[i + 1] > B[j] || A[i + 1] == -1))
                {
                    MoveToRight(i + 1, A);
                    A[i + 1] = B[j];
                    i++;
                    j++;
                }
                else
                {
                    i++;
                }
            }

            return A;
        }

        private void MoveToRight(int index, int[] array)
        {
            for (var i = array.Length - 1; i >= index + 1; i--)
            {
                array[i] = array[i - 1];
            }
        }
    }
}