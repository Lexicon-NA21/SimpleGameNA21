using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SimpleGameNA21;
using SimpleGameNA21.DelegateExample;
using SimpleGameNA21.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGame.Tests.Map
{
    [TestClass]
   public class MapTests
    {

        [TestInitialize]
        public void Init()
        {
          
        }

        [TestMethod]
        public void Map_GetCorrectWidth_IOption()
        {
            //var expected = 10;
            //var settings = new MapSettings { X = 10, Y = 10 };
            //IOptions<MapSettings> options = Options.Create(settings);
            //var map = new ConsoleMap(options);

            //var actual = map.Width;

            //Assert.AreEqual(expected, actual);
        }
         
        [TestMethod]
        public void Map_GetCorrectWidth_IMapSErvice()
        {
            //var expected = 10;
            //var mapServiceMock = new Mock<IMapService>();
            //mapServiceMock.Setup(s => s.GetMap()).Returns((expected, expected));
            //var map = new ConsoleMap(mapServiceMock.Object);

            //var actual = map.Width;

            //Assert.AreEqual(expected, actual);
           
        }
        
        [TestMethod]
        public void Map_GetCorrectWidth_IConfigurationExtension()
        {
            var expected = 10;

            var getMapSizeMock = new Mock<IGetMapSize>();
            var iconfigMock = new Mock<IConfiguration>();

            getMapSizeMock.Setup(m => m.GetMapSizeFor(iconfigMock.Object, It.IsAny<string>())).Returns(expected);

            MapExtensions.Implementation = getMapSizeMock.Object;

            var map = new ConsoleMap(iconfigMock.Object);

            var actual = map.Width;

            Assert.AreEqual(expected, actual);
           
        }

        [TestMethod]
        public void DelegateExample()
        {
            const string expected = "NOTOK";
            var stWrapper = new StaticWrapperDelegateExample(s => !String.IsNullOrEmpty(s));

            var actual = stWrapper.IsTrue(null);

            Assert.AreEqual(expected, actual);

        }



    [TestCleanup]
        public void TestCleanUp()
        {
        }
    }
}
