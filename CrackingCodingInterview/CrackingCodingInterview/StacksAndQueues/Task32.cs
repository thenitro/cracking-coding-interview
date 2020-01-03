using System;

namespace CrackingCodingInterview.StacksAndQueues
{
    public class Task32
    {
        public Task32()
        {
            var stack = new CustomMinMaxStack();
            
            stack.Push(4);
            stack.Push(3);
            stack.Push(2);
            stack.Push(1);

            Console.WriteLine(1 == stack.Min());
            Console.WriteLine(4 == stack.Max());

            stack.Pop();
            stack.Pop();
            stack.Pop();
            
            Console.WriteLine(4 == stack.Min());
            Console.WriteLine(4 == stack.Max());
            
            stack.Pop();
            
            Console.WriteLine(0 == stack.Min());
            Console.WriteLine(0 == stack.Max());
            
            stack.Push(5);
            stack.Push(6);
            stack.Push(7);
            stack.Push(8);
            
            Console.WriteLine(5 == stack.Min());
            Console.WriteLine(8 == stack.Max());
        }
    }
}