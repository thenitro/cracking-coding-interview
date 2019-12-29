using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.LinkedLists
{
    public class Task26
    {
        public Task26()
        {
            var palindromeNotEven = new Node(1)
            {
                Next = new Node(2)
                {
                    Next = new Node(3)
                    {
                        Next = new Node(2)
                        {
                            Next = new Node(1)
                        }
                    }
                }
            };
            
            var palindromeEven = new Node(1)
            {
                Next = new Node(2)
                {
                    Next = new Node(2)
                    {
                        Next = new Node(1)
                    }
                }
            };
            
            var palindromeNot = new Node(1)
            {
                Next = new Node(2)
                {
                    Next = new Node(3)
                    {
                        Next = new Node(1)
                    }
                }
            };

            Console.WriteLine(true == Solution(palindromeNotEven));
            Console.WriteLine(true == Solution(palindromeEven));
            Console.WriteLine(false == Solution(palindromeNot));
        }

        private bool Solution(Node root)
        {
            var counter = 0;
            var next = root;

            while (next != null)
            {
                counter++;
                next = next.Next;
            }

            var middle = counter / 2;
            var skipMiddle = counter % 2 != 0;
            
            var stack = new Stack<int>();
            
            next = root;
            
            while (next != null)
            {
                if (middle > 0)
                {
                    middle--;
                    stack.Push(next.Value);
                }
                else
                {
                    if (skipMiddle)
                    {
                        skipMiddle = false;
                    }
                    else
                    {                    
                        var value = stack.Pop();
                        if (value != next.Value)
                        {
                            return false;
                        }
                    }   
                }

                next = next.Next;
            }
            
            return true;
        }
    }
}