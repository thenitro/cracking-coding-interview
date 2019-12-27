using System;

namespace CrackingCodingInterview.LinkedLists
{
    public class Task22
    {
        public Task22()
        {
            var node = new Node(1)
            {
                Next = new Node(2)
                {
                    Next = new Node(3)
                    {
                        Next = new Node(4)
                        {
                            Next = new Node(5)
                            {
                                Next = new Node(6)
                            }
                        }
                    }
                }
            };

            Console.WriteLine(Solve(node, 0).Value);
            Console.WriteLine(Solve(node, 1).Value);
            Console.WriteLine(Solve(node, 2).Value);
            Console.WriteLine(Solve(node, 3).Value);
            Console.WriteLine(Solve(node, 4).Value);
            Console.WriteLine(Solve(node, 5).Value);
        }

        private Node Solve(Node root, int n)
        {
            var next = root;
            var next2 = root;
            
            var count = 0;
            
            while (next != null)
            {   
                next = next.Next;
                count++;
                
                if (count > n && next != null)
                {
                    next2 = next2.Next;
                }
            }

            return next2;
        }
    }
}