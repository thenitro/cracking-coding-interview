using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.Hard
{
    public class Task1709
    {
        public Task1709()
        {
            Console.WriteLine(21 == Solution(7));
        }

        private int Solution(int k)
        {
            if (k < 0)
            {
                return 0;
            }

            var val = 0;

            var queue3 = new Queue<int>();
                queue3.Enqueue(1);
            
            var queue5 = new Queue<int>();
            var queue7 = new Queue<int>();

            for (var i = 0; i <= k; i++)
            {
                var v3 = queue3.Count > 0 ? queue3.Peek() : int.MaxValue;
                var v5 = queue5.Count > 0 ? queue5.Peek() : int.MaxValue;
                var v7 = queue7.Count > 0 ? queue7.Peek() : int.MaxValue;

                val = Math.Min(v3, Math.Min(v5, v7));

                if (val == v3)
                {
                    queue3.Dequeue();
                    queue3.Enqueue(3 * val);
                    queue3.Enqueue(5 * val);
                } 
                else if (val == v5)
                {
                    queue5.Dequeue();
                    queue5.Enqueue(5 * val);
                }
                else if (val == v7)
                {
                    queue7.Dequeue();
                }
                
                queue7.Enqueue(7 * val);
            }
            
            return val;
        }
    }
}