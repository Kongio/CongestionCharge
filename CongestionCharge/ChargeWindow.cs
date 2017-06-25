using System;

namespace CongestionCharge
{
    public class ChargeWindow
    {
        public string Name { get; set; }
        public TimeSpan StartTime { get; }
        public TimeSpan EndTime { get; }
        public Vehicle Vehicle { get; }
        public DayOfWeek DayOfWeek { get; }
        public decimal HourlyCharge { get; }

        public ChargeWindow(string name, Vehicle vehicle, DayOfWeek dayOfWeek, TimeSpan startTime, TimeSpan endTime, decimal hourlyCharge)
        {
            Name = name;
            Vehicle = vehicle;
            DayOfWeek = dayOfWeek;
            StartTime = startTime;
            EndTime = endTime;
            HourlyCharge = hourlyCharge;
        }
    }
}
