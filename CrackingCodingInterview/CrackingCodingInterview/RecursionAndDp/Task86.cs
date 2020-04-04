using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.RecursionAndDp
{
    public class Task86
    {
        public Task86()
        {
            var n = 3;
            var towers = new Tower[n];

            for (var i = 0; i < 3; i++)
            {
                towers[i] = new Tower(i);
            }

            for (var i = n - 1; i >= 0; i--)
            {
                towers[0].Add(i);
            }

            towers[0].MoveDisks(n, towers[2], towers[1]);
        }
    }

    public class Tower
    {
        public int Index { get; private set; }
        private Stack<int> _disks;

        public Tower(int i)
        {
            _disks = new Stack<int>();
            Index = i;
        }

        public void Add(int d)
        {
            if (_disks.Count != 0 && _disks.Peek() <= d)
            {
                Console.WriteLine("Error placing disk {0}", d);
            }
            else
            {
                _disks.Push(d);
            }
        }

        public void MoveTopTo(Tower t)
        {
            var top = _disks.Pop();
            t.Add(top);
        }

        public void MoveDisks(int n, Tower destination, Tower buffer)
        {
            if (n > 0)
            {
                MoveDisks(n - 1, buffer, destination);
                MoveTopTo(destination);
                buffer.MoveDisks(n - 1, destination, this);
            }
        }
    }
}