using System;
using System.Data.Odbc;

namespace CrackingCodingInterview.GraphsAndTrees
{
    public class Task46
    {
        public Task46()
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
            
            Console.WriteLine(left1 == Solution(left2));
            Console.WriteLine(left2Right == Solution(left1));
            Console.WriteLine(right2 == Solution(right1));
            Console.WriteLine(root == Solution(left2Right));
        }

        private BinaryTreeNode Solution(BinaryTreeNode node)
        {
            if (node.Right != null)
            {
                return LeftMostChild(node.Right);
            }
            
            var current = node;
            var parent = current.Parent;

            while (parent != null && parent.Left != current)
            {
                current = parent;
                parent = current.Parent;
            }

            return parent;
        }

        private BinaryTreeNode LeftMostChild(BinaryTreeNode node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }
    }
}