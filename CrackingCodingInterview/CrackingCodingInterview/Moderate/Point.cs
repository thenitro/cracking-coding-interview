namespace CrackingCodingInterview.Moderate
{
    public class Point
    {
        public double X;
        public double Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public void SetLocation(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"[ Point x={X}, y={Y} ]";
        }
    }
}