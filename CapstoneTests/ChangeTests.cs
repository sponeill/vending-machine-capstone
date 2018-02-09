using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class ChangeTests
    {
        [TestMethod]
        public void ProperChange()
        {
            //Arrange
            decimal total = 6.95M;
            Change change = new Change(total);

            //Act

            //Assert
            Assert.AreEqual(27, change.Quarters);
            Assert.AreEqual(2, change.Dimes);
        }
    }
}
