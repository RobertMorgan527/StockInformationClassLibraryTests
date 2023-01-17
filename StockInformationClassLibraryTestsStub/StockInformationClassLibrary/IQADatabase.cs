using System;
using System.Collections.Generic;

namespace StockInformationClassLibrary
{
    public interface IQADatabase
    {
        List<string> getUsernames();
        List<string> getPasswords();
        List<int> getCompanyIds();
        List<int> getStockLevels();
    }
}
