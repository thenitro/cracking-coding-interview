using System.Collections.Generic;

namespace CrackingCodingInterview.StacksAndQueues
{
    public class CustomNStack<T>
    {
        private int _size;
        
        private int[] _sizes;
        private T[] _list;
        
        public CustomNStack(int stacksAmount, int size)
        {
            _size = size;
            
            _sizes = new int[stacksAmount];
            _list = new T[size * stacksAmount];
        }

        public T Peek(int stackId)
        {
            if (_sizes[stackId] == 0)
            {
                return default(T);
            }
            
            return _list[GetTopIndex(stackId)];
        }

        public void Push(int stackId, T item)
        {
            if (_sizes[stackId] == _size)
            {
                return;
            }

            _sizes[stackId]++;
            _list[GetTopIndex(stackId)] = item;
        }

        public T Pop(int stackId)
        {
            if (_sizes[stackId] == 0)
            {
                return default(T);
            }

            var topIndex = GetTopIndex(stackId);
            var item = _list[topIndex];
            
            _list[topIndex] = default(T);
            _sizes[stackId]--;
            
            return item;
        }

        private int GetTopIndex(int stackId)
        {
            var offset = stackId * _size;
            var size = _sizes[stackId];

            return offset + size - 1;
        }
    }
}