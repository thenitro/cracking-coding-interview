using System;

namespace CrackingCodingInterview.LinkedLists
{
    public class Task24
    {
        public Task24()
        {
            var node = new Node(3)
            {
                Next = new Node(5)
                {
                    Next = new Node(8)
                    {
                        Next = new Node(5)
                        {
                            Next = new Node(10)
                            {
                                Next = new Node(2)
                                {
                                    Next = new Node(1)
                                }
                            }
                        }
                    }
                }
            };

            node.Print();
            var newHead = Solve(node, 5);
            newHead.Print();
        }

        private Node Solve(Node root, int value)
        {
            Node less = null;
            Node lessHead = null;
            Node bigger = null;
            Node biggerHead = null;

            var next = root;
            
            while (next != null)
            {
                if (next.Value < value)
                {
                    if (less == null)
                    {
                        less = new Node(next.Value);
                        lessHead = less;
                    }
                    else
                    {
                        less.Next = new Node(next.Value);
                        less = less.Next;
                    }
                }
                else
                {
                    if (bigger == null)
                    {
                        bigger = new Node(next.Value);
                        biggerHead = bigger;
                    }
                    else
                    {
                        bigger.Next = new Node(next.Value);
                        bigger = bigger.Next;
                    }
                }
                
                next = next.Next;
            }

            if (less == null && biggerHead == null)
            {
                return null;
            }

            if (less == null)
            {
                return biggerHead;
            }

            if (biggerHead == null)
            {
                return root;
            }

            less.Next = biggerHead;

            return lessHead;
        }
    }
}