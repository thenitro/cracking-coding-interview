using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.Moderate
{
    public class Task1624
    {
        public Task1624()
        {
            var result = Solution(new int[] { 9, 10, 11, 12, 13, 1, 22, 25, 24, 0, 1, 2, 3, 4, 6, 5, 2, 3, 4, 5, 6}, 22);

            foreach (var tuple in result)
            {
                Console.WriteLine($"{tuple.Item1} + {tuple.Item2} = 22");
            }
        }

        private List<Tuple<int, int>> Solution(int[] array, int sum)
        {
            var dict = new Dictionary<int, int>();

            foreach (var i in array)
            {
                if (!dict.ContainsKey(i))
                {
                    dict.Add(i, 0);
                }

                dict[i]++;
            }

            var result = new List<Tuple<int, int>>();
            
            foreach (var i in array)
            {
                var diff = sum - i;
                
                if ((dict.ContainsKey(diff) && diff == i && dict[diff] > 1) || 
                    (dict.ContainsKey(diff) && diff != i && dict[diff] > 0))
                {
                    dict[diff]--;
                    dict[i]--;
                    
                    result.Add(new Tuple<int, int>(i, diff));
                }
            }

            return result;
        }
    }
}