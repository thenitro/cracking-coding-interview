using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.Hard
{
    public class Task1722
    {
        public Task1722()
        {
            var dictionary = new HashSet<string>()
            {
                "DAMP",
                "LAMP",
                "LIMP",
                "LIME",
                "LIKE",
                "NIKE",
                "HIKE",
                "SIKE",
            };
            
            Console.WriteLine(string.Join("->", Solution("DAMP", "LIKE", dictionary)));
        }

        private List<string> Solution(string a, string b, HashSet<string> dictionary)
        {
            var visited = new HashSet<string>();
            return Helper(a, b, dictionary, visited);
        }

        private List<string> Helper(string a, string b, HashSet<string> dictionary, HashSet<string> visited)
        {
            if (a == b)
            {
                var path = new List<string>();
                    path.Add(a);

                return path;
            } 
            else if (visited.Contains(a) || !dictionary.Contains(a))
            {
                return null;
            }

            visited.Add(a);
            var words = WordsOneAway(a);
            
            foreach (var word in words)
            {
                var path = Helper(word, b, dictionary, visited);
                if (path != null)
                {
                    path.Insert(0, a);
                    return path;
                }
            }

            return null;
        }

        private List<string> WordsOneAway(string word)
        {
            var words = new List<string>();

            for (var i = 0; i < word.Length; i++)
            {
                for (var c = 'A'; c <= 'Z'; c++)
                {
                    var w = word.Substring(0, i) + c + word.Substring(i + 1, word.Length - i - 1);
                    words.Add(w);
                }
            }

            return words;
        }
    }
}