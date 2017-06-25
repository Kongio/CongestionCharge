using CongestionCharge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CongestionChargeTests
{
    [TestClass]
    public class ChargeReceiptUnitTests
    {
        [TestMethod]
        public void CheckChargeReciptCalculatesGrandTotalCorrectly()
        {
            //Arrange
            ChargeReceipt receipt = new ChargeReceipt();
            Charge charge1 = new Charge("AM", 2.0M,180.0f);
            receipt.Add(charge1);
            Charge charge2 = new Charge("PM", 2.5M, 180.0f);
            receipt.Add(charge2);

            //Act
            var total = receipt.GrandTotal;

            //Assert
            Assert.AreEqual(total,"£13.50");
        }

        [TestMethod]
        public void CheckChargeReceiptCalculatesMorningDurationCorrectly()
        {
            //Arrange
            ChargeReceipt receipt = new ChargeReceipt();
            Charge charge1 = new Charge("AM", 2.0M, 180.0f);
            receipt.Add(charge1);
            Charge charge2 = new Charge("AM", 2.0M, 180.0f);
            receipt.Add(charge2);

            //Act
            var total = receipt.TotalMorningDuration;

            //Assert
            Assert.AreEqual(total, "6h 0m");
        }

        [TestMethod]
        public void CheckChargeReceiptCalculatesAfternoonDurationCorrectly()
        {
            //Arrange
            ChargeReceipt receipt = new ChargeReceipt();
            Charge charge1 = new Charge("PM", 2.5M, 180.0f);
            receipt.Add(charge1);
            Charge charge2 = new Charge("PM", 2.5M, 180.0f);
            receipt.Add(charge2);

            //Act
            var total = receipt.TotalAfternoonDuration;

            //Assert
            Assert.AreEqual(total, "6h 0m");
        }

        [TestMethod]
        public void CheckChargeReceiptCalculatesMorningCostCorrectly()
        {
            //Arrange
            ChargeReceipt receipt = new ChargeReceipt();
            Charge charge1 = new Charge("AM", 2.0M, 180.0f);
            receipt.Add(charge1);
            Charge charge2 = new Charge("AM", 2.0M, 180.0f);
            receipt.Add(charge2);

            //Act
            var total = receipt.TotalMorningCost;

            //Assert
            Assert.AreEqual(total, "£12.00");
        }

        [TestMethod]
        public void CheckChargeReceiptCalculatesAfternoonCostCorrectly()
        {
            //Arrange
            ChargeReceipt receipt = new ChargeReceipt();
            Charge charge1 = new Charge("PM", 2.5M, 180.0f);
            receipt.Add(charge1);
            Charge charge2 = new Charge("PM", 2.5M, 180.0f);
            receipt.Add(charge2);

            //Act
            var total = receipt.TotalAfternoonCost;

            //Assert
            Assert.AreEqual(total, "£15.00");
        }
    }
}
