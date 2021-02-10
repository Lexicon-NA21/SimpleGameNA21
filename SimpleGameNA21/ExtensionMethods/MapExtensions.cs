using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGameNA21
{
    public static class MapExtensions
    {
        private static readonly IGetMapSize _default = new GetMapSize();

        public static IGetMapSize Implementation {private get; set; } = _default;

        public static void Reset() => Implementation = _default;
        public static int GetMapSizeFor(this IConfiguration config, string name)
        {
            return Implementation.GetMapSizeFor(config, name);
        }
    }

    public class GetMapSize : IGetMapSize
    {
        public int GetMapSizeFor(IConfiguration config, string name)
        {
            var section = config.GetSection("consolegame:mapsettings");
            return int.TryParse(section[name], out int result) ? result : 0;
        }

    }

    public interface IGetMapSize
    {
        int GetMapSizeFor(IConfiguration config, string name);
    }


}
