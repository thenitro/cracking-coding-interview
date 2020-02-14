using System;

namespace CrackingCodingInterview.GraphsAndTrees
{
    public class Task44
    {
        public Task44()
        {
            var balanced = new BinaryTreeNode(1)
            {
                Left = new BinaryTreeNode(2)
                {
                    Left = new BinaryTreeNode(4),
                    Right = new BinaryTreeNode(6)
                },
                Right = new BinaryTreeNode(3)
                {
                    Left = new BinaryTreeNode(7),
                    Right = new BinaryTreeNode(5)
                }
            };
            
            var balanced2 = new BinaryTreeNode(1)
            {
                Left = new BinaryTreeNode(2)
                {
                    Left = new BinaryTreeNode(4)
                },
                Right = new BinaryTreeNode(3)
            };
            
            var notBalanced = new BinaryTreeNode(1)
            {
                Left = new BinaryTreeNode(2)
                {
                    Left = new BinaryTreeNode(4)
                    {
                        Left = new BinaryTreeNode(5)
                        {
                            Left = new BinaryTreeNode(6)
                        }
                    }
                },
                Right = new BinaryTreeNode(3)
            };

            Console.WriteLine(true == SolutionRecursive(balanced));
            Console.WriteLine(true == SolutionRecursive(balanced2));
            Console.WriteLine(false == SolutionRecursive(notBalanced));
        }

        private bool SolutionRecursive(BinaryTreeNode root)
        {            
            return SolutionRecursiveHelper(root) <= 1;
        }

        private int SolutionRecursiveHelper(BinaryTreeNode node)
        {
            if (node.Left == null && node.Right == null)
            {
                return 0;
            }

            if (node.Left != null && node.Right == null)
            {
                return 1 + SolutionRecursiveHelper(node.Left);
            }
            
            if (node.Left == null && node.Right != null)
            {
                return 1 + SolutionRecursiveHelper(node.Right);
            }

            return Math.Max(SolutionRecursiveHelper(node.Left), SolutionRecursiveHelper(node.Right));
        }
    }
}