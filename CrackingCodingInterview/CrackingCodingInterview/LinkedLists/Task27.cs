using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.LinkedLists
{
    public class Task27
    {
        public Task27()
        {
            var intersection = new Node(5)
            {
                Next = new Node(6)
                {
                    Next = new Node(7)
                }
            };
            
            var listA = new Node(1)
            {
                Next = new Node(2)
                {
                    Next = new Node(3)
                    {
                        Next = intersection
                    }
                }
            };
            
            var listB = new Node(0)
            {
                Next = new Node(4)
                {
                    Next = intersection
                }
            };

            Console.WriteLine(Solve(listA, listB).Value);
        }

        private Node Solve(Node listA, Node listB)
        {
            var set = new HashSet<Node>();
            var next = listA;
            
            while (next != null)
            {
                set.Add(next);
                next = next.Next;
            }

            next = listB;

            while (next != null)
            {
                if (set.Contains(next))
                {
                    return next;
                }

                next = next.Next;
            }

            return null;
        }
    }
}