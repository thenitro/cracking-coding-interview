using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingCodingInterview.Moderate
{
    public class Task1620
    {
        private readonly char[][] PAD = new []
        {
            new char[0],
            new char[0],
            new char[] { 'a', 'b', 'c' },
            new char[] { 'd', 'e', 'f' },
            new char[] { 'g', 'h', 'i' },
            new char[] { 'j', 'k', 'l' },
            new char[] { 'm', 'n', 'o' },
            new char[] { 'p', 'q', 'r', 's' },
            new char[] { 't', 'u', 'v' },
            new char[] { 'w', 'x', 'y', 'z' },
        };

        public Task1620()
        {
            var trieRoot = BuildDictionary(new[] {"tree", "used", "trie", "useed", "a", "the"});

            Console.WriteLine(string.Join(",", Solution(trieRoot, 8733)));
        }

        private List<string> Solution(TrieNode root, int number)
        {
            var result = new List<string>();
            var numbers = new Stack<int>();

            while (number > 0)
            {
                numbers.Push(number % 10);
                number /= 10;
            }

            CollectNumbers(root, numbers, result, new StringBuilder());   
            
            return result;
        }

        private void CollectNumbers(TrieNode node, Stack<int> numbers, List<string> result, StringBuilder currentWord)
        {
            if (numbers.Count == 0)
            {
                if (node.EndOfWord)
                {
                    result.Add(currentWord.ToString());                    
                }

                return;
            }
            
            var currentNumber = numbers.Pop();
            var possibleCharacters = PAD[currentNumber];

            for (var i = 0; i < possibleCharacters.Length; i++)
            {
                var currentCharacter = possibleCharacters[i];
                
                if (!node.Children.ContainsKey(currentCharacter))
                {
                    continue;
                }

                currentWord.Append(currentCharacter);
                
                CollectNumbers(node.Children[currentCharacter], numbers, result, currentWord);

                currentWord.Remove(currentWord.Length - 1, 1);
            }
            
            numbers.Push(currentNumber);
        }

        private TrieNode BuildDictionary(string[] array)
        {
            var root = new TrieNode('0', false);

            foreach (var s in array)
            {
                var currentNode = root;
                
                for (var i = 0; i < s.Length; i++)
                {
                    var isLast = s.Length - 1 == i;
                    var c = s[i];

                    currentNode = currentNode.AddChildren(c, isLast);
                }
            }
            
            return root;
        }
    }

    public class TrieNode
    {
        public Char Character;
        public bool EndOfWord;
        public Dictionary<char, TrieNode> Children { get; private set; }

        public TrieNode(char c, bool endOfWord)
        {
            Character = c;
            EndOfWord = endOfWord;
            
            Children = new Dictionary<char, TrieNode>();
        }

        public TrieNode AddChildren(Char c, bool isEndOfWord)
        {
            if (!Children.ContainsKey(c))
            {
                Children.Add(c, new TrieNode(c, isEndOfWord));
            }

            return Children[c];
        }
    }
}