using System;

namespace CrackingCodingInterview.Moderate
{
    public class Task1618
    {
        public Task1618()
        {
            Console.WriteLine(true == Solution("catcatgocatgo", "aabab"));
            Console.WriteLine(false == Solution("catcatgogocatgo", "aabab"));
        }

        private bool Solution(string value, string pattern)
        {
            if (pattern.Length == 0)
            {
                return value.Length == 0;
            }

            var mainChar = pattern[0];
            var altChar = mainChar == 'a' ? 'b' : 'a';

            var countOfMain = CountOf(pattern, mainChar);
            var countOfAlt = CountOf(pattern, altChar);

            var firstAlt = pattern.IndexOf(altChar);
            var maxMainSize = value.Length / countOfMain;

            for (var mainSize = 0; mainSize <= maxMainSize; mainSize++)
            {
                var remainingLength = value.Length - mainSize * countOfMain;
                if (countOfAlt == 0 || remainingLength % countOfAlt == 0)
                {
                    var altIndex = firstAlt * mainSize;
                    var altSize = countOfAlt == 0 ? 0 : remainingLength / countOfAlt;

                    if (Matches(pattern, value, mainSize, altSize, altIndex))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool Matches(string pattern, string value, int mainSize, int altSize, int firstAlt)
        {
            var stringIndex = mainSize;

            for (var i = 1; i < pattern.Length; i++)
            {
                var size = pattern[i] == pattern[0] ? mainSize : altSize;
                var offset = pattern[i] == pattern[0] ? 0 : firstAlt;

                if (!IsEqual(value, offset, stringIndex, size))
                {
                    return false;
                }

                stringIndex += size;
            }

            return true;
        }

        private bool IsEqual(string s1, int offset1, int offset2, int size)
        {
            for (var i = 0; i < size; i++)
            {
                if (s1[offset1 + i] != s1[offset2 + i])
                {
                    return false;
                }
            }

            return true;
        }

        private int CountOf(string patter, char c)
        {
            var count = 0;
            
            foreach (var currentC in patter)
            {
                if (c == currentC)
                {
                    count++;
                }
            }

            return count;
        }
    }
}