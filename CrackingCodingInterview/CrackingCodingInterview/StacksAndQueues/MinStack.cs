using System.Collections.Generic;

namespace CrackingCodingInterview.StacksAndQueues
{
    public class MinStack
    {
        private Stack<int> _stack = new Stack<int>();
        
        public void Push(int value)
        {
            if (_stack.Count == 0 || value < _stack.Peek())
            {
                _stack.Push(value);
            }
            else
            {
                var tmp = new Stack<int>();

                while (value > _stack.Peek())
                {
                    tmp.Push(_stack.Pop());
                }
                
                _stack.Push(value);

                while (tmp.Count > 0)
                {
                    _stack.Push(tmp.Pop());
                }
            }
        }

        public int Pop()
        {
            if (_stack.Count == 0)
            {
                return 0;
            }
            
            return _stack.Pop();
        }

        public int Peek()
        {
            return _stack.Peek();
        }

        public bool IsEmpty()
        {
            return _stack.Count == 0;
        }
    }
}