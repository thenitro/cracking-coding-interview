using System;

namespace CrackingCodingInterview.GraphsAndTrees
{
    public class Task410
    {
        public Task410()
        {
            var rootA = new BinaryTreeNode(1)
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
            
            var rootB = new BinaryTreeNode(2)
            {
                Left = new BinaryTreeNode(4),
                Right = new BinaryTreeNode(5),
            };
            
            var rootC = new BinaryTreeNode(2)
            {
                Left = new BinaryTreeNode(41),
                Right = new BinaryTreeNode(51),
            };

            Console.WriteLine(true == SolutionDumb(rootA, rootB));
            Console.WriteLine(false == SolutionDumb(rootA, rootC));
        }

        private bool SolutionDumb(BinaryTreeNode rootA, BinaryTreeNode rootB)
        {
            if (rootA == null && rootB != null)
            {
                return false;
            }
            
            if (rootA != null && rootB == null)
            {
                return false;
            }

            if (rootA == null && rootB == null)
            {
                return true;
            }

            if (rootA.Value == rootB.Value)
            {
                return SolutionDumb(rootA.Left, rootB.Left) && SolutionDumb(rootA.Right, rootB.Right);
            }

            return SolutionDumb(rootA.Left, rootB) || SolutionDumb(rootA.Right, rootB);
        }
    }
}