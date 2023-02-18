using CC.Domain.Model;

namespace CC.Domain.Contract
{
    public interface ICubeFactory
    {
        Cube Create(Point center, double sideLength);
    }
}
