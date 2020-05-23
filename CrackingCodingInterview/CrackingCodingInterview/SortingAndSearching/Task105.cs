using System;

namespace CrackingCodingInterview.SortingAndSearching
{
    public class Task105
    {
        public Task105()
        {
            Console.WriteLine(4 == Solution(new []{"at", "", "", "", "ball", "", "", "car", "", "", "dad", "", ""}, "ball"));
            Console.WriteLine(0 == Solution(new []{"at", "", "", "", "ball", "", "", "car", "", "", "dad", "", ""}, "at"));
            Console.WriteLine(7 == Solution(new []{"at", "", "", "", "ball", "", "", "car", "", "", "dad", "", ""}, "car"));
            Console.WriteLine(10 == Solution(new []{"at", "", "", "", "ball", "", "", "car", "", "", "dad", "", ""}, "dad"));
        }

        private int Solution(string[] arr, string value)
        {
            var lo = ClosestNonEmpty(0, 1, arr);
            var hi = ClosestNonEmpty(arr.Length - 1, -1, arr);

            while (lo <= hi)
            {
                var midL = (hi + lo) / 2;
                var midR = (hi + lo) / 2;

                while (string.IsNullOrEmpty(arr[midL]) && string.IsNullOrEmpty(arr[midR]))
                {
                    midL--;
                    midR++;
                }

                var mid = string.IsNullOrEmpty(arr[midL]) ? midR : midL;

                if (arr[mid].CompareTo(value) == 1)
                {
                    hi = ClosestNonEmpty(mid - 1, -1, arr);
                } else if (arr[mid].CompareTo(value) == -1)
                {
                    lo = ClosestNonEmpty(mid + 1, 1, arr);
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }

        private int ClosestNonEmpty(int index, int increment, string[] arr)
        {
            while (string.IsNullOrEmpty(arr[index]))
            {
                index += increment;
            }
            
            return index;
        }
    }
}