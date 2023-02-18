using CC.Domain.Model;

namespace CC.Domain.Contract
{
    public interface ICubePositionService
    {
        bool IsInside(Cube innerCube, Cube outerCube);
        double GetOverlapLength(Cube cube1, Cube cube2);
    }
}
