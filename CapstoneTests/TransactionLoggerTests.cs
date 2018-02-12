using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.IO;

namespace CapstoneTests
{
    [TestClass]
    public class TransactionLoggerTests
    {
        [TestMethod]
        public void LogCreated()
        {
            //Arrange
            string Filepath = "Test.txt";
            TransactionLogger log = new TransactionLogger(Filepath, "Test2.txt");
            decimal balance = 0;

            //Act
            log.RecordDeposit(10, balance);


            //Assert
            Assert.IsTrue(File.Exists(Filepath));
        }
    }
}
