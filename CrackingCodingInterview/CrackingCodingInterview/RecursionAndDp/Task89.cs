using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrackingCodingInterview.RecursionAndDp
{
    public class Task89
    {
        public Task89()
        {
            Console.WriteLine(string.Join(",", SolutionNaive(3)));
            Console.WriteLine(string.Join(",", GenerateNotEfficient(3)));
            Console.WriteLine(string.Join(",", GenerateParens(3)));
        }

        private List<string> SolutionNaive(int N)
        {
            var generated = GenParens(N);
            var result = new List<string>();

            SolutionHelper(generated, generated.Length, new StringBuilder(), result, new HashSet<int>(), new HashSet<string>());
            
            return result;
        }

        private string GenParens(int N)
        {
            var result = string.Empty;

            for (var i = 0; i < N; i++)
            {
                result += '(';
            }
            
            for (var i = 0; i < N; i++)
            {
                result += ')';
            }

            return result;
        }

        private void SolutionHelper(string generated, int length, 
            StringBuilder tmp, List<string> result, HashSet<int> memo, HashSet<string> memo2)
        {
            if (length == 0)
            {
                var str = tmp.ToString();
                
                if (!memo2.Contains(str) && Validate(tmp))
                {
                    result.Add(str);
                }

                memo2.Add(str);
                
                return;
            }

            for (var i = 0; i < generated.Length; i++)
            {
                if (memo.Contains(i))
                {
                    continue;
                }
                
                tmp.Append(generated[i]);
                memo.Add(i);
                
                SolutionHelper(generated, length - 1, tmp, result, memo, memo2);
                
                tmp.Remove(tmp.Length - 1, 1);
                memo.Remove(i);
            }
        }

        private bool Validate(StringBuilder tmp)
        {
            var stack = new Stack<char>();

            for (int i = 0; i < tmp.Length; i++)
            {
                if (tmp[i] == '(')
                {
                    stack.Push('(');
                    continue;
                }

                if (tmp[i] == ')' && stack.Count > 0)
                {                    
                    var prev = stack.Pop();
                    if (prev != '(')
                    {
                        stack.Push(prev);
                    }
                }
            }

            return stack.Count == 0;
        }

        private string[] GenerateNotEfficient(int remaining)
        {
            var set = new HashSet<string>();

            if (remaining == 0)
            {
                set.Add("");
            }
            else
            {
                var prev = GenerateNotEfficient(remaining - 1);

                foreach (var str in prev)
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (str[i] == '(')
                        {
                            var s = InsertInside(str, i);
                            set.Add(s);
                        }
                    }
                    
                    set.Add("()" + str);
                }
            }

            return set.ToArray();
        }

        private string InsertInside(string str, int leftIndex)
        {
            var left = str.Substring(0, leftIndex + 1);
            var right = str.Substring(leftIndex + 1, str.Length - (leftIndex + 1));

            return left + "()" + right;
        }

        private List<string> GenerateParens(int count)
        {
            var str = new char[count * 2];
            var list = new List<string>();
            AddParen(list, count, count, str, 0);
            return list;
        }

        private void AddParen(List<string> list, int left, int right, char[] str, int index)
        {
            if (left < 0 || right < left)
            {
                return;
            }

            if (left == 0 && right == 0)
            {
                list.Add(new string(str));
            }
            else
            {
                str[index] = '(';
                AddParen(list, left - 1, right, str, index + 1);

                str[index] = ')';
                AddParen(list, left, right - 1, str, index + 1);
            }
        } 
    }
}