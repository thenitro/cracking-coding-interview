using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CrackingCodingInterview.GraphsAndTrees
{
    public class Task48
    {
        public Task48()
        {
            var root = new BinaryTreeNode(1);
            
            var left1 = new BinaryTreeNode(2)
            {
                Parent = root
            };
            
            var left2 = new BinaryTreeNode(3)
            {
                Parent = left1
            };
            
            var left2Right = new BinaryTreeNode(6)
            {
                Parent = left1
            };

            left1.Left = left2;
            left1.Right = left2Right;
            
            var right1 = new BinaryTreeNode(4)
            {
                Parent = root
            };
            
            var right2Left = new BinaryTreeNode(7)
            {
                Parent = right1
            };
            
            var right2 = new BinaryTreeNode(5)
            {
                Parent = right1
            };

            right1.Left = right2Left;
            right1.Right = right2;
            
            root.Left = left1;
            root.Right = right1;

            Console.WriteLine(left1 == Solution(root, left2, left2Right));
            Console.WriteLine(root == Solution(root, left2, right2));
        }

        private BinaryTreeNode Solution(BinaryTreeNode root, BinaryTreeNode node1, BinaryTreeNode node2)
        {
            var queue = new Queue<BinaryTreeNode>();
                queue.Enqueue(root);

            var prev = root;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (!IsAncestor(node1, node) || 
                    !IsAncestor(node2, node))
                {
                    break;
                }

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }
                
                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }

                prev = node;
            }

            return prev;
        }

        private bool IsAncestor(BinaryTreeNode node, BinaryTreeNode root)
        {
            var queue = new Queue<BinaryTreeNode>();
                queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current == node)
                {
                    return true;
                }

                if (current.Left != null)
                {
                    queue.Enqueue(current.Left);
                }

                if (current.Right != null)
                {
                    queue.Enqueue(current.Right);
                }
            }

            return false;
        }
    }
}