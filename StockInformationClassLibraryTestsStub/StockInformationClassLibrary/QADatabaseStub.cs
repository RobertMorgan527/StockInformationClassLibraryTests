using System;
using System.Collections.Generic;

namespace StockInformationClassLibrary
{
    public class QADatabaseStub : IQADatabase
    {
        private readonly List<string> userNames = new List<string>{
            "Daniel","Michal","Nathaniel","Wilshire",
            "Nicholas","Steven","Alexander","Robert",
            "Thomas","Sree","David","Darren"
        };

        private readonly List<string> passwords = new List<string>{
            "Daniel123","Michal123","Nathaniel123","Wilshire123",
            "Nicholas123","Steven123","Alexander123","Robert123",
            "Thomas123","Sree123","David123","Darren123"
        };

        private readonly List<int> companyIDs = new List<int>{
            1, 4, 5, 9, 12, 16, 25, 30, 36, 40, 49, 64, 81, 99
        };
        private readonly List<int> stockLevels = new List<int>{
            11, 14, 15, 19, 112, 116, 125, 130, 136, 140, 149, 164, 181, 199
        };

        public List<string> getUsernames()
        {
            return userNames;
        }
        public List<string> getPasswords()
        {
            return passwords;
        }
        public List<int> getCompanyIds()
        {
            return companyIDs;
        }
        public List<int> getStockLevels()
        {
            return stockLevels;
        }
    }
}
