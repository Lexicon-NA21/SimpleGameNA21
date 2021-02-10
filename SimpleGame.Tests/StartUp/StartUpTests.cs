using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using SimpleGameNA21;

namespace SimpleGame.Tests.StartUp
{
    [TestClass]
    public class StartUpTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Ignore]
        public void ExceptionExample()
        {
            try
            {

            }
            catch (ArgumentNullException)
            {
                return;
               
            }
        }

        [TestMethod]
        public void StartUp_CreatesCorrectInstanseOfMap()
        {
            var serviceCollection = new ServiceCollection();
            var startUp = new SimpleGameNA21.StartUp();
            startUp.ConfigureServices(serviceCollection);
            var provider = serviceCollection.BuildServiceProvider();

            var map = provider.GetRequiredService<IMap>();

            Assert.IsInstanceOfType(map, typeof(ConsoleMap));
        }

    }
}
