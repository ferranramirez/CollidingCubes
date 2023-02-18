using CC.Domain.Contract;
using CC.Domain.Impl;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CC.Console
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>()
                            .AddScoped<ICubeService, CubeService>()
                            .AddScoped<ICubePositionService, CubePositionService>()
                            .AddScoped<ICubeFactory, CubeFactory>();
                });
    }
}
