using System;

namespace CrackingCodingInterview.Hard
{
    public class Task1710
    {
        public Task1710()
        {
            Console.WriteLine(5 == Solution(new [] { 1, 2, 5, 9, 5, 9, 5, 5, 5 }));
            Console.WriteLine(-1 == Solution(new [] { 1, 2, 1, 2, 1, 2, 1, 2}));
        }

        private int Solution(int[] array)
        {
            var value = -1;
            var count = 0;

            for (var i = 0; i < array.Length; i++)
            {
                if (count == 0)
                {
                    value = array[i];
                } 
                
                if (value != array[i])
                {
                    count--;
                }
                else
                {
                    count++;
                }
            }

            return Validate(array, value) ? value : -1;
        }

        private bool Validate(int[] array, int value)
        {
            var count = 0;

            foreach (var i in array)
            {
                if (i == value)
                {
                    count++;
                }
            }

            return count > array.Length / 2;
        }
    }
}