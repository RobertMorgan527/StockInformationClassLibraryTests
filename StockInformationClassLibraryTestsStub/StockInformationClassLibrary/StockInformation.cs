using System;
using System.Collections.Generic;

namespace StockInformationClassLibrary
{
    public class StockInformation
    {
        private readonly int companyID;
        private bool validated;
        private readonly List<int> companyIds;

        public StockInformation(int companyID, IQADatabase db)
        {
            this.companyIds = db.getCompanyIds();

            if (!isValidCompanyID(companyID))
            {
                throw new ArgumentException(companyID + " is not a valid company ID");
            }

            this.companyID = companyID;
            this.validated = false;
            

        }

        public void login(string username, string password)
        {
            QASecurity security = new QASecurity(new QADatabaseStub());

            if (!security.login(username, password))
                throw new ArgumentException("Invalid username or password");

            validated = true;
        }

        public int getStockLevel(int id)
        {
            if (!validated)
                return -1;
            StockInformationWebService ws = new StockInformationWebService();
            return ws.getStockLevel(id);
        }

        public bool isValidCompanyID(int companyID)
        {
            if (companyID < 1 || companyID > 100)
            {
                return false;
            }
            foreach (int id in companyIds)
            {
                if(companyID == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

