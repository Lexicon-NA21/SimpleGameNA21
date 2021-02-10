using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGameNA21.Services
{
    public class MapService : IMapService
    {
        private readonly IConfiguration config;

        public MapService(IConfiguration config)
        {
            this.config = config;
        }

        public (int width, int height) GetMap()
        {
            return (width: config.GetMapSizeFor("X"), height: config.GetMapSizeFor("Y"));
        }
    }
}
