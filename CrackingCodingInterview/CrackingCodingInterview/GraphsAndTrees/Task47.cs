using System;
using System.Collections.Generic;
using System.Linq;

namespace CrackingCodingInterview.GraphsAndTrees
{
    public class Task47
    {
        public Task47()
        {
            Console.WriteLine(string.Join(", ", Solution(
                new []{ 'a', 'b', 'c', 'd', 'e', 'f' },
                new List<char[]>()
                {
                    new []{ 'd', 'a' },
                    new []{ 'b', 'f' },
                    new []{ 'd', 'b' },
                    new []{ 'a', 'f' },
                    new []{ 'c', 'd' },
                }
                )));
        }

        private char[] Solution(char[] projects, List<char[]> dependencies)
        {
            var graphOut = new Graph<char>();
                graphOut.Nodes = new Dictionary<char, List<char>>();
                
            var graphIn = new Graph<char>();
                graphIn.Nodes = new Dictionary<char, List<char>>();

            foreach (var character in projects)
            {
                graphOut.Nodes.Add(character, new List<char>());
                graphIn.Nodes.Add(character, new List<char>());
            }

            foreach (var project in dependencies)
            {
                graphOut.Nodes[project[0]].Add(project[1]);
                graphIn.Nodes[project[1]].Add(project[0]);
            }
            
            var queue = new Queue<char>();

            foreach (var graphNode in graphOut.Nodes)
            {
                if (graphNode.Value.Count == 0)
                {
                    queue.Enqueue(graphNode.Key);
                }
            }

            if (queue.Count == 0)
            {
                return null;
            }
            
            var visited = new HashSet<char>();

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (visited.Contains(node))
                {
                    continue;
                }

                visited.Add(node);

                foreach (var child in graphIn.Nodes[node])
                {
                    queue.Enqueue(child);
                }
            }

            return visited.ToArray();
        }
    }
}