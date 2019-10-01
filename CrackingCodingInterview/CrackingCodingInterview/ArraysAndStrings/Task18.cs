using System;
using System.Collections.Generic;

namespace Algorithms.RandomTests.CrackingCodingInterview
{
    public class Task18
    {
        public Task18()
        {
            var matrixSize = 5;
            
            var matrix = new int[matrixSize, matrixSize];
            var count = 1;
            
            for (int i = 0; i < matrixSize; i++)
            {
                for (var j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = count;
                    count++;
                }
            }

            matrix[2, 2] = 0;

            Console.WriteLine("Before");
            PrintMatrix(matrix, matrixSize);

            Solve(matrix, matrixSize);
            
            Console.WriteLine("After");
            PrintMatrix(matrix, matrixSize);
        }

        private void Solve(int[,] matrix, int matrixSize)
        {
            var zeroIndexes = new List<Tuple<int, int>>();

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        zeroIndexes.Add(new Tuple<int, int>(i, j));
                    }
                }
            }
            
            var updateIndexes = new List<Tuple<int, int>>();

            foreach (var index in zeroIndexes)
            {
                for (var i = 0; i < matrixSize; i++)
                {
                    updateIndexes.Add(new Tuple<int, int>(i, index.Item2));
                }
                
                for (var i = 0; i < matrixSize; i++)
                {
                    updateIndexes.Add(new Tuple<int, int>(index.Item1, i));
                }
            }

            foreach (var index in updateIndexes)
            {
                matrix[index.Item1, index.Item2] = 0;
            }
        }

        private void PrintMatrix(int[,] matrix, int matrixSize)
        {
            for (var i = 0; i < matrixSize; i++)
            {
                for (var j = 0; j < matrixSize; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}