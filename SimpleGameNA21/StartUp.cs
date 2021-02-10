using LimitedList;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleGameNA21.Services;
using System;
using System.Runtime.CompilerServices;

//[assembly:InternalsVisibleTo("SimpleGame.Tests")]
namespace SimpleGameNA21
{
    internal class StartUp
    {
        internal void SetUp()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetService<Game>().Run();
        }

        internal void ConfigureServices(ServiceCollection services)
        {
            IConfiguration config = GetConfig();

            services.AddSingleton(config);
            services.AddSingleton<IMap, ConsoleMap>();
            services.AddSingleton<IMapService, MapService>();
            services.AddSingleton<Game>();
            services.AddUI(config);
            services.AddSingleton<ILimitedList<string>>(s => new MessageLog<string>(6));

            // var mapSettings = config.GetSection("consolegame:mapsettings").Get<MapSettings>();
            services.Configure<MapSettings>(config.GetSection("consolegame:mapsettings").Bind);
        }

        private IConfiguration GetConfig()
        {
            return new ConfigurationBuilder()
                                .SetBasePath(Environment.CurrentDirectory)
                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                .Build();
        }

        public void ThrowException()
        {
            throw new ArgumentException();
        }
    }
}