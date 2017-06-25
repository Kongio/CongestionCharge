using System;

namespace CongestionCharge
{
    public class ChargeReceipt
    {
        public string TotalMorningDuration
        {
            get { return ConvertToHoursAndMins(totalMorningDuration); }
        }

        public string TotalAfternoonDuration
        {
            get
            {
                return ConvertToHoursAndMins(totalAfternoonDuration);
            }
        }

        public string TotalMorningCost
        {
            get { return string.Format("£{0:f2}", totalMorningCost); }
        }

        public string TotalAfternoonCost
        {
            get
            {
                return string.Format("£{0:f2}", totalAfternoonCost);
            }
        }

        private decimal totalMorningDuration;
        private decimal totalAfternoonDuration;
        private decimal totalMorningCost;
        private decimal totalAfternoonCost;

        public string GrandTotal
        {
            get
            { 
                var total = totalMorningCost + totalAfternoonCost;
                return string.Format("£{0:f2}", total);
            }
        }

        public ChargeReceipt()
        {
            totalMorningDuration = 0.00M;
            totalAfternoonDuration = 0.00M;
            totalMorningCost = 0.00M;
            totalAfternoonCost = 0.00M;
        }

        public void Add(Charge charge)
        {
            if (charge.Type == "AM")
            {
                totalMorningDuration += charge.TotalMinutes;
                totalMorningCost = GetCost(charge.HourlyCharge, totalMorningDuration);
            }
            else
            {
                totalAfternoonDuration += charge.TotalMinutes;
                totalAfternoonCost = GetCost(charge.HourlyCharge, totalAfternoonDuration);
            }
        }

        private string ConvertToHoursAndMins(decimal duration)
        {
            var hours = Math.Floor(duration / 60);
            var mins = (hours > 0) ? duration - (hours * 60): duration;
            return string.Format("{0}h {1}m", Convert.ToInt32(hours), Convert.ToInt32(mins));
        }

        private decimal GetCost(decimal hourlyCharge, decimal duration)
        {
            var temp = hourlyCharge * duration / 60;
            return Math.Truncate(temp * 10) / 10;
        }
    }
}
