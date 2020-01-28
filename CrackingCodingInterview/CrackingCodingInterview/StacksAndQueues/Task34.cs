using System;

namespace CrackingCodingInterview.StacksAndQueues
{
    public class Task34
    {
        public Task34()
        {
            var queue = new MyQueue<int>();
            
            queue.Enqueue(1);

            Console.WriteLine(1 == queue.Dequeue());//1
            Console.WriteLine(0 == queue.Dequeue());//0
            
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Console.WriteLine(1 == queue.Dequeue());//1
            Console.WriteLine(2 == queue.Dequeue());//2
            Console.WriteLine(3 == queue.Dequeue());//3
        }
    }
}