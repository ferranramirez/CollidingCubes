using CC.Domain.Contract;
using CC.Domain.Impl;
using CC.Domain.Model;
using Xunit;

namespace CC.Domain.UnitTest
{
    public class CubeFactoryTest
    {
        private ICubeFactory _cubeFactory;

        public CubeFactoryTest()
        {
            _cubeFactory = new CubeFactory();
        }

        [Fact]
        public void CubeCreation()
        {
            // Arrange
            var center = new Point(0, 0, 0);
            var sideLength = 2;

            // Act
            var cube = _cubeFactory.Create(center, sideLength);

            // Assert
            Assert.NotNull(cube);
            Assert.Equal(center, cube.Center);
            Assert.Equal(sideLength, cube.SideLength);
        }
    }
}
