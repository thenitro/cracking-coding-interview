using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.GraphsAndTrees
{
    public class Task42
    {
        public Task42()
        {
            var tree = Solve(new [] { 1, 2, 3, 4, 5, 6, 7 });

            var queue = new Queue<BinaryTreeNode>();
                queue.Enqueue(tree);
                
            var counter = 1;

            while (queue.Count > 0)
            {
                var newCounter = 0;
                
                for (var i = 0; i < counter; i++)
                {
                    var node = queue.Dequeue();

                    Console.Write(node.Value);
                    
                    if (node.Left != null)
                    {
                        newCounter++;
                        queue.Enqueue(node.Left);
                    }
                    
                    if (node.Right != null)
                    {
                        newCounter++;
                        queue.Enqueue(node.Right);
                    }
                }

                Console.WriteLine();
                counter = newCounter;
            }
        }

        private BinaryTreeNode Solve(int[] array)
        {
            return TakeMiddle(array, 0, array.Length);
        }

        private BinaryTreeNode TakeMiddle(int[] array, int start, int end)
        {
            if (start == end)
            {
                return null;
            }
            
            var middle = start + (end - start) / 2;
            if (middle < 0 || middle >= array.Length)
            {
                return null;
            }

            var node = new BinaryTreeNode();
                node.Value = array[middle];
                node.Left = TakeMiddle(array, start, middle);
                node.Right = TakeMiddle(array, middle + 1, end);

            return node;
        }
    }
}