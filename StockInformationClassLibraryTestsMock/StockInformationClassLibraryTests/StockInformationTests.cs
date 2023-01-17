using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace StockInformationClassLibrary.Tests
{
    [TestClass()]
    public class StockInformationTests
    {
        readonly int validId = 36;
        IQADatabase moqDb;
        StockInformation validSi; 

        [TestInitialize]
        public void Initialize()
        {
            var moqDatabase = new Mock<IQADatabase>();
            moqDatabase.Setup(x => x.getUsernames()).Returns(new List<string>
            {
            "Daniel","Michal","Nathaniel","Wilshire",
            "Nicholas","Steven","Alexander","Robert",
            "Thomas","Sree","David","Darren"
            });
            moqDatabase.Setup(x => x.getPasswords()).Returns(new List<string>
            {
            "Daniel123","Michal123","Nathaniel123","Wilshire123",
            "Nicholas123","Steven123","Alexander123","Robert123",
            "Thomas123","Sree123","David123","Darren123"
            });
            moqDatabase.Setup(x => x.getCompanyIds()).Returns(new List<int>
            {
            1, 4, 5, 9, 12, 16, 25, 30, 36, 40, 49, 64, 81, 99
            });
            moqDb = moqDatabase.Object;
            validSi = new StockInformation(validId, moqDb);
        }

        [TestMethod()]
        public void isValidCompanyIDTestForValidId()
        {
            Assert.AreEqual(true, validSi.isValidCompanyID(validId));
        }
        [TestMethod()]
        public void isValidCompanyIDTestForIDLessThan1()
        {
            Assert.ThrowsException<ArgumentException>(() => new StockInformation(0, moqDb));
        }
        [TestMethod()]
        public void isValidCompanyIDTestForIDMoreThan100()
        {
            Assert.ThrowsException<ArgumentException>(() => new StockInformation(101, moqDb));
        }
        [TestMethod()]
        public void loginTestForInvalidUsername()
        {
            Assert.ThrowsException<ArgumentException>(() => validSi.login("username", "Robert123",moqDb));
        }
        [TestMethod()]
        public void loginTestForInvalidPassword()
        {
            Assert.ThrowsException<ArgumentException>(() => validSi.login("Robert", "password",moqDb));
        }
        [TestMethod()]
        public void loginTestForInvalidUsernameAndPassword()
        {
            Assert.ThrowsException<ArgumentException>(() => validSi.login("username", "password", moqDb));
        }


    }
}