using System;
using System.Collections.Generic;
using System.Linq;

namespace CrackingCodingInterview.Hard
{
    public class Task1707
    {
        public Task1707()
        {
            var names = new Dictionary<string, int>()
            {
                {"John", 15},
                {"Jon", 12},
                {"Chris", 13},
                {"Kris", 4},
                {"Christopher", 19},
            };

            var synonyms = new[]
            {
                new[] { "Jon", "John" },
                new[] { "John", "Johnny" },
                new[] { "Chris", "Kris" },
                new[] { "Chris", "Christopher" },
            };

            var result = Solution(names, synonyms);

            foreach (var kv in result)
            {
                Console.WriteLine($"{kv.Key} = {kv.Value}");
            }
        }

        private Dictionary<string, int> Solution(Dictionary<string, int> names, string[][] synonyms)
        {
            var graph = ConstructGraph(names);
            ConnectEdges(graph, synonyms);

            return GetTrueFrequencies(graph);
        }

        private Graph ConstructGraph(Dictionary<string, int> names)
        {
            var graph = new Graph();

            foreach (var entry in names)
            {
                graph.CreateNode(entry.Key, entry.Value);
            }

            return graph;
        }

        private void ConnectEdges(Graph graph, string[][] synonyms)
        {
            foreach (var synonym in synonyms)
            {
                graph.AddEdge(synonym[0], synonym[1]);
            }
        }

        private Dictionary<string, int> GetTrueFrequencies(Graph graph)
        {
            var rootNames = new Dictionary<string, int>();

            foreach (var node in graph.GetNodes())
            {
                if (node.IsVisited)
                {
                    continue;
                }


                rootNames.Add(node.Name, GetComponentFrequency(graph, node));
            }
            
            return rootNames;
        }

        private int GetComponentFrequency(Graph graph, GraphNode node)
        {
            if (node.IsVisited)
            {
                return 0;
            }

            node.IsVisited = true;
            
            var sum = node.Count;

            foreach (var neighbor in graph.GetNeighbors(node))
            {
                sum += GetComponentFrequency(graph, neighbor);
            }

            return sum;
        }

        private class Graph
        {
            private Dictionary<string, GraphNode> _nodes;
            private Dictionary<GraphNode, HashSet<GraphNode>> _neighbors;
            
            public Graph()
            {
                _nodes = new Dictionary<string, GraphNode>();
                _neighbors = new Dictionary<GraphNode, HashSet<GraphNode>>();
            }

            public GraphNode[] GetNodes()
            {
                return _nodes.Values.ToArray();
            }

            public void CreateNode(string name, int count)
            {
                _nodes[name] = new GraphNode(name, count);
            }

            public void AddEdge(string name1, string name2)
            {
                if (!_nodes.ContainsKey(name1))
                {
                    _nodes.Add(name1, new GraphNode(name1, 0));
                }
                
                if (!_nodes.ContainsKey(name2))
                {
                    _nodes.Add(name2, new GraphNode(name2, 0));
                }
                
                var node1 = _nodes[name1];
                var node2 = _nodes[name2];
                
                AddNeighbor(node1, node2);
                AddNeighbor(node2, node1);
            }

            private void AddNeighbor(GraphNode node1, GraphNode node2)
            {
                if (!_neighbors.ContainsKey(node1))
                {
                    _neighbors.Add(node1, new HashSet<GraphNode>());
                }

                if (_neighbors[node1].Contains(node2))
                {
                    return;
                }
                
                _neighbors[node1].Add(node2);
            }

            public GraphNode[] GetNeighbors(GraphNode node)
            {
                return _neighbors[node].ToArray();
            }
        }
        
        public class GraphNode
        {
            public string Name { get; }
            public int Count { get; }

            public bool IsVisited;
                
            public GraphNode(string name, int count)
            {
                Name = name;
                Count = count;
            }
        }
    }
}