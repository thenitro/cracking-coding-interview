using System;
using System.Linq;

namespace CrackingCodingInterview.Hard
{
    public class Task1718
    {
        public Task1718()
        {
            Console.WriteLine(string.Join(",", Solution(new [] { 1, 5, 9 }, new [] { 7, 5, 9, 0, 2, 1, 3, 5, 7, 9, 1, 1, 5, 8, 8, 9, 7 })));
        }

        private int[] Solution(int[] small, int[] large)
        {
            var result = new int[2];
            var set = small.ToHashSet();

            var minSize = int.MaxValue;
            
            for (var i = 0; i < large.Length; i++)
            {
                for (var j = i; j < large.Length; j++)
                {
                    if (set.Contains(large[j]))
                    {
                        set.Remove(large[j]);

                        if (set.Count == 0)
                        {
                            if (minSize > j - i)
                            {
                                minSize = j - i;
                                
                                result[0] = i;
                                result[1] = j;
                            }

                            set = small.ToHashSet();
                            break;
                        }
                    }
                }
            }
            
            return result;
        }
    }
}