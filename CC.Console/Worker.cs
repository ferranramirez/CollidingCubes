using CC.Domain.Contract;
using CC.Domain.Model;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace CC.Console
{
    public class Worker : BackgroundService
    {
        private readonly IHost _host;
        public ICubeService _cubeService;
        public ICubeFactory _cubeFactory;

        public Worker(IHost host, ICubeService cubeService, ICubeFactory cubeFactory)
        {
            _host = host;
            _cubeService = cubeService;
            _cubeFactory = cubeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            System.Console.WriteLine("Enter the dimensions for the first cube:");
            System.Console.WriteLine("Dimension X:");
            double.TryParse(System.Console.ReadLine(), out double x);

            System.Console.WriteLine("Dimension Y:");
            double.TryParse(System.Console.ReadLine(), out double y);

            System.Console.WriteLine("Dimension Z:");
            double.TryParse(System.Console.ReadLine(), out double z);

            System.Console.WriteLine("Cube side length:");
            double.TryParse(System.Console.ReadLine(), out double sideLength);

            var cube1 = _cubeFactory.Create(center: new Point(x, y, z), sideLength);

            System.Console.WriteLine("Enter the dimensions for the second cube:");
            System.Console.WriteLine("Dimension X:");
            double.TryParse(System.Console.ReadLine(), out x);

            System.Console.WriteLine("Dimension Y:");
            double.TryParse(System.Console.ReadLine(), out y);

            System.Console.WriteLine("Dimension Z:");
            double.TryParse(System.Console.ReadLine(), out z);

            System.Console.WriteLine("Cube side length:");
            double.TryParse(System.Console.ReadLine(), out sideLength);

            var cube2 = _cubeFactory.Create(center: new Point(x, y, z), sideLength);

            if (_cubeService.DoIntersect(cube1, cube2))
            {
                var volume = _cubeService.IntersectionVolume(cube1, cube2);
                System.Console.WriteLine(string.Concat("The cubes intersect with each other. The intersected volume is ", volume, "."));


            }
            else
            {
                System.Console.WriteLine("There is NO intersection between the cubes.");
            }

            System.Console.ReadLine();
            await _host.StopAsync();
        }
    }
}
