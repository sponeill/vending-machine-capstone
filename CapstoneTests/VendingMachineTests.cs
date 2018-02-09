using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.Collections.Generic;


namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        public void FeedMoneyTest()
        {
            //Arrange
            VendingMachineFileReader reader = new VendingMachineFileReader("vendingmachine.csv");
            var inventory = reader.GetInventory();
            VendingMachine vm = new VendingMachine(inventory);

            //Act
            vm.FeedMoney(10);

            //Assert
            Assert.AreEqual(10, vm.Balance);
        }

        [TestMethod]
        public void QuantityRemainingTest()
        {
            //Arrange
            VendingMachineFileReader reader = new VendingMachineFileReader("vendingmachine.csv");
            var inventory = reader.GetInventory();
            VendingMachine vm = new VendingMachine(inventory);

            //Act
            List<Product> items = inventory["A1"];
            items.RemoveAt(0);

            //Assert
            Assert.AreEqual(4, items.Count);
        }

        [TestMethod]
        public void ReturnChangeTest()
        {
            //Arrange
            VendingMachineFileReader reader = new VendingMachineFileReader("vendingmachine.csv");
            var inventory = reader.GetInventory();
            VendingMachine vm = new VendingMachine(inventory);

            //Act
            vm.FeedMoney(10);
            Change result = vm.ReturnChange();


            //Assert
            Assert.AreEqual(0, vm.Balance);
            Assert.AreEqual(40, result.Quarters);
        }

        [TestMethod]
        public void PurchaseTest()
        {
            //Arrange
            VendingMachineFileReader reader = new VendingMachineFileReader("vendingmachine.csv");
            var inventory = reader.GetInventory();
            VendingMachine vm = new VendingMachine(inventory);

            //Act
            vm.FeedMoney(10);
            vm.Purchase("A1");

            //Assert
            Assert.AreEqual(6.95M, vm.Balance);
        }
    }
}
