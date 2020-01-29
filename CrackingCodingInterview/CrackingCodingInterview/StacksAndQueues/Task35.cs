using System;

namespace CrackingCodingInterview.StacksAndQueues
{
    public class Task35
    {
        public Task35()
        {
            var minStack = new MinStack();
            
            minStack.Push(4);
            minStack.Push(1);
            minStack.Push(2);
            minStack.Push(3);

            Console.WriteLine(1 == minStack.Peek());
            Console.WriteLine(1 == minStack.Pop());
            Console.WriteLine(2 == minStack.Peek());
            Console.WriteLine(2 == minStack.Pop());
            Console.WriteLine(3 == minStack.Peek());
            Console.WriteLine(3 == minStack.Pop());
            Console.WriteLine(4 == minStack.Peek());
            Console.WriteLine(4 == minStack.Pop());
            Console.WriteLine(0 == minStack.Pop());
            Console.WriteLine(true == minStack.IsEmpty());
        }
    }
}