using System;

namespace CrackingCodingInterview.SortingAndSearching
{
    public class Task1011
    {
        public Task1011()
        {
            Console.WriteLine(string.Join(",", Solution(new []{ 5, 3, 1, 2, 3 })));
        }

        private int[] Solution(int[] array)
        {
            for (var i = 1; i < array.Length; i += 2)
            {
                var index = MaxIndex(array, i - 1, i , i + 1);
                if (index == i)
                {
                    continue;
                }

                Swap(array, i, index);
            }

            return array;
        }

        private int MaxIndex(int[] array, int a, int b, int c)
        {
            var aValue = a >= 0 && a < array.Length ? array[a] : int.MinValue;
            var bValue = b >= 0 && b < array.Length ? array[b] : int.MinValue;
            var cValue = c >= 0 && c < array.Length ? array[c] : int.MinValue;

            var max = Math.Max(aValue, Math.Max(bValue, cValue));
            if (max == aValue)
            {
                return a;
            }
            
            if (max == bValue)
            {
                return b;
            }

            return c;
        }

        private void Swap(int[] array, int a, int b)
        {
            var tmp = array[a];
            array[a] = array[b];
            array[b] = tmp;
        }
    }
}