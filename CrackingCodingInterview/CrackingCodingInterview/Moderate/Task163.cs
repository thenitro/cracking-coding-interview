using System;

namespace CrackingCodingInterview.Moderate
{
    public class Task163
    {
        public Task163()
        {
            Console.WriteLine(Solution(new Point(0, 6), new Point(10, 5), new Point(6, 0), new Point(5, 10)));
        }

        private Point Solution(Point start1, Point end1, Point start2, Point end2)
        {
            Console.WriteLine($"before {start1}, {end1}, {start2}, {end2}");
            
            if (start1.X > end1.X)
            {
                Swap(start1, end1);
            }

            if (start2.X > end2.X)
            {
                Swap(start2, end2);
            }

            if (start1.X > start2.X)
            {
                Swap(start1, start2);
                Swap(end1, end2);
            }

            Console.WriteLine($"after {start1}, {end1}, {start2}, {end2}");

            var line1 = new Line(start1, end1);
            var line2 = new Line(start2, end2);

            Console.WriteLine($"Slopes {line1.Slope} {line2.Slope}");

            if (line1.Slope == line2.Slope)
            {
                if (line1.InterceptY == line2.InterceptY &&
                    IsBetween(start1, start2, end1))
                {
                    return start2;
                }

                return null;
            }
            
            var x = (line2.InterceptY - line1.InterceptY) / (line1.Slope - line2.Slope);
            var y = x * line1.Slope + line1.InterceptY;
            
            var intersection = new Point(x, y);

            if (IsBetween(start1, intersection, end1) &&
                IsBetween(start2, intersection, end2))
            {
                return intersection;
            }

            return null;
        }

        private bool IsBetween(Point start, Point middle, Point end)
        {
            return IsBetween(start.X, middle.X, end.X) &&
                   IsBetween(start.Y, middle.Y, end.Y);
        }

        private bool IsBetween(double start, double middle, double end)
        {
            if (start > end)
            {
                return end <= middle && middle <= start;
            }

            return start <= middle && middle <= end;
        }

        private void Swap(Point a, Point b)
        {
            var tmpX = a.X;
            var tmpY = a.Y;
            
            a.SetLocation(b.X, b.Y);
            b.SetLocation(tmpX, tmpY);
        }
    }
}