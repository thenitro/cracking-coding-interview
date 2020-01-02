using System;

namespace CrackingCodingInterview.StacksAndQueues
{
    public class Task31
    {
        public Task31()
        {
            var stack = new CustomNStack<int>(3, 100);
                stack.Push(0, 1);
                
            Console.WriteLine(stack.Peek(0));
            
            stack.Push(0, 2);
            Console.WriteLine(stack.Peek(0));
            
            stack.Push(0, 3);
            Console.WriteLine(stack.Peek(0));

            stack.Pop(0);
            Console.WriteLine(stack.Peek(0));
            
            stack.Pop(0);
            Console.WriteLine(stack.Peek(0));
            
            stack.Pop(0);
            Console.WriteLine(stack.Peek(0));
        }
    }
}