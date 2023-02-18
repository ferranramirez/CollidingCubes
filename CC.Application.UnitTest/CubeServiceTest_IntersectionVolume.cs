using CC.Domain.Contract;
using CC.Domain.Impl;
using CC.Domain.Model;
using Moq;
using Xunit;

namespace CC.Domain.UnitTest
{
    public class CubeServiceTest_IntersectionVolume
    {
        private ICubeFactory _cubeFactory;
        private ICubeService _collisionService;
        private Mock<ICubePositionService> _cubePositionServiceMock;

        public CubeServiceTest_IntersectionVolume()
        {
            _cubeFactory = new CubeFactory();
            _cubePositionServiceMock = new Mock<ICubePositionService>();
            _collisionService = new CubeService(_cubePositionServiceMock.Object);

        }

        [Fact]
        public void IntersectionVolume_WhenCubesIntersect_ShouldReturnCorrectVolume()
        {
            // Arrange
            var cube1 = _cubeFactory.Create(center: new Point(0, 0, 0), sideLength: 2);
            var cube2 = _cubeFactory.Create(center: new Point(1, 1, 1), sideLength: 2);
            _cubePositionServiceMock.Setup(cp => cp.IsInside(cube1, cube2)).Returns(false);
            _cubePositionServiceMock.Setup(cp => cp.GetOverlapLength(cube1, cube2)).Returns(1);

            // Act
            double result = _collisionService.IntersectionVolume(cube1, cube2);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void IntersectionVolume_WhenCubesDoNotIntersect_ShouldReturnZero()
        {
            // Arrange
            var cube1 = _cubeFactory.Create(center: new Point(0, 0, 0), sideLength: 2);
            var cube2 = _cubeFactory.Create(center: new Point(3, 3, 3), sideLength: 2);
            _cubePositionServiceMock.Setup(cp => cp.IsInside(cube1, cube2)).Returns(false);
            _cubePositionServiceMock.Setup(cp => cp.GetOverlapLength(cube1, cube2)).Returns(0);

            // Act
            double result = _collisionService.IntersectionVolume(cube1, cube2);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void IntersectionVolume_WhenCubesOverlap_ShouldReturnCorrectVolume()
        {
            // Arrange
            var cube1 = _cubeFactory.Create(center: new Point(0, 0, 0), sideLength: 2);
            var cube2 = _cubeFactory.Create(center: new Point(1, 1, 1), sideLength: 2);
            _cubePositionServiceMock.Setup(cp => cp.IsInside(cube1, cube2)).Returns(false);
            _cubePositionServiceMock.Setup(cp => cp.GetOverlapLength(cube1, cube2)).Returns(1);

            // Act
            double result = _collisionService.IntersectionVolume(cube1, cube2);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void IntersectionVolume_WhenOneCubeIsCompletelyInsideTheOther_ShouldReturnCorrectVolume()
        {
            // Arrange
            var cube1 = _cubeFactory.Create(center: new Point(0, 0, 0), sideLength: 4);
            var cube2 = _cubeFactory.Create(center: new Point(0, 0, 0), sideLength: 2);
            _cubePositionServiceMock.Setup(cp => cp.IsInside(cube1, cube2)).Returns(true);
            _cubePositionServiceMock.Setup(cp => cp.GetOverlapLength(cube1, cube2)).Returns(2);

            // Act
            double result = _collisionService.IntersectionVolume(cube1, cube2);

            // Assert
            Assert.Equal(8, result);
        }
    }
}
