using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.RecursionAndDp
{
    public class Task810
    {
        public Task810()
        {
            var grid = new int[,]
            {
                { 1, 1, 1, 1, 1 },
                { 1, 3, 3, 3, 1 },
                { 1, 3, 5, 3, 1 },
                { 1, 3, 3, 3, 1 },
                { 1, 1, 1, 1, 1 },
            };

            Solution(grid, 2, 2, 3);

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i, j]);
                }

                Console.WriteLine();
            }
            
            Solution(grid, 2, 2, 5);
            
            
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i, j]);
                }

                Console.WriteLine();
            }
        }
        
        private void Solution(int[,] grid, int x, int y, int newColor)
        {
            if (grid == null || 
                grid.GetLength(0) == 0 || 
                grid.GetLength(1) == 0 || 
                !IsCoordsValid(grid, x, y))
            {
                return;
            }

            var oldColor = grid[x, y];
            
            var queue = new Queue<Tuple<int,int>>();
                queue.Enqueue(new Tuple<int, int>(x, y));

            while (queue.Count > 0)
            {
                var coords = queue.Dequeue();

                if (grid[coords.Item1, coords.Item2] != oldColor)
                {
                    continue;
                }
                
                grid[coords.Item1, coords.Item2] = newColor;

                AddToQueue(queue, grid, coords.Item1 - 1, coords.Item2);
                AddToQueue(queue, grid, coords.Item1 + 1, coords.Item2);
                AddToQueue(queue, grid, coords.Item1, coords.Item2 - 1);
                AddToQueue(queue, grid, coords.Item1, coords.Item2 + 1);
            }
        }

        private void AddToQueue(Queue<Tuple<int, int>> queue, int[,] grid, int x, int y)
        {
            if (!IsCoordsValid(grid, x, y))
            {
                return;
            }
            
            queue.Enqueue(new Tuple<int, int>(x, y));
        }

        private bool IsCoordsValid(int[,] grid, int x, int y)
        {
            return x >= 0 && x < grid.GetLength(0) &&
                   y >= 0 && y < grid.GetLength(1);
        }
    }
}