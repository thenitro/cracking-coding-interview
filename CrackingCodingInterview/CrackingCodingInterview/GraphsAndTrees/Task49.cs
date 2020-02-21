using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.GraphsAndTrees
{
    public class Task49
    {
        public Task49()
        {
            var root = new BinaryTreeNode(2)
            {
                Left = new BinaryTreeNode(1),
                Right = new BinaryTreeNode(3),
            };

            foreach (var subsolution in Solution(root))
            {
                Console.WriteLine(string.Join(", ", subsolution));
            }
        }

        private List<List<int>> Solution(BinaryTreeNode root)
        {
            var result = new List<List<int>>();

            if (root == null)
            {
                result.Add(new List<int>());
                return result;
            }
            
            var prefix = new List<int>();
                prefix.Add(root.Value);

            var leftSequence = Solution(root.Left);
            var rightSequence = Solution(root.Right);

            foreach (var left in leftSequence)
            {
                foreach (var right in rightSequence)
                {
                    var weaved = new List<List<int>>();

                    WeaveLists(left, right, weaved, prefix);

                    foreach (var subWeave in weaved)
                    {
                        result.Add(subWeave);
                    }
                }
            }

            return result;
        }

        private void WeaveLists(List<int> first, List<int> second, List<List<int>> results, List<int> prefix)
        {
            if (first.Count == 0 || second.Count == 0)
            {
                var result = new List<int>(prefix);

                foreach (var i in first)
                {
                    result.Add(i);
                }
                
                foreach (var i in second)
                {
                    result.Add(i);
                }
                
                results.Add(result);
                return;
            }
            
            var headFirst = first[0];
            first.RemoveAt(0);
            
            prefix.Add(headFirst);
            WeaveLists(first, second, results, prefix);
            prefix.RemoveAt(prefix.Count - 1);
            first.Insert(0, headFirst);
            
            var headSecond = second[0];
            second.RemoveAt(0);
            prefix.Add(headSecond);
            WeaveLists(first, second, results, prefix);
            prefix.RemoveAt(prefix.Count - 1);
            second.Insert(0, headSecond);
        } 
    }
}