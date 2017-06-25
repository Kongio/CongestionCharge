using System;

namespace CongestionCharge
{
    public class Charge
    {
        public Charge(string chargeType,decimal hourlyCharge, double totalMinutes)
        {
            Type = chargeType;
            HourlyCharge = hourlyCharge;
            TotalMinutes = Convert.ToDecimal(totalMinutes);
        }

        public decimal HourlyCharge { get; set; }

        public decimal TotalMinutes { get; set; }

        public string Type { get; set; }
    }
}