using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.Moderate
{
    public class Task1619
    {
        public Task1619()
        {
            Console.WriteLine(string.Join(",", Solution(new int[,]
            {
                { 0, 2, 1, 0 },
                { 0, 1, 0, 1 },
                { 1, 1, 0, 1 },
                { 0, 1, 0, 1 }
            })));
        }

        private List<int> Solution(int[,] plot)
        {
            var result = new List<int>();
            var visited = new bool[plot.Length, plot.Length];

            for (var i = 0; i < plot.GetLength(0); i++)
            {
                for (var j = 0; j < plot.GetLength(1); j++)
                {
                    if (visited[i, j])
                    {
                        continue;
                    }

                    visited[i, j] = true;

                    if (plot[i, j] != 0)
                    {
                        continue;
                    }

                    result.Add(Bfs(plot, i, j, visited));
                }
            }
            
            return result;
        }

        private int Bfs(int[,] plot, int i, int j, bool[,] visited)
        {
            var queue = new Queue<Tuple<int, int>>();
                queue.Enqueue(new Tuple<int, int>(i, j));

            var count = 0;
                
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                count++;

                for (var n = Math.Max(0, node.Item1 - 1); n < Math.Min(node.Item1 + 2, plot.GetLength(0)); n++)
                {
                    for (var m = Math.Max(0, node.Item2 - 1); m < Math.Min(node.Item2 + 2, plot.GetLength(1)); m++)
                    {
                        if (visited[n, m])
                        {
                            continue;
                        }

                        if (plot[n, m] != 0)
                        {
                            continue;
                        }
                        
                        queue.Enqueue(new Tuple<int, int>(n, m));
                        visited[n, m] = true;
                    }
                }
            }

            return count;
        }
    }
}