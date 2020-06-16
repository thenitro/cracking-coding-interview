using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.Moderate
{
    public class Task1622
    {
        private int[][] Directions = new[]
        {
            new[] {0, 1},
            new[] {1, 0},
            new[] {0, -1},
            new[] {-1, 0},
        };
        
        public Task1622()
        {
            var result = Solution(100);

            for (var i = 0; i < result.GetLength(0); i++)
            {
                for (var j = 0; j < result.GetLength(1); j++)
                {
                    Console.Write(result[i, j].IsWhite + " ");
                }

                Console.WriteLine();
            }
        }

        private Node[,] Solution(int k)
        {
            var dict = new Dictionary<int, Dictionary<int, Node>>();
            
            var directionIndex = 1;
            var direction = Directions[directionIndex];
            
            var currentNode = GetNode(0, 0, dict);

            var minI = 0;
            var minJ = 0;

            var maxI = 0;
            var maxJ = 0;
            
            while (k > 0)
            {
                if (currentNode.IsWhite)
                {
                    directionIndex = ChangeDirection(directionIndex, 1);
                }
                else
                {
                    directionIndex = ChangeDirection(directionIndex, -1);
                }

                direction = Directions[directionIndex];
                currentNode.FlipColor();

                var newIndexI = currentNode.I + direction[0];
                var newIndexJ = currentNode.J + direction[1];

                minI = Math.Min(minI, newIndexI);
                minJ = Math.Min(minJ, newIndexJ);
                
                maxI = Math.Max(maxI, newIndexI);
                maxJ = Math.Max(maxJ, newIndexJ);

                currentNode = GetNode(newIndexI, newIndexJ, dict);

                Console.WriteLine(currentNode);
                
                k--;
            }

            var sizeI = maxI - minI;
            var sizeJ = maxJ - minJ;

            var diffI = Math.Max(minI * -1, 0);
            var diffJ = Math.Max(minJ * -1, 0);

            var result = new Node[sizeI, sizeJ];

            for (var i = minI; i < maxI; i++)
            {
                for (var j = minJ; j < maxJ; j++)
                {
                    var node = GetNode(i, j, dict);

                    result[i + diffI, j + diffJ] = node;
                }
            }

            return result;
        }

        private int ChangeDirection(int direction, int diff)
        {
            var newDirection = direction + diff;
            
            if (newDirection > 3)
            {
                newDirection = 0;
            }

            if (newDirection < 0)
            {
                newDirection = 3;
            }

            return newDirection;
        }

        private Node AddNode(Node node, Dictionary<int, Dictionary<int, Node>> dict)
        {
            if (HasNode(node.I, node.J, dict))
            {
                return dict[node.I][node.J];
            }

            if (!dict.ContainsKey(node.I))
            {
                dict.Add(node.I, new Dictionary<int, Node>());
            }

            dict[node.I].Add(node.J, node);

            return node;
        }

        private Node GetNode(int I, int J, Dictionary<int, Dictionary<int, Node>> dict)
        {
            if (HasNode(I, J, dict))
            {
                return dict[I][J];
            }

            return AddNode(new Node()
            {
                I = I,
                J = J,
                IsWhite = GenerateRandomColor()
            }, dict);
        }

        private bool HasNode(int I, int J, Dictionary<int, Dictionary<int, Node>> dict)
        {
            return dict.ContainsKey(I) && dict[I].ContainsKey(J);
        }
        
        private bool GenerateRandomColor()
        {
            return new Random().Next(0, 10) > 5;
        }
        
        private class Node
        {
            public int I;
            public int J;
            public bool IsWhite;

            public void FlipColor()
            {
                IsWhite = !IsWhite;
            }

            public override string ToString()
            {
                return $"[ Node i={I}, j={J}, c={IsWhite}]";
            }
        }
    }
}