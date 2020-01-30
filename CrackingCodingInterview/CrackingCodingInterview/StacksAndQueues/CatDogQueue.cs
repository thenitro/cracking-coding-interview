using System.Collections.Generic;

namespace CrackingCodingInterview.StacksAndQueues
{
    public class CatDogQueue
    {
        private LinkedList<CatDogNode> _list = new LinkedList<CatDogNode>();

        private int _cats = 0;
        private int _dogs = 0;
        
        public void Enqueue(Animal animal)
        {
            _list.AddLast(new CatDogNode() {  animal = animal, Order = animal == Animal.Cat ? _cats : _dogs});

            if (animal == Animal.Cat)
            {
                _cats++;
            } 
            else
            {
                _dogs++;
            }
        }

        public CatDogNode Dequeue()
        {
            var last = _list.Last.Value;

            _list.RemoveLast();
            
            return last;
        }
        
        public CatDogNode DequeueCat()
        {
            return DequeueByType(Animal.Cat);
        }
        
        public CatDogNode DequeueDog()
        {
            return DequeueByType(Animal.Dog);
        }

        private CatDogNode DequeueByType(Animal animal)
        {
            var node = _list.Last;

            while (node != null || node.Value.animal == animal)
            {
                node = node.Previous;
            }

            if (node != null)
            {
                _list.Remove(node);
            }

            return node.Value;
        }
    }

    public enum Animal
    {
        Cat,
        Dog,
    }

    public class CatDogNode
    {
        public Animal animal;
        public int Order;
    }
}