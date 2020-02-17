using System;
using System.Xml.Schema;

namespace CrackingCodingInterview.GraphsAndTrees
{
    public class Task45
    {
        public Task45()
        {
            var validRoot = new BinaryTreeNode(5)
            {
                Left = new BinaryTreeNode(4)
                {
                    Left = new BinaryTreeNode(1)
                },
                Right = new BinaryTreeNode(6)
                {
                    Right = new BinaryTreeNode(8)
                }
            };
            
            Console.WriteLine(true == Solution(validRoot));
            
            var inValidRoot = new BinaryTreeNode(5)
            {
                Left = new BinaryTreeNode(4)
                {
                    Right = new BinaryTreeNode(1)
                },
                Right = new BinaryTreeNode(6)
                {
                    Left = new BinaryTreeNode(8)
                }
            };
            
            Console.WriteLine(false == Solution(inValidRoot));
        }

        private bool Solution(BinaryTreeNode root)
        {
            if (root == null)
            {
                return true;
            }
            
            if (root.Left != null && root.Left.Value > root.Value)
            {
                return false;
            }
            
            if (root.Right != null && root.Right.Value < root.Value)
            {
                return false;
            }

            return Solution(root.Left) && Solution(root.Right);
        }
    }
}