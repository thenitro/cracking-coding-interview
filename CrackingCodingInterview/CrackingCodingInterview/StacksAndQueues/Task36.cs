using System;

namespace CrackingCodingInterview.StacksAndQueues
{
    public class Task36
    {
        public Task36()
        {
            var queue = new CatDogQueue();
            
            queue.Enqueue(Animal.Cat);
            queue.Enqueue(Animal.Dog);
            queue.Enqueue(Animal.Dog);
            queue.Enqueue(Animal.Cat);

            Console.WriteLine(Animal.Cat == queue.Dequeue().animal);
            Console.WriteLine(Animal.Dog == queue.Dequeue().animal);
            Console.WriteLine(Animal.Dog == queue.Dequeue().animal);
            Console.WriteLine(Animal.Cat == queue.Dequeue().animal);
            
            queue.Enqueue(Animal.Cat);
            queue.Enqueue(Animal.Dog);
            queue.Enqueue(Animal.Dog);
            queue.Enqueue(Animal.Cat);

            Console.WriteLine(3 == queue.DequeueCat().Order);
            Console.WriteLine(4 == queue.DequeueCat().Order);
            Console.WriteLine(3 == queue.DequeueDog().Order);
            Console.WriteLine(4 == queue.DequeueDog().Order);
        }
    }
}