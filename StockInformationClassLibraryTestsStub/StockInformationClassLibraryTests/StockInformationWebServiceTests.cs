using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace StockInformationClassLibrary.Tests
{
    [TestClass()]
    public class StockInformationWebServiceTestsReal
    {
        [TestMethod()]
        public void getStockLevelTestForValidated()
        {
            int companyId = 36;
            StockInformation si = new StockInformation(companyId,new QADatabaseStub());
            si.login("Robert", "Robert123");
            int stockLevel = si.getStockLevel(companyId);
            Assert.AreEqual(0, stockLevel);
        }
        [TestMethod()]
        public void getStockLevelTestForNotValidated()
        {
            int companyId = 36;
            StockInformation si = new StockInformation(companyId, new QADatabaseStub());
            int stockLevel = si.getStockLevel(companyId);
            Assert.AreEqual(-1, stockLevel);
        }
    }
}