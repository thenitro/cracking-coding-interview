using System;
using System.Collections.Generic;
using CrackingCodingInterview.LinkedLists;

namespace CrackingCodingInterview.GraphsAndTrees
{
    public class Task43
    {
        public Task43()
        {
            var root = new BinaryTreeNode(1)
            {
                Left = new BinaryTreeNode(2)
                {
                    Left = new BinaryTreeNode(4)
                },
                Right = new BinaryTreeNode(3)
                {
                    Right = new BinaryTreeNode(5)
                },
            };

            var result = Solution(root);

            foreach (var node in result)
            {
                var next = node;
                
                while (next != null)
                {
                    Console.Write(next.Value + " ");
                    next = next.Next;
                }

                Console.WriteLine();
            }
        }

        private List<Node> Solution(BinaryTreeNode root)
        {
            var queue = new Queue<BinaryTreeNode>();
                queue.Enqueue(root);

            var count = 1;
            
            var result = new List<Node>();

            while (queue.Count > 0)
            {
                var newCount = 0;
                Node head = null;
                
                for (var i = 0; i < count; i++)
                {
                    var tNode = queue.Dequeue();
                    
                    var llNode = new Node(tNode.Value);
                    if (head == null)
                    {
                        head = llNode;
                    }
                    else
                    {
                        head.Next = llNode;
                    }

                    if (tNode.Left != null)
                    {
                        newCount++;
                        queue.Enqueue(tNode.Left);
                    } 
                    
                    if (tNode.Right != null)
                    {
                        newCount++;
                        queue.Enqueue(tNode.Right);
                    } 
                }

                count = newCount;
                result.Add(head);
                head = null;
            }

            return result;
        }
    }
}