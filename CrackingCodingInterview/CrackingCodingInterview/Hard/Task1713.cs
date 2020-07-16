using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingCodingInterview.Hard
{
    public class Task1713
    {
        public Task1713()
        {
            var dict = new HashSet<string>()
            {
                "looked",
                "just",
                "like",
                "her",
                "brother"
            };
            Console.WriteLine($"'{Solution("jesslookedjustliketimherbrother", dict)}'");
        }

        private string Solution(string s, HashSet<string> dict)
        {
            var result = string.Empty;
            var subResult = new List<WordNode>();
            var prevWord = 0;

            for (var i = 0; i < s.Length; i++)
            {
                foreach (var node in subResult)
                {
                    node.Word.Append(s[i]);
                }
                
                var sb = new StringBuilder();
                    sb.Append(s[i]);
                
                subResult.Add(new WordNode()
                {
                    Started = i,
                    Word = sb,
                });

                var found = false;
                
                foreach (var node in subResult)
                {
                    var word = node.Word.ToString();
                    
                    if (dict.Contains(word))
                    {
                        var wordEndIndex = node.Started + node.Word.Length;
                        
                        var partOne = s.Substring(0, node.Started);
                        var partWord = s.Substring(node.Started, node.Word.Length);
                        var partTwo = s.Substring(wordEndIndex, s.Length - wordEndIndex);

                        var prefix = !char.IsWhiteSpace(s[node.Started - 1]) && partOne.Length > 0 ? " " : string.Empty;
                        var postfix = wordEndIndex < s.Length && !char.IsWhiteSpace(s[wordEndIndex]) ? " " : string.Empty;
                        
                        s = partOne + prefix + partWord + postfix + partTwo;
                        
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    subResult.Clear();
                }
            }
            
            return s;
        }

        private class WordNode
        {
            public int Started;
            public StringBuilder Word;
        }
    }
}