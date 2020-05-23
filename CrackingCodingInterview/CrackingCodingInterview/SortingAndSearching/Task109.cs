using System;

namespace CrackingCodingInterview.SortingAndSearching
{
    public class Task109
    {
        public Task109()
        {
            var matrix = new[]
            {
                new[] { 1, 2, 3, 4, 5 },
                new[] { 6, 7, 8, 9, 10 },
                new[] { 11, 12, 13, 14, 15 },
            };

            Console.WriteLine(Solution(matrix, 6));
            Console.WriteLine(Solution(matrix, 5));
            Console.WriteLine(Solution(matrix, 8));
            Console.WriteLine(Solution(matrix, 15));
            Console.WriteLine(Solution(matrix, 115));
        }
        
        private Tuple<int, int> Solution(int[][] matrix, int value)
        {
            var lo = 0;
            var hi = matrix.Length;

            while (lo < hi)
            {
                var mid = (lo + hi) / 2;
                
                if (matrix[mid][0] == value)
                {
                    return new Tuple<int, int>(mid, 0);
                } 
                else if (matrix[mid][0] < value && (mid + 1 >= matrix.Length || matrix[mid + 1][0] > value))
                {
                    var l = 0;
                    var r = matrix[mid].Length;

                    while (l < r)
                    {
                        var m = (l + r) / 2;
                        
                        if (matrix[mid][m] == value)
                        {
                            return new Tuple<int, int>(mid, m);
                        }
                        else if (matrix[mid][m] > value)
                        {
                            r = m;
                        }
                        else
                        {
                            l = m + 1;
                        }
                    }
                    
                    return new Tuple<int, int>(-1, -1);
                }
                else if (matrix[mid][0] > value)
                {
                    hi = mid;
                }
                else
                {
                    lo = mid + 1;
                }
            }
            
            return new Tuple<int, int>(-1, -1);
        }
    }
}