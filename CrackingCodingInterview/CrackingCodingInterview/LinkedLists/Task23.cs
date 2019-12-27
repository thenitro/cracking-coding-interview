using System;

namespace CrackingCodingInterview.LinkedLists
{
    public class Task23
    {
        public Task23()
        {

            var middle = new Node(3)
            {
                Next = new Node(4)
                {
                    Next = new Node(5)
                    {
                        Next = new Node(6)
                    }
                }
            };
            
            var node = new Node(1)
            {
                Next = new Node(2)
                {
                    Next = middle
                }
            };

            PrintList(node);
            Solve(middle);
            PrintList(node);
        }

        private void Solve(Node node)
        {
            node.Value = node.Next.Value;
            node.Next = node.Next.Next;
        }

        private void PrintList(Node root)
        {
            while (root != null)
            {
                Console.Write("->" + root.Value);
                root = root.Next;
            }

            Console.WriteLine();
        }
    }
}