using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.GraphsAndTrees
{
    public class Task41
    {
        public Task41()
        {
            var graph = new Graph<int>()
            {
                Nodes = new Dictionary<int, List<int>>()
                {
                    { 1, new List<int>() { 2, 3 } },
                    { 4, new List<int>() { 2, 3 } }
                }
            };

            Console.WriteLine(true == Solve(graph, 1, 3));
            Console.WriteLine(false == Solve(graph, 1, 4));
        }

        private bool Solve(Graph<int> graph, int start, int finish)
        {
            var visited = new HashSet<int>();
            
            var toVisit = new Queue<int>();
                toVisit.Enqueue(start);

            while (toVisit.Count > 0)
            {
                var node = toVisit.Dequeue();
                if (node == finish)
                {
                    return true;
                }
                
                if (visited.Contains(node))
                {
                    continue;
                }
                
                visited.Add(node);

                if (!graph.Nodes.ContainsKey(node))
                {
                    continue;
                }

                foreach (var childNode in graph.Nodes[node])
                {
                    toVisit.Enqueue(childNode);
                }
            }

            return false;
        }
    }
}