using CC.Domain.Contract;
using CC.Domain.Model;
using System;

namespace CC.Domain.Impl
{
    public class CubePositionService : ICubePositionService
    {
        public bool IsInside(Cube innerCube, Cube outerCube)
        {
            return (innerCube.MinimumXPoint > outerCube.MinimumXPoint && innerCube.MaximumXPoint < outerCube.MaximumXPoint)
                && (innerCube.MinimumYPoint > outerCube.MinimumYPoint && innerCube.MaximumYPoint < outerCube.MaximumYPoint)
                && (innerCube.MinimumZPoint > outerCube.MinimumZPoint && innerCube.MaximumZPoint < outerCube.MaximumZPoint);
        }

        public double GetOverlapLength(Cube mainCube, Cube otherCube)
        {
            double overlapX = Math.Max(0, Math.Min(mainCube.MaximumXPoint, otherCube.MaximumXPoint) - Math.Max(mainCube.MinimumXPoint, otherCube.MinimumXPoint));
            double overlapY = Math.Max(0, Math.Min(mainCube.MaximumYPoint, otherCube.MaximumYPoint) - Math.Max(mainCube.MinimumYPoint, otherCube.MinimumYPoint));
            double overlapZ = Math.Max(0, Math.Min(mainCube.MaximumZPoint, otherCube.MaximumZPoint) - Math.Max(mainCube.MinimumZPoint, otherCube.MinimumZPoint));

            double overlapVolume = overlapX * overlapY * overlapZ;

            return Math.Pow(overlapVolume, 1.0 / 3.0);
        }
    }
}
