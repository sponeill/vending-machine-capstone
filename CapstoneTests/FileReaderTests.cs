using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class FileReaderTests
    {
        [TestMethod]
        public void InventoryStocked()
        {
            //Arrange
            VendingMachineFileReader reader = new VendingMachineFileReader("vendingmachine.csv");
            var inventory = reader.GetInventory();

            VendingMachine vm = new VendingMachine(inventory);

            //Act
            //int result = 

            //Assert
            Assert.AreEqual(16, inventory.Count);
        }
    }
}
