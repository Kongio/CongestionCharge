using System;
using System.Globalization;
using System.Linq;
using CongestionCharge;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CongestionChargeTests
{
    [Binding]
    public class CongestionChargeSteps
    {
        private Vehicle Vehicle;
        private DateTime entryDateTime;
        private DateTime leaveDateTime;

        [Given(@"I am driving a (.*)")]
        public void GivenIAmDrivingA(string vehicle)
        {   
            Vehicle = (Vehicle)Enum.Parse(typeof(Vehicle), vehicle, true);
        }
        
        [When(@"I enter the congestion charge zone at (.*) (.*)")]
        public void WhenIEnterTheCongestionChargeZoneAt(string startDate, string startTime)
        {
            entryDateTime = ParseDateTime(startDate, startTime);
        }
        
        [When(@"I leave the congestion charge zone at (.*) (.*)")]
        public void WhenILeaveTheCongestionChargeZoneAt(string endDate, string endTime)
        {
            leaveDateTime = ParseDateTime(endDate, endTime);
        }
        
        [Then(@"the result should be :")]
        public void ThenTheResultShouldBe(Table results)
        {
            var chargeWindows = Helpers.GetChargeWindows();
            ChargeCalculator calculator = new ChargeCalculator();
            var receipt = calculator.Calculate(Vehicle, entryDateTime, leaveDateTime, chargeWindows);

            var expectedReceipt = results.CreateSet<ReceiptLineItem>().ToArray();

            Assert.AreEqual(expectedReceipt[0].Description, string.Format("Charge for {0} (AM rate):", receipt.TotalMorningDuration));
            Assert.AreEqual(expectedReceipt[0].Value, receipt.TotalMorningCost);
            Assert.AreEqual(expectedReceipt[1].Description, string.Format("Charge for {0} (PM rate):", receipt.TotalAfternoonDuration));
            Assert.AreEqual(expectedReceipt[1].Value, receipt.TotalAfternoonCost);
            Assert.AreEqual(expectedReceipt[2].Value, receipt.GrandTotal);
        }

        public class ReceiptLineItem
        {
            public string Description { get; set; }
            public string Value { get; set; }
        }

        private DateTime ParseDateTime(string date, string time)
        {
            var temp = String.Format("{0} {1}", date, time);
            var datetime = DateTime.ParseExact(temp,"dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            return datetime;
        }
    }
}
