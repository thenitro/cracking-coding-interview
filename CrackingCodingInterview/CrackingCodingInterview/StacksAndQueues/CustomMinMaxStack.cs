using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CrackingCodingInterview.StacksAndQueues
{
    public class CustomMinMaxStack
    {
        private List<Tuple<int, int>> _list = new List<Tuple<int, int>>();

        private int _min = int.MaxValue;
        private int _max = int.MinValue;

        public int Peek()
        {
            if (_list.Count == 0)
            {
                return 0;
            }
            
            return _list[_list.Count - 1].Item1;
        }

        public void Push(int item)
        {
            if (item > _max)
            {
                _max = item;
            }
            
            var tuple = new Tuple<int, int>(item, _min);
            
            if (item < _min)
            {
                _min = item;
            }
            
            _list.Add(tuple);
        }

        public int Pop()
        {
            if (_list.Count == 0)
            {
                return 0;
            }
            
            var item = _list[_list.Count - 1];

            _list.RemoveAt(_list.Count - 1);
            _min = item.Item2;
            
            return item.Item1;
        }

        public int Min()
        {
            if (_list.Count == 0)
            {
                return 0;
            }
            
            return _min;
        }
        
        public int Max()
        {
            if (_list.Count == 0)
            {
                return 0;
            }
            
            return _max;
        }
    }
}