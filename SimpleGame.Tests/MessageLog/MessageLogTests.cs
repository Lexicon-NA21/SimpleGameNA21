using LimitedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGame.Tests.MessageLog
{
    [TestClass]
   public class MessageLogTests
    {
        [TestMethod]
        public void Add_ShouldRemoveFirstWhenFull()
        {
            //Arrenge
            const string first = "First";
            const string second = "Second";
            const string tryAdd = "TryToAdd";
            var messageLog = new MessageLog<string>(2)
            {
                first,
                second
            };

            //Act
            var expected = messageLog.Add(tryAdd);

            //Assert
            Assert.IsTrue(expected);
            Assert.AreSame(messageLog[0], second);
            Assert.AreNotSame(messageLog[0], first);
            
        }
    }
}
