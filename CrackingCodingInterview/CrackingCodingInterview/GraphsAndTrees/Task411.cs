using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.GraphsAndTrees
{
    public class Task411
    {
        public Task411()
        {
            var root = new BinaryTreeNode(1)
            {
                Left = new BinaryTreeNode(2)
                {
                    Left = new BinaryTreeNode(4),
                    Right = new BinaryTreeNode(5),
                },
                Right = new BinaryTreeNode(3)
                {
                    Left = new BinaryTreeNode(6),
                    Right = new BinaryTreeNode(7),
                },
            };

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Solution(root).Value);
            }
        }

        private BinaryTreeNode Solution(BinaryTreeNode root)
        {
            var queue = new Queue<BinaryTreeNode>();
                queue.Enqueue(root);
                
            var array = new List<BinaryTreeNode>();

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node == null)
                {
                    continue;
                }

                array.Add(node);
                
                queue.Enqueue(node.Left);
                queue.Enqueue(node.Right);
            }

            var rnd = new Random(DateTime.Now.Millisecond);
            return array[rnd.Next(0, array.Count)];
        }
    }
}