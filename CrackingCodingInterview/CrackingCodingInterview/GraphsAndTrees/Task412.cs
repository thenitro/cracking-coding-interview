using System;

namespace CrackingCodingInterview.GraphsAndTrees
{
    public class Task412
    {
        public Task412()
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

            Console.WriteLine(1 == Solution(root, 9));
        }

        private int Solution(BinaryTreeNode root, int N)
        {
            if (root == null)
            {
                return 0;
            }

            var pathsFromRoot = Dfs(root, N, 0);

            var pathsOnLeft = Solution(root.Left, N);
            var pathsOnRight = Solution(root.Right, N);

            return pathsFromRoot + pathsOnLeft + pathsOnRight;
        }

        private int Dfs(BinaryTreeNode node, int N, int sum)
        {
            if (node == null)
            {
                return 0;
            }

            sum += node.Value;

            var paths = 0;
            if (sum == N)
            {
                paths++;
            }

            paths += Dfs(node.Left, N, sum);
            paths += Dfs(node.Right, N, sum);
            
            return paths;
        }
    }
}