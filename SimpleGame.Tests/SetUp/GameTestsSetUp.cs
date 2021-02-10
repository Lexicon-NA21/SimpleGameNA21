using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGame.Tests.SetUp
{
    [TestClass]
    public class GameTestsSetUp
    {
        [AssemblyInitialize]
        public static void GameSetUp(TestContext context)
        {
            //Starts here
        }



        [AssemblyCleanup]
        public static void GameCleanUp()
        {
            //Clean up
        }
    }
}
