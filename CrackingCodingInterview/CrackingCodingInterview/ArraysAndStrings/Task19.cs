using System;
using System.Collections.Generic;

namespace Algorithms.RandomTests.CrackingCodingInterview
{
    public class Task19
    {
        public Task19()
        {
            Console.WriteLine(true == Solve("waterbottle", "erbottlewat"));
        }

        private bool Solve(string s1, string s2)
        {
            var queue = new Queue<char>();

            foreach (var symbol in s2)
            {
                queue.Enqueue(symbol);
            }

            var counter = 0;
            
            while (counter < queue.Count)
            {
                queue.Enqueue(queue.Dequeue());
                
                var newStr = new string(queue.ToArray());
                if (newStr == s1)
                {
                    return true;
                }

                counter++;
            }

            return false;
        }
    }
}