using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace StockInformationClassLibrary.Tests
{
    [TestClass()]
    public class QASecurityTests
    {

        QASecurity sec;

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
            moqDatabase.Setup(x => x.getPasswords()).Returns(new List<string>{
            "Daniel123","Michal123","Nathaniel123","Wilshire123",
            "Nicholas123","Steven123","Alexander123","Robert123",
            "Thomas123","Sree123","David123","Darren123"
            });

            sec = new QASecurity(moqDatabase.Object);
        }

        [TestMethod()]
        public void isValidUsernameTestForNamesLongerThan3Chars()
        {
            Assert.AreEqual(true, sec.isValidUsername("Mike"));
        }
        [TestMethod()]
        public void isValidUsernameTestForNamesShorter3Chars()
        {
            Assert.AreEqual(false, sec.isValidUsername("A"));
        }
        [TestMethod()]
        public void isValidUsernameTestForNullUsername()
        {
            Assert.AreEqual(false, sec.isValidUsername(null));
        }
        [TestMethod()]
        public void isValidUsernameTestForBlankUsername()
        {
            Assert.AreEqual(false, sec.isValidUsername(""));
        }
        [TestMethod()]
        public void isValidUsernameTestForNotLettersOnly()
        {
            Assert.AreEqual(false, sec.isValidUsername("123!!"));
        }
        [TestMethod()]
        public void isValidPasswordTestForValidPassword()
        {
            Assert.AreEqual(true, sec.isValidPassword("Password1"));
        }
        [TestMethod()]
        public void isValidPasswordTestForPasswordUnder8Char()
        {
            Assert.AreEqual(false, sec.isValidPassword("Pass1"));
        }
        [TestMethod()]
        public void isValidPasswordTestForPasswordNull()
        {
            Assert.AreEqual(false, sec.isValidPassword(null));
        }
        [TestMethod()]
        public void isValidPasswordTestForPasswordBlank()
        {
            Assert.AreEqual(false, sec.isValidPassword(""));
        }
        [TestMethod()]
        public void isValidPasswordTestForPasswordNoInteger()
        {
            Assert.AreEqual(false, sec.isValidPassword("Password"));
        }
        [TestMethod()]
        public void isValidPasswordTestForPasswordLessThan3Char()
        {
            Assert.AreEqual(false, sec.isValidPassword("Pa123456"));
        }
        [TestMethod()]
        public void loginTestForValidLogin()
        {
            Assert.AreEqual(true, sec.login("Robert", "Robert123"));
        }
        [TestMethod()]
        public void loginTestForInvalidUsername()
        {
            Assert.AreEqual(false, sec.login("username", "Robert123"));
        }
        [TestMethod()]
        public void loginTestForInvalidPassword()
        {
            Assert.AreEqual(false, sec.login("Robert", "password123"));
        }
        [TestMethod()]
        public void loginTestForInvalidUsernameAndPassword()
        {
            Assert.AreEqual(false, sec.login("username", "password123"));
        }

    }
}