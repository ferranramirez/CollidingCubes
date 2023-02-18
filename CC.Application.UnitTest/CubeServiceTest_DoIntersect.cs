using CC.Domain.Contract;
using CC.Domain.Impl;
using CC.Domain.Model;
using Moq;
using Xunit;

namespace CC.Domain.UnitTest
{
    public class CubeServiceTest_DoIntersect
    {
        private ICubeFactory _cubeFactory;
        private ICubeService _collisionService;
        private Mock<ICubePositionService> _cubePositionServiceMock;

        public CubeServiceTest_DoIntersect()
        {
            _cubeFactory = new CubeFactory();
            _cubePositionServiceMock = new Mock<ICubePositionService>();
            _collisionService = new CubeService(_cubePositionServiceMock.Object);
        }

        [Fact]
        public void DoIntersect_WhenCubesIntersect_ShouldReturnTrue()
        {
            // Arrange
            var cube1 = _cubeFactory.Create(center: new Point(0, 0, 0), sideLength: 2);
            var cube2 = _cubeFactory.Create(center: new Point(1, 1, 1), sideLength: 2);

            // Act
            bool doIntersect = _collisionService.DoIntersect(cube1, cube2);

            // Assert
            Assert.True(doIntersect);
        }

        [Fact]
        public void DoIntersect_WhenCubesDoNotIntersect_ShouldReturnFalse()
        {
            // Arrange
            var cube1 = _cubeFactory.Create(center: new Point(0, 0, 0), sideLength: 2);
            var cube2 = _cubeFactory.Create(center: new Point(3, 3, 3), sideLength: 2);

            // Act
            bool doIntersect = _collisionService.DoIntersect(cube1, cube2);

            // Assert
            Assert.False(doIntersect);
        }

        [Fact]
        public void DoIntersect_WhenCubesOverlap_ShouldReturnTrue()
        {
            // Arrange
            var cube1 = _cubeFactory.Create(center: new Point(0, 0, 0), sideLength: 2);
            var cube2 = _cubeFactory.Create(center: new Point(1, 1, 1), sideLength: 3);

            // Act
            bool doIntersect = _collisionService.DoIntersect(cube1, cube2);

            // Assert
            Assert.True(doIntersect);
        }

        [Fact]
        public void DoIntersect_WhenOneCubeIsInsideTheOther_ShouldReturnTrue()
        {
            // Arrange
            var cube1 = _cubeFactory.Create(new Point(0, 0, 0), 4);
            var cube2 = _cubeFactory.Create(new Point(0, 0, 0), 2);

            // Act
            bool doIntersect = _collisionService.DoIntersect(cube1, cube2);

            // Assert
            Assert.True(doIntersect);
        }

    }
}
