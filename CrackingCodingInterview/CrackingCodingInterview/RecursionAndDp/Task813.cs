using System;

namespace CrackingCodingInterview.RecursionAndDp
{
    public class Task813
    {
        public Task813()
        {
            Console.WriteLine(25 == Solution(new []
            {
                new Box()
                {
                    Width = 10,
                    Height = 10,
                    Depth = 10,
                },
                new Box()
                {
                    Width = 15,
                    Height = 15,
                    Depth = 15,
                },
            }));
            
            Console.WriteLine(30 == Solution(new []
            {
                new Box()
                {
                    Width = 10,
                    Height = 10,
                    Depth = 10,
                },
                new Box()
                {
                    Width = 15,
                    Height = 15,
                    Depth = 15,
                },
                new Box()
                {
                    Width = 10,
                    Height = 30,
                    Depth = 30,
                },
            }));
            
            Console.WriteLine(55 == Solution(new []
            {
                new Box()
                {
                    Width = 10,
                    Height = 10,
                    Depth = 10,
                },
                new Box()
                {
                    Width = 15,
                    Height = 45,
                    Depth = 15,
                },
                new Box()
                {
                    Width = 10,
                    Height = 30,
                    Depth = 30,
                },
                new Box()
                {
                    Width = 10,
                    Height = 5,
                    Depth = 30,
                },
            }));
        }

        private int Solution(Box[] boxes)
        {
            Array.Sort(boxes, (box, box1) => box1.Dimensions.CompareTo(box.Dimensions));
            
            var result = 0;
            var dp = new int[boxes.Length];

            for (var i = boxes.Length; i >= 0; i--)
            {
                result = Math.Max(result, StackBox(i, boxes, dp));
            }
            
            return result;
        }

        private int StackBox(int index, Box[] boxes, int[] dp)
        {
            if (index >= boxes.Length)
            {
                return 0;
            }

            if (dp[index] != 0)
            {
                return dp[index];
            }

            var height = 0;

            for (var i = index + 1; i < boxes.Length; i++)
            {
                if (CanStack(boxes[index], boxes[i]))
                {
                    height = Math.Max(height, StackBox(i, boxes, dp));
                }
            }

            dp[index] = height + boxes[index].Height;

            return dp[index];
        }

        private bool CanStack(Box onto, Box on)
        {
            if (on.Width >= onto.Width ||
                on.Height >= onto.Height ||
                on.Depth >= onto.Depth)
            {
                return false;
            }

            return true;
        }
        
        private struct Box
        {
            public int Width;
            public int Height;
            public int Depth;

            public int Dimensions => Width * Height * Depth;
        }
    }
}