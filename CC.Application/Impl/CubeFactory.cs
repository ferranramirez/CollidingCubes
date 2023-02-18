using CC.Domain.Contract;
using CC.Domain.Model;
using System;

namespace CC.Domain.Impl
{
    public class CubeFactory : ICubeFactory
    {
        public Cube Create(Point center, double sideLength)
        {
            if (sideLength <= 0)
            {
                throw new ArgumentException("Side length must be greater than 0.");
            }

            if (center == null)
            {
                throw new ArgumentNullException(nameof(center));
            }

            if (double.IsInfinity(center.X) || double.IsInfinity(center.Y) || double.IsInfinity(center.Z))
            {
                throw new ArgumentException("Center point coordinates must not be infinity.");
            }

            return new Cube(center, sideLength);
        }
    }
}
