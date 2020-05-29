namespace CrackingCodingInterview.Moderate
{
    public class Line
    {
        public double Slope;
        public double InterceptY;

        public Line(Point start, Point end)
        {
            var deltaX = end.X - start.X;
            var deltaY = end.Y - start.Y;

            Slope = deltaY / deltaX;
            InterceptY = end.Y - Slope * end.X;
        }
    }
}