using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.StacksAndQueues
{
    public class MyQueue<T>
    {
        private Stack<T> _stack = new Stack<T>();
        
        public void Enqueue(T value)
        {
            _stack.Push(value);
            
            Console.WriteLine(string.Join(", ", _stack.ToArray()));
        }

        public T Dequeue()
        {
            if (_stack.Count == 0)
            {
                return default(T);
            }
            
            var stackTmp = new Stack<T>();

            while (_stack.Count > 1)
            {
                stackTmp.Push(_stack.Pop());
            }

            var result = _stack.Pop();

            while (stackTmp.Count > 0)
            {
                _stack.Push(stackTmp.Pop());
            }
            
            return result;
        }

        public T Peek()
        {
            return _stack.Peek();
        }
    }
}