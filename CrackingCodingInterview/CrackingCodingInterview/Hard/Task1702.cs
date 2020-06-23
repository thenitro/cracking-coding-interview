using System;

namespace CrackingCodingInterview.Hard
{
    public class Task1702
    {
        public Task1702()
        {
            Console.WriteLine(string.Join(",", Solution(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })));
        }
        
        private int[] Solution(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                Swap(i, new Random().Next(i), array);
            }
            
            return array;
        }

        private void Swap(int a, int b, int[] array)
        {
            var tmp = array[a];
            array[a] = array[b];
            array[b] = tmp;
        }
    }
}