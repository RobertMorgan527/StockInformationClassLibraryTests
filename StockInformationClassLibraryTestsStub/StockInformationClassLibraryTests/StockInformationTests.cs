using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace StockInformationClassLibrary.Tests
{
    [TestClass()]
    public class StockInformationTests
    {
        readonly int validId = 36;
        readonly StockInformation validSi = new StockInformation(36, new QADatabaseStub());

        [TestMethod()]
        public void isValidCompanyIDTestForValidId()
        {
            Assert.AreEqual(true, validSi.isValidCompanyID(validId));
        }
        [TestMethod()]
        public void isValidCompanyIDTestForIDLessThan1()
        {
            Assert.ThrowsException<ArgumentException>(() => new StockInformation(0, new QADatabaseStub()));
        }
        [TestMethod()]
        public void isValidCompanyIDTestForIDMoreThan100()
        {
            Assert.ThrowsException<ArgumentException>(() => new StockInformation(101, new QADatabaseStub()));
        }
        [TestMethod()]
        public void loginTestForInvalidUsername()
        {
            Assert.ThrowsException<ArgumentException>(() => validSi.login("username", "Robert123"));
        }
        [TestMethod()]
        public void loginTestForInvalidPassword()
        {
            Assert.ThrowsException<ArgumentException>(() => validSi.login("Robert", "password"));
        }
        [TestMethod()]
        public void loginTestForInvalidUsernameAndPassword()
        {
            Assert.ThrowsException<ArgumentException>(() => validSi.login("username", "password"));
        }


    }
}