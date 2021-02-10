using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleGameNA21;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGame.Tests.Map
{
    [TestClass]
   public class MapTests
    {
        private MapSettings settings;

        [TestInitialize]
        public void Init()
        {
            settings = new MapSettings()
            {
                X = 10,
                Y = 10
            };
        }

        [TestMethod]
        public void Map_GetCorrectWidth_IOption()
        {
            var expected = 10;
            IOptions<MapSettings> options = Options.Create(settings);
            var map = new ConsoleMap(options);

            var actual = map.Width;

            Assert.AreEqual(expected, actual);

        }
    }
}
