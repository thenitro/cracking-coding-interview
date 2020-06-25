using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.Hard
{
    public class Task1705
    {
        public Task1705()
        {
            Console.WriteLine(string.Join(",",
                Solution(new char[] { '1', 'a', '1', '1', 'a', 'a', '1', '1', '1', 'a', 'a', 'a', 'a', 'a', 'a', '1'})));
        }

        private char[] Solution(char[] array)
        {
            var deltas = ComputeDeltaArray(array);
            var match = FindLongestMatch(deltas);

            Console.WriteLine(string.Join(",", match));

            return GetResult(array, match[0] + 1, match[1]);
        }

        private int[] ComputeDeltaArray(char[] array)
        {
            var deltas = new int[array.Length];
            var delta = 0;

            for (var i = 0; i < array.Length; i++)
            {
                if (char.IsDigit(array[i]))
                {
                    delta--;
                }
                else
                {
                    delta++;
                }

                deltas[i] = delta;
            }

            return deltas;
        }

        private int[] FindLongestMatch(int[] deltas)
        {
            var dict = new Dictionary<int, int>();
                dict.Add(0, -1);
            
            var max = new int[2];

            for (var i = 0; i < deltas.Length; i++)
            {
                if (!dict.ContainsKey(deltas[i]))
                {
                    dict.Add(deltas[i], i);
                }
                else
                {
                    var match = dict[deltas[i]];
                    var distance = i - match;
                    var longest = max[1] - max[0];

                    if (distance > longest)
                    {
                        max[1] = i;
                        max[0] = match;
                    }
                }
            }
            
            return max;
        }

        private char[] GetResult(char[] array, int start, int end)
        {
            var result = new char[end - start + 1];

            for (var i = start; i <= end; i++)
            {   
                result[i - start] = array[i];
            }

            return result;
        }
    }
}