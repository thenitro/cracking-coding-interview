using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.RecursionAndDp
{
    public class Task84
    {
        public Task84()
        {
            var result = Solution(new[] {1, 2, 3, 4, 5});

            foreach (var subresult in result)
            {
                Console.WriteLine(string.Join(",", subresult));
            }
        }

        private List<List<int>> Solution(int[] input)
        {
            var result = new List<List<int>>();
            
            Dfs(input, 0, new List<int>(), result);

            return result;
        }

        private void Dfs(int[] input, int index, List<int> tmp, List<List<int>> result)
        {
            if (index >= input.Length)
            {
                return;
            }
            
            var subarray = new List<int>();

            foreach (var item in tmp)
            {
                subarray.Add(item);
            }
            
            result.Add(subarray);

            for (var i = index; i < input.Length; i++)
            {
                tmp.Add(input[i]);
                Dfs(input, i + 1, tmp, result);
                tmp.RemoveAt(tmp.Count - 1);
            }
        }
    }
}