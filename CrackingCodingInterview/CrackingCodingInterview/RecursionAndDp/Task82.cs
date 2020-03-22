using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.RecursionAndDp
{
    public class Task82
    {
        public Task82()
        {
            var grid = new []
            {
                new [] {0, 1, 0},
                new [] {0, 1, 0},
                new [] {0, 0, 0},
            };

            var path = Solution(grid);

            foreach (var tuple in path)
            {
                Console.WriteLine(tuple.Item1 + " " + tuple.Item2);
            }
        }

        private List<Tuple<int, int>> Solution(int[][] grid)
        {
            var result = new List<Tuple<int, int>>();
            
            var targetX = grid.Length - 1;
            var targetY = grid[0].Length - 1;

            SolutionHelper(grid, targetX, targetY, result, new List<Tuple<int, int>>(), 0, 0);

            return result;
        }

        private void SolutionHelper(int[][] grid, int targetX, int targetY, List<Tuple<int, int>> result, List<Tuple<int, int>> tmp, int x, int y)
        {
            if (x == targetX && y == targetY)
            {
                result.Clear();
                
                foreach (var tuple in tmp)
                {
                    result.Add(tuple);
                }
                
                return;
            }

            if (x > targetX || y > targetY)
            {
                return;
            }
            
            if (grid[x][y] == 1)
            {
                return;
            }
            
            tmp.Add(new Tuple<int, int>(x + 1, y));
            SolutionHelper(grid, targetX, targetY, result, tmp, x + 1, y);
            tmp.RemoveAt(tmp.Count - 1);
            
            tmp.Add(new Tuple<int, int>(x, y + 1));
            SolutionHelper(grid, targetX, targetY, result, tmp, x, y + 1);
            tmp.RemoveAt(tmp.Count - 1);
        }
    }
}