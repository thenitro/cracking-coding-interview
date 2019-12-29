using System;

namespace CrackingCodingInterview.LinkedLists
{
    public class Task25
    {
        public Task25()
        {
            var listA = new Node(7)
            {
                Next = new Node(1)
                {
                    Next = new Node(6)
                }
            };
            
            var listB = new Node(5)
            {
                Next = new Node(9)
                {
                    Next = new Node(2)
                }
            };

            var result = Solve(listA, listB);
                result.Print();
        }

        private Node Solve(Node listA, Node listB)
        {
            Node head = null;
            Node next = null;
            
            var memory = 0;
            
            while (listA != null || listB != null)
            {
                var calculate = (listA?.Value ?? 0) + (listB?.Value ?? 0) + memory;
                var newValue = calculate % 10;

                memory = calculate / 10;

                if (next == null)
                {
                    next = new Node(newValue);
                    head = next;
                }
                else
                {
                    next.Next = new Node(newValue);
                    next = next.Next;
                }

                listA = listA.Next;
                listB = listB.Next;
            }

            return head;
        }
    }
}