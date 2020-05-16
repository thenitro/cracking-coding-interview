using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.RecursionAndDp
{
    public class Task814
    {
        public Task814()
        {
            Console.WriteLine(2 == Solution("1^0|0|1", false));
            Console.WriteLine(10 == Solution("0&0&0&1^1|0", true));
        }

        private int Solution(string s, bool result)
        {
            return CountEval(s, result, new Dictionary<string, int>());
        }

        private int CountEval(string s, bool result, Dictionary<string, int> memo)
        {
            if (s.Length == 0)
            {
                return 0;
            }

            if (s.Length == 1)
            {
                return StringToBool(s) == result ? 1 : 0;
            }

            var key = result + s;

            if (memo.ContainsKey(key))
            {
                return memo[key];
            }

            var ways = 0;

            for (var i = 1; i < s.Length; i += 2)
            {
                var c = s[i];

                var left = s.Substring(0, i);
                var right = s.Substring(i + 1, s.Length - (i + 1));

                var leftTrue = CountEval(left, true, memo);
                var leftFalse = CountEval(left, false, memo);

                var rightTrue = CountEval(right, true, memo);
                var rightFalse = CountEval(right, false, memo);

                var total = (leftTrue + leftFalse) * (rightTrue + rightFalse);

                var totalTrue = 0;

                if (c == '^')
                {
                    totalTrue = leftTrue * rightFalse + leftFalse * rightTrue;
                } 
                else if (c == '&')
                {
                    totalTrue = leftTrue * rightTrue;
                }
                else if (c == '|')
                {
                    totalTrue = leftTrue * rightTrue + 
                                leftFalse * rightTrue + 
                                leftTrue * rightFalse;
                }
                
                var subWays = result ? totalTrue : total - totalTrue;
                ways += subWays;
            }

            memo[key] = ways;
            return ways;
        }

        private bool StringToBool(string s)
        {
            return s == "1";
        }
    }
}