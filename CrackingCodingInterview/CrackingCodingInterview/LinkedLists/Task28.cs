using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.LinkedLists
{
    public class Task28
    {
        public Task28()
        {
            var lastOfLoop = new Node(6);
            var nextAfterLoop = new Node(4)
            {
                Next = new Node(5)
                {
                    Next = lastOfLoop
                }
            };
            
            var loop = new Node(3)
            {
                Next = nextAfterLoop
            };
            
            lastOfLoop.Next = loop;
            
            var head = new Node(1)
            {
                Next = new Node(2)
                {
                    Next = loop
                }
            };

            Console.WriteLine(Solve(head).Value);
        }

        private Node Solve(Node head)
        {
            var set = new HashSet<Node>();
            var next = head;

            while (next != null)
            {
                if (set.Contains(next))
                {
                    return next;
                }
                else
                {
                    set.Add(next);
                    next = next.Next;
                }
            }

            return null;
        }
    }
}