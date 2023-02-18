using CC.Domain.Model;

namespace CC.Domain.Contract
{
    public interface ICubeService
    {
        public bool DoIntersect(Cube cube1, Cube cube2);
        double IntersectionVolume(Cube cube1, Cube cube2);
    }
}