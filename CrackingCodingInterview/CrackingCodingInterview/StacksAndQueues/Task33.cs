using System;

namespace CrackingCodingInterview.StacksAndQueues
{
    public class Task33
    {
        public Task33()
        {
            var stacks = new SetOfStacks<int>(1);
            
                stacks.Push(1);
                stacks.Push(2);
                stacks.Push(3);

            Console.WriteLine("data: " + stacks.PopAt(0));
            Console.WriteLine("stack index: " + stacks.CurrentStackIndex);
            Console.WriteLine("data: " + stacks.PopAt(0));
            Console.WriteLine("stack index: " + stacks.CurrentStackIndex);
            Console.WriteLine("data: " + stacks.PopAt(0));
            Console.WriteLine("stack index: " + stacks.CurrentStackIndex);
            Console.WriteLine("data: " + stacks.PopAt(0));
            Console.WriteLine("stack index: " + stacks.CurrentStackIndex);
        }
    }
}