
using CC.Domain.Contract;
using CC.Domain.Model;
using System;

namespace CC.Domain.Impl
{
    public class CubeService : ICubeService
    {
        private ICubePositionService _cubePositionService;

        public CubeService(ICubePositionService cubePositionService)
        {
            _cubePositionService = cubePositionService;
        }

        public bool DoIntersect(Cube cube1, Cube cube2)
        {
            double distanceX = Math.Abs(cube1.Center.X - cube2.Center.X);
            double distanceY = Math.Abs(cube1.Center.Y - cube2.Center.Y);
            double distanceZ = Math.Abs(cube1.Center.Z - cube2.Center.Z);

            return distanceX < cube1.HalfSideLength + cube2.HalfSideLength &&
                distanceY < cube1.HalfSideLength + cube2.HalfSideLength &&
                distanceZ < cube1.HalfSideLength + cube2.HalfSideLength;
        }

        public double IntersectionVolume(Cube cube1, Cube cube2)
        {
            double overlapLength = _cubePositionService.GetOverlapLength(cube1, cube2);

            if (overlapLength <= 0)
            {
                return 0;
            }

            if (cube1.SideLength >= cube2.SideLength && _cubePositionService.IsInside(cube2, cube1))
            {
                return cube2.SideLength * cube2.SideLength * cube2.SideLength;
            }
            else if (cube2.SideLength >= cube1.SideLength && _cubePositionService.IsInside(cube1, cube2))
            {
                return cube1.SideLength * cube1.SideLength * cube1.SideLength;
            }
            else
            {
                return Math.Pow(overlapLength, 3);
            }
        }

    }
}
