using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace StockInformationClassLibrary.Tests
{
    [TestClass()]
    public class StockInformationWebServiceTestsReal
    {
        readonly int validId = 36;
        StockInformation validSi;
        IQADatabase moqDb;

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
            validSi = new StockInformation(validId, moqDatabase.Object);
        }

        [TestMethod()]
        public void getStockLevelTestForValidated()
        {
            validSi.login("Robert", "Robert123",moqDb);
            int stockLevel = validSi.getStockLevel(validId);
            Assert.AreEqual(0, stockLevel);
        }
        [TestMethod()]
        public void getStockLevelTestForNotValidated()
        {
            int stockLevel = validSi.getStockLevel(validId);
            Assert.AreEqual(-1, stockLevel);
        }
    }
}