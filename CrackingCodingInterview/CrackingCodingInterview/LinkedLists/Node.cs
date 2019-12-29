using System;

namespace CrackingCodingInterview.LinkedLists
{
    public class Node
    {
        public Node Next;
        public int Value;

        public Node(int value)
        {
            Value = value;
        }
        
        public void Print()
        {
            var next = this;
            
            while (next != null)
            {
                Console.Write("->" + next.Value);
                next = next.Next;
            }

            Console.WriteLine();
        }
    }
}