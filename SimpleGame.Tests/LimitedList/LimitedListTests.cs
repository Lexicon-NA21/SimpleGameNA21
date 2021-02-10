using LimitedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGame.Tests.LimitedList
{
    [TestClass]
    public class LimitedListTests
    {
        private LimitedList<int> list;
        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void ClassSetUp(TestContext context)
        {
            //Once / class
        }

        [TestInitialize]
        public void SetUp()
        {
            if (TestContext.TestName.EndsWith('0'))
                list = new LimitedList<int>(0);
            else
                list = new LimitedList<int>(6);
        }

        [TestMethod]
        [Owner("Kalle")]
        [Priority(1)]
        [TestCategory("V1")]
        [Timeout(1000)]
        [Description("Blaha blaha")]
       // [Ignore]
        public void Add_WithZeroCapasity_0()
        {
            //Arrange
            const int expected = 0;
            //var list = new LimitedList<int>(expected);

            //Act
            var tryToAdd = list.Add(1);
            int count = list.Count;
            var actual = list.Capacity;

            //Assert
            Assert.IsFalse(tryToAdd);
            Assert.AreEqual(count, expected);
            Assert.AreEqual(actual, expected);

        }  
        
        
        [TestMethod]
        public void Add_WithNegativeCapacity_CreatesListWithZeroCapacity()
        {
            //Arrange
            const int expected = 0;
            const int capacity = -10;
            var list = new LimitedList<int>(capacity);

            //Act
            var tryToAdd = list.Add(1);
            int count = list.Count;
            var actual = list.Capacity;

            //Assert
            Assert.IsFalse(tryToAdd);
            Assert.AreEqual(count, expected);
            Assert.AreEqual(actual, expected);
        
        }





        [TestCleanup]
        public void CleanUp()
        {
            list = null;
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            //Clean resources
        }
    }
}
