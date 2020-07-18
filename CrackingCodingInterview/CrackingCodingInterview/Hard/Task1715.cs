using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.Hard
{
    public class Task1715
    {
        public Task1715()
        {
            Console.WriteLine(Solution(new [] { "cat", "banana", "dog", "nana", "walk", "walker", "dogwalker" }));
        }

        private string Solution(string[] array)
        {
            var map = new HashSet<string>();

            foreach (var s in array)
            {
                if (map.Contains(s))
                {
                    continue;
                }

                map.Add(s);
            }

            var result = new string[1];
                result[0] = string.Empty;

            Helper(array, map, new List<string>(), 0, result);
            
            return result[0];
        }

        private void Helper(
            string[] array, HashSet<string> set, 
            List<string> currentWord, int currentIndex,
            string[] result)
        {
            if (currentIndex == array.Length)
            {
                return;
            }
            
            var word = string.Join("", currentWord);
            if (set.Contains(word))
            {
                result[0] = result[0].Length < word.Length ? word : result[0];
            }
            
            currentWord.Add(array[currentIndex]);
            Helper(array, set, currentWord, currentIndex + 1, result);
            currentWord.RemoveAt(currentWord.Count - 1);
            
            Helper(array, set, currentWord, currentIndex + 1, result);
        }
    }
}