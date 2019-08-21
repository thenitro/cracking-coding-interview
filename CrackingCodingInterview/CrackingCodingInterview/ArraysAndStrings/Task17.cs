using System;

namespace Algorithms.RandomTests.CrackingCodingInterview
{
    public class Task17
    {
        public Task17()
        {
            var matrixSize = 4;
            
            var matrix = new int[matrixSize,matrixSize];
            var count = 0;

            for (var i = 0; i < matrixSize; i++)
            {
                for (var j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = count;
                    count++;
                }
            }
            
            Solve(matrix, matrixSize);

            for (var i = 0; i < matrixSize; i++)
            {
                for (var j = 0; j < matrixSize; j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                
                Console.WriteLine();
            }
        }

        private void Solve(int[,] input, int matrixSize)
        {
            var level = 0;
            var last = matrixSize - 1;
            var amountOfLevels = matrixSize / 2;
            
            while (level < amountOfLevels)
            {
                for (int i = level; i < last; i++)
                {
                    Swap(level, i, i, last, input);
                    Swap(level, i, last, last - i + level, input);
                    Swap(level, i, last - i + level, level, input);
                }

                level++;
                last--;
            }
        }

        private void Swap(int si, int sj, int di, int dj, int[,] matrix)
        {
            var tmp = matrix[si, sj];
            
            matrix[si, sj] = matrix[di, dj];
            matrix[di, dj] = tmp;
        }
    }
}