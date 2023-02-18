namespace CC.Domain.Model
{
    public class Cube
    {
        public Point Center;
        public double SideLength;

        public Cube(Point center, double sideLength)
        {
            Center = center;
            SideLength = sideLength;
        }

        public double HalfSideLength => SideLength / 2;

        public double MinimumXPoint => MinimumPoint(Center.X);
        public double MaximumXPoint => MaximumPoint(Center.X);

        public double MinimumYPoint => MinimumPoint(Center.Y);
        public double MaximumYPoint => MaximumPoint(Center.Y);

        public double MinimumZPoint => MinimumPoint(Center.Z);
        public double MaximumZPoint => MaximumPoint(Center.Z);


        private double MinimumPoint(double point) => point - HalfSideLength;
        private double MaximumPoint(double point) => point + HalfSideLength;
    }
}
