using System;

namespace CrackingCodingInterview.Hard
{
    public class Task1716
    {
        public Task1716()
        {
            Console.WriteLine(180 == Solution(new [] { 30, 15, 60, 75, 45, 15, 15, 45 }));
        }

        private int Solution(int[] array)
        {
            return Math.Max(Helper(array, true, 0, 0), Helper(array, false, 0, 0));
        }

        private int Helper(int[] array, bool take, int index, int sum)
        {
            if (index >= array.Length)
            {
                return sum;
            }

            return
                Math.Max(
                    Helper(array, true, take ? index + 2 : index + 1, take ? sum + array[index] : sum),
                    Helper(array, false, take ? index + 2 : index + 1, take ? sum + array[index] : sum));
        }
    }
}