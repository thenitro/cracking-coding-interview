using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.LinkedLists
{
    public class Task21
    {
        public Task21()
        {
            var node = new Node(1)
            {
                Next = new Node(1)
                {
                    Next = new Node(2)
                    {
                        Next = new Node(2)
                        {
                            Next = new Node(3)
                            {
                                Next = new Node(3)
                            }
                        }
                    }
                }
            };
            
            Solve(node);

            var next = node;

            while (next != null)
            {
                Console.Write(next.Value + " ");
                next = next.Next;
            }
        }

        private void Solve(Node head)
        {
            var set = new HashSet<int>();
            
            var prev = head;
            set.Add(prev.Value);
            var next = head.Next;

            while (next != null)
            {
                if (set.Contains(next.Value))
                {
                    prev.Next = next.Next;
                }
                else
                {
                    set.Add(next.Value);
                    prev = next;
                }
                
                next = next.Next;
            }
        }
    }
}