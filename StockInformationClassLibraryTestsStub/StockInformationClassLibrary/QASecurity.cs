using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StockInformationClassLibrary
{
    public class QASecurity
    {
        private readonly List<string> userNames;
        private readonly List<string> passwords;

        public QASecurity(IQADatabase db)
        {
            this.userNames = db.getUsernames();
            this.passwords = db.getPasswords();
        }

        public bool login(string username, string password)
        {
            if (!isValidUsername(username))
                throw new ArgumentException("Invalid username format");

            if (!isValidPassword(password))
                throw new ArgumentException("Invalid password format");


            for (int i = 0; i < userNames.Count; i++)
            {
                if (username.ToLower() == userNames[i].ToLower() && password == passwords[i])
                {
                    return true;
                }
            }
            return false;
        }

        public bool isValidUsername(String username)
        {
            if (String.IsNullOrEmpty(username) || username.Length <= 3 || !Regex.IsMatch(username, @"^[a-zA-Z]+$"))
            {
                return false;
            }
            return true;

        }

        public bool isValidPassword(String password)
        {
            if (String.IsNullOrEmpty(password) || !Regex.IsMatch(password, @"(?=.*[a-zA-Z]{3,})(?=.*[0-9]{1,})(?=.{8,})"))
            {
                return false;
            }
            return true;
        }

    }
}