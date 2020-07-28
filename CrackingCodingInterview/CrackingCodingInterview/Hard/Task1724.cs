using System;

namespace CrackingCodingInterview.Hard
{
    public class Task1724
    {
        public Task1724()
        {
            var matrix = new[,]
            {
                {2, 3, 4, -2, -1},
                {1, 6, 5, -6, -4},
                {1, -10, 1, -6, -4},
                {-1, -10, 10, 12, 13},
                {-1, -10, 14, -6, 20},
            };

            var submatrix = Solution(matrix);

            Console.WriteLine($"{submatrix.Row1} {submatrix.Row2} {submatrix.Col1} {submatrix.Col2} {submatrix.Sum}");
        }

        private Submatrix Solution(int[,] matrix)
        {
            var rowCount = matrix.GetLength(0);
            var colCount = matrix.GetLength(1);
            Submatrix best = null;

            for (var rowStart = 0; rowStart < rowCount; rowStart++)
            {
                var partialSum = new int[colCount];

                for (var rowEnd = rowStart; rowEnd < rowCount; rowEnd++)
                {
                    for (var i = 0; i < colCount; i++)
                    {
                        partialSum[i] += matrix[rowEnd, i];
                    }

                    var bestRange = MaxSubarray(partialSum, colCount);
                    if (best == null || best.Sum < bestRange.Sum)
                    {
                        best = new Submatrix(rowStart, bestRange.Start, rowEnd, bestRange.End, bestRange.Sum);
                    }
                }
            }

            return best;
        }

        private Range MaxSubarray(int[] array, int N)
        {
            Range best = null;

            var start = 0;
            var sum = 0;

            for (var i = 0; i < N; i++)
            {
                sum += array[i];

                if (best == null || sum > best.Sum)
                {
                    best = new Range(start, i, sum);
                }

                if (sum < 0)
                {
                    start = i + 1;
                    sum = 0;
                }
            }
            
            return best;
        }

        private class Range
        {
            public int Start;
            public int End;
            public int Sum;

            public Range(int start, int end, int sum)
            {
                Start = start;
                End = end;
                Sum = sum;
            }
        }

        private class Submatrix
        {
            public int Row1;
            public int Row2;
            public int Col1;
            public int Col2;
            public int Sum;

            public Submatrix(int row1, int row2, int col1, int col2, int sum)
            {
                Row1 = row1;
                Row2 = row2;
                Col1 = col1;
                Col2 = col2;
                Sum = sum;
            }
        }
    }
}