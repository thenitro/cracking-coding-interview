using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.Moderate
{
    public class Task1625
    {
        public Task1625()
        {
            var cache = new LruCache(5);
            
            cache.SetKeyValue(1, "a");
            cache.SetKeyValue(2, "b");
            cache.SetKeyValue(3, "c");
            cache.SetKeyValue(4, "d");
            cache.SetKeyValue(5, "e");

            Console.WriteLine(cache.GetValue(1));
            Console.WriteLine(cache.GetValue(2));
            Console.WriteLine(cache.GetValue(3));
            Console.WriteLine(cache.GetValue(4));
            
            cache.SetKeyValue(6, "g");

            Console.WriteLine(null == cache.GetValue(5));
        }
    }

    public class LruCache
    {
        private int _maxSize;
        private Dictionary<int, Node> _map;
        private Node _head;
        private Node _tail;

        public LruCache(int maxSize)
        {
            _maxSize = maxSize;
            _map = new Dictionary<int, Node>();
        }

        public string GetValue(int key)
        {
            if (!_map.ContainsKey(key))
            {
                return null;
            }

            var item = _map[key];
            if (item != _head)
            {
                RemoveFromLinkedList(item);
                InsertAtFrontOfLinkedList(item);
            }

            return item.Value;
        }

        private void RemoveFromLinkedList(Node node)
        {
            if (node == null)
            {
                return;
            }

            if (node.Prev != null)
            {
                node.Prev.Next = node.Next;
            }

            if (node.Next != null)
            {
                node.Next.Prev = node.Prev;
            }

            if (node == _tail)
            {
                _tail = node.Prev;
            }

            if (node == _head)
            {
                _head = node.Next;
            }
        }

        private void InsertAtFrontOfLinkedList(Node node)
        {
            if (_head == null)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                _head.Prev = node;
                node.Next = _head;
                _head = node;
            }
        }

        public bool RemoveKey(int key)
        {
            if (!_map.ContainsKey(key))
            {
                return false;
            }
            
            var node = _map[key];
            RemoveFromLinkedList(node);
            _map.Remove(key);
            return true;
        }

        public void SetKeyValue(int key, string value)
        {
            RemoveKey(key);

            if (_map.Count >= _maxSize && _tail != null)
            {
                RemoveKey(_tail.Key);
            }

            var node = new Node(key, value);
            InsertAtFrontOfLinkedList(node);
            _map.Add(key, node);
        }

        private class Node
        {
            public Node Next;
            public Node Prev;

            public int Key;
            public string Value;
            
            public Node(int key, string value)
            {
                Key = key;
                Value = value;
            }
        }
    }
}