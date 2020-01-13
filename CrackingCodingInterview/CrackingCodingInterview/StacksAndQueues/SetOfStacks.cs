using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.StacksAndQueues
{
    public class SetOfStacks<T>
    {
        private int _currentStackIndex;
        private int _stackLimit;
        
        private List<Stack<T>> _listOfStacks;
        
        public SetOfStacks(int stackLimit)
        {
            if (stackLimit < 1)
            {
                throw new ArgumentException("Stack limit must be more than zero");
            }

            _currentStackIndex = 0;
            _listOfStacks = new List<Stack<T>>();
            
            _stackLimit = stackLimit;
        }

        public int CurrentStackIndex => _currentStackIndex;

        public void Push(T item)
        {
            if (_listOfStacks.Count == 0)
            {
                _listOfStacks.Add(new Stack<T>());
            }
            
            var stack = _listOfStacks[_currentStackIndex];
                stack.Push(item);

            if (stack.Count >= _stackLimit)
            {
                _currentStackIndex++;
                _listOfStacks.Add(new Stack<T>());
            }
        }

        public T Pop()
        {
            var stack = _listOfStacks[_currentStackIndex];
            if (stack.Count == 0)
            {
                return default(T);
            }
            
            var item = stack.Pop();

            if (stack.Count == 0)
            {
                _currentStackIndex--;
                _listOfStacks.RemoveAt(_listOfStacks.Count - 1);
            }

            return item;
        }

        public T PopAt(int index)
        {
            if (index == _currentStackIndex)
            {
                return Pop();
            }

            var stack = _listOfStacks[index];
            var item = stack.Pop();

            if (stack.Count == 0)
            {
                _currentStackIndex--;
                _listOfStacks.Remove(stack);
            }

            return item;
        }
    }
}