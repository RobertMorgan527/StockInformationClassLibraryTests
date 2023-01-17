using System;

namespace StockInformationClassLibrary
{
    public class QAInvalidUserException : Exception
    {
        public QAInvalidUserException() : this("Invalid username or password")
        {
        }
        public QAInvalidUserException(string msg) : base(msg)
        {
        }
    }
    public class QAInvalidPasswordFormatException : Exception
    {
        public QAInvalidPasswordFormatException() : this("Invalid password")
        {
        }
        public QAInvalidPasswordFormatException(string msg) : base(msg)
        {
        }
    }
    public class QAInvalidUsernameFormatException : Exception
    {
        public QAInvalidUsernameFormatException() : this("Invalid username format")
        {
        }
        public QAInvalidUsernameFormatException(string msg) : base(msg)
        {
        }
    }

    public class QAInvalidCompanyIDException : Exception
    {
        public QAInvalidCompanyIDException() : this("Invalid companyID")
        {
        }
        public QAInvalidCompanyIDException(string msg) : base(msg)
        {
        }
    }
}
