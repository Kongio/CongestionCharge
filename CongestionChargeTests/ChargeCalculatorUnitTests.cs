using System;
using System.Collections.Generic;
using CongestionCharge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CongestionChargeTests
{
    [TestClass]
    public class ChargeCalculatorUnitTests
    {
        [TestMethod]
        public void CheckThatWeekendResultsInNoCharge()
        {
            //Arrange
            var chargeWindows = Helpers.GetChargeWindows();
            ChargeCalculator calculator = new ChargeCalculator();

            //Saturday 10th June 07:00:00 - 08:00:00
            var startDateTime = new DateTime(2017, 06, 10, 7, 0, 0);
            var endDateTime = new DateTime(2017, 06, 10, 8, 0, 0);

            //Act
            var receipt = calculator.Calculate(Vehicle.Car, startDateTime, endDateTime, chargeWindows);

            //Assert
            Assert.AreEqual(receipt.TotalMorningCost, "£0.00");
            Assert.AreEqual(receipt.TotalAfternoonCost, "£0.00");
            Assert.AreEqual(receipt.TotalMorningDuration, "0h 0m");
            Assert.AreEqual(receipt.TotalAfternoonDuration, "0h 0m");
            Assert.AreEqual(receipt.GrandTotal, "£0.00");
        }

        [TestMethod]
        public void CheckThatWeekendSpanning2DaysResultsInNoCharge()
        {
            //Arrange
            var chargeWindows = Helpers.GetChargeWindows();
            ChargeCalculator calculator = new ChargeCalculator();
            //Saturday 10th June - Sunday 11th June
            var startDateTime = new DateTime(2017, 06, 10, 7, 0, 0);
            var endDateTime = new DateTime(2017, 06, 11, 8, 0, 0);

            //Act
            var receipt = calculator.Calculate(Vehicle.Car, startDateTime, endDateTime, chargeWindows);

            //Assert
            Assert.AreEqual(receipt.TotalMorningCost, "£0.00");
            Assert.AreEqual(receipt.TotalAfternoonCost, "£0.00");
            Assert.AreEqual(receipt.TotalMorningDuration, "0h 0m");
            Assert.AreEqual(receipt.TotalAfternoonDuration, "0h 0m");
            Assert.AreEqual(receipt.GrandTotal, "£0.00");
        }

        [TestMethod]
        public void CheckThatBeforeChargingWindowResultsInNoCharge()
        {
            //Arrange
            var chargeWindows = Helpers.GetChargeWindows();
            ChargeCalculator calculator = new ChargeCalculator();

            //Monday 12th June 06:00:00 - 06:45:00
            var startDateTime = new DateTime(2017, 06, 12, 6, 0, 0);
            var endDateTime = new DateTime(2017, 06, 12, 6, 45, 0);

            //Act
            var receipt = calculator.Calculate(Vehicle.Car, startDateTime, endDateTime, chargeWindows);

            //Assert
            Assert.AreEqual(receipt.TotalMorningCost, "£0.00");
            Assert.AreEqual(receipt.TotalAfternoonCost, "£0.00");
            Assert.AreEqual(receipt.TotalMorningDuration, "0h 0m");
            Assert.AreEqual(receipt.TotalAfternoonDuration, "0h 0m");
            Assert.AreEqual(receipt.GrandTotal, "£0.00");
        }

        [TestMethod]
        public void CheckThatAfterChargingWindowResultsInNoCharge()
        {
            //Arrange
            var chargeWindows = Helpers.GetChargeWindows();
            ChargeCalculator calculator = new ChargeCalculator();

            //Monday 12th June 19:00:00 - 20:00:00
            var startDateTime = new DateTime(2017, 06, 12, 19, 0, 0);
            var endDateTime = new DateTime(2017, 06, 12, 20, 0, 0);

            //Act
            var receipt = calculator.Calculate(Vehicle.Car, startDateTime, endDateTime, chargeWindows);

            //Assert
            Assert.AreEqual(receipt.TotalMorningCost, "£0.00");
            Assert.AreEqual(receipt.TotalAfternoonCost, "£0.00");
            Assert.AreEqual(receipt.TotalMorningDuration, "0h 0m");
            Assert.AreEqual(receipt.TotalAfternoonDuration, "0h 0m");
            Assert.AreEqual(receipt.GrandTotal, "£0.00");
        }

        [TestMethod]
        public void CheckThatMorningSessionResultsInMorningChargeOnly()
        {
            //Arrange
            var chargeWindows = Helpers.GetChargeWindows();
            ChargeCalculator calculator = new ChargeCalculator();

            //Monday 12th June 08:00:00 - 09:00:00
            var startDateTime = new DateTime(2017, 06, 12, 8, 0, 0);
            var endDateTime = new DateTime(2017, 06, 12, 9, 0, 0);

            //Act
            var receipt = calculator.Calculate(Vehicle.Car, startDateTime, endDateTime, chargeWindows);

            //Assert
            Assert.AreEqual(receipt.TotalMorningCost, "£2.00");
            Assert.AreEqual(receipt.TotalAfternoonCost, "£0.00");
            Assert.AreEqual(receipt.TotalMorningDuration, "1h 0m");
            Assert.AreEqual(receipt.TotalAfternoonDuration, "0h 0m");
            Assert.AreEqual(receipt.GrandTotal, "£2.00");
        }

        [TestMethod]
        public void CheckThatAfternoonSessionResultsInAfternoonChargeOnly()
        {
            //Arrange
            var chargeWindows = Helpers.GetChargeWindows();
            ChargeCalculator calculator = new ChargeCalculator();

            //Monday 12th June 13:00:00 - 14:00:00
            var startDateTime = new DateTime(2017, 06, 12, 13, 0, 0);
            var endDateTime = new DateTime(2017, 06, 12, 14, 0, 0);

            //Act
            var receipt = calculator.Calculate(Vehicle.Car, startDateTime, endDateTime, chargeWindows);

            //Assert
            Assert.AreEqual(receipt.TotalMorningCost, "£0.00");
            Assert.AreEqual(receipt.TotalAfternoonCost, "£2.50");
            Assert.AreEqual(receipt.TotalMorningDuration, "0h 0m");
            Assert.AreEqual(receipt.TotalAfternoonDuration, "1h 0m");
            Assert.AreEqual(receipt.GrandTotal, "£2.50");
        }

        [TestMethod]
        public void CheckThatSessionSpanningMorningAndAfternoonSessionResultsInBothCharges()
        {
            //Arrange
            var chargeWindows = Helpers.GetChargeWindows();
            ChargeCalculator calculator = new ChargeCalculator();

            //Monday 12th June 09:00:00 - 14:00:00
            var startDateTime = new DateTime(2017, 06, 12, 9, 0, 0);
            var endDateTime = new DateTime(2017, 06, 12, 14, 0, 0);

            //Act
            var receipt = calculator.Calculate(Vehicle.Car, startDateTime, endDateTime, chargeWindows);

            //Assert
            Assert.AreEqual(receipt.TotalMorningCost, "£6.00");
            Assert.AreEqual(receipt.TotalAfternoonCost, "£5.00");
            Assert.AreEqual(receipt.TotalMorningDuration, "3h 0m");
            Assert.AreEqual(receipt.TotalAfternoonDuration, "2h 0m");
            Assert.AreEqual(receipt.GrandTotal, "£11.00");
        }

        [TestMethod]
        public void CheckThatSessionSpanningMultipleDaysResultsInCorrectCharges()
        {
            //Arrange
            var chargeWindows = Helpers.GetChargeWindows();
            ChargeCalculator calculator = new ChargeCalculator();

            //Monday 12th June 09:00:00 - Tuesday 13th June 14:00:00

            //AM:8 hours, PM 9 hours
            var startDateTime = new DateTime(2017, 06, 12, 9, 0, 0);
            var endDateTime = new DateTime(2017, 06, 13, 14, 0, 0);

            //Act
            var receipt = calculator.Calculate(Vehicle.Car, startDateTime, endDateTime, chargeWindows);

            //Assert
            Assert.AreEqual(receipt.TotalMorningCost, "£16.00");
            Assert.AreEqual(receipt.TotalAfternoonCost, "£22.50");
            Assert.AreEqual(receipt.TotalMorningDuration, "8h 0m");
            Assert.AreEqual(receipt.TotalAfternoonDuration, "9h 0m");
            Assert.AreEqual(receipt.GrandTotal, "£38.50");
        }


        [TestMethod]
        public void CheckThatFlatRateSessionSpanningMorningAndAfternoonSessionResultsInSimilarCharges()
        {
            //Arrange
            var chargeWindows = Helpers.GetChargeWindows();
            ChargeCalculator calculator = new ChargeCalculator();

            //Monday 12th June 10:00:00 - 14:00:00
            var startDateTime = new DateTime(2017, 06, 12, 10, 0, 0);
            var endDateTime = new DateTime(2017, 06, 12, 14, 0, 0);

            //Act
            var receipt = calculator.Calculate(Vehicle.Motorbike, startDateTime, endDateTime, chargeWindows);

            //Assert
            Assert.AreEqual(receipt.TotalMorningCost, receipt.TotalAfternoonCost);
            Assert.AreEqual(receipt.TotalMorningDuration, receipt.TotalAfternoonDuration);
        }
    }
}
