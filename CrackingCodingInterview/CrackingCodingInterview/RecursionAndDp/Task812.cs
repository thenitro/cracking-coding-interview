using System;
using System.Collections.Generic;
using Microsoft.SqlServer.Server;

namespace CrackingCodingInterview.RecursionAndDp
{
    public class Task812
    {
        private const int GRID_SIZE = 8;
        
        public Task812()
        {
            var result = Solution();

            for (var i = 0; i < result.GetLength(0); i++)
            {
                for (var j = 0; j < result.GetLength(1); j++)
                {
                    Console.Write(result[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private int[,] Solution()
        {
            var board = new int[GRID_SIZE, GRID_SIZE];

            SolutionHelper(board, 0);

            return board;
        }

        private bool SolutionHelper(int[,] board, int col)
        {
            if (col >= GRID_SIZE)
            {
                return true;
            }

            for (var i = 0; i < GRID_SIZE; i++)
            {
                if (IsValid(board, i, col))
                {
                    board[i, col] = 1;

                    if (SolutionHelper(board, col + 1) == true)
                    {
                        return true;
                    }

                    board[i, col] = 0;
                }
            }

            return false;
        }

        private bool IsValid(int[,] board, int row, int col)
        {
            var i = 0;
            var j = 0;
            
            for (i = 0; i < col; i++)
            {
                if (board[row, i] == 1)
                {
                    return false;
                }
            }

            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == 1)
                {
                    return false;
                }
            }

            for (i = row, j = col; i < GRID_SIZE && j >= 0; i++, j--)
            {
                if (board[i, j] == 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}