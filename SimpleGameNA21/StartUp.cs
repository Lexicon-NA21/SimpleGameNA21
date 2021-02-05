using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

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

        private void ConfigureServices(ServiceCollection services)
        {
            IConfiguration config = GetConfig();

            services.AddSingleton(config);
            services.AddSingleton<IMap, ConsoleMap>();
            services.AddSingleton<Game>();

            var ui = config.GetSection("consolegame:ui").Value;

            switch (ui)
            {
                case "console":
                    services.AddSingleton<IUI, ConsoleUI>();
                    break;
                    //Add more options here...
                default:
                    break;
            }
        }

        private IConfiguration GetConfig()
        {
            return new ConfigurationBuilder()
                                .SetBasePath(Environment.CurrentDirectory)
                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                .Build();
        }
    }
}