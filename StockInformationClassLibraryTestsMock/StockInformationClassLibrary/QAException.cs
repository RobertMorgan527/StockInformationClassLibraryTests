using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockInformationClassLibrary
{
    public class InvalidIdException: Exception
    {
        public InvalidIdException() : base("Not a valid ID")
        {
        }
        public InvalidIdException(String errMsg) : base(errMsg)
        {
        }
    }
    public class InvalidUsernameException : Exception
    {
        public InvalidUsernameException() : base("Not a valid username")
        {
        }
        public InvalidUsernameException(String errMsg) : base(errMsg)
        {
        }
    }
    public class InvalidCompanyIdException : Exception
    {
        public InvalidCompanyIdException() : base("Not a valid company ID")
        {
        }
        public InvalidCompanyIdException(String errMsg) : base(errMsg)
        {
        }
    }
}
