using System;
using System.Collections.Generic;
using CongestionCharge;

namespace CongestionChargeTests
{
    public class Helpers
    {
        public static IEnumerable<ChargeWindow> GetChargeWindows()
        {
            var chargeWindows = new List<ChargeWindow>
            {
                new ChargeWindow("AM", Vehicle.Car, DayOfWeek.Monday, new TimeSpan(0, 7, 0, 0), new TimeSpan(0, 12, 0, 0),
                    2.0M),
                new ChargeWindow("AM", Vehicle.Car, DayOfWeek.Tuesday, new TimeSpan(0, 7, 0, 0), new TimeSpan(0, 12, 0, 0),
                    2.0M),
                new ChargeWindow("AM", Vehicle.Car, DayOfWeek.Wednesday, new TimeSpan(0, 7, 0, 0), new TimeSpan(0, 12, 0, 0),
                    2.0M),
                new ChargeWindow("AM", Vehicle.Car, DayOfWeek.Thursday, new TimeSpan(0, 7, 0, 0), new TimeSpan(0, 12, 0, 0),
                    2.0M),
                new ChargeWindow("AM", Vehicle.Car, DayOfWeek.Friday, new TimeSpan(0, 7, 0, 0), new TimeSpan(0, 12, 0, 0),
                    2.0M),
                new ChargeWindow("PM", Vehicle.Car, DayOfWeek.Monday, new TimeSpan(0, 12, 0, 0), new TimeSpan(0, 19, 0, 0),
                    2.5M),
                new ChargeWindow("PM", Vehicle.Car, DayOfWeek.Tuesday, new TimeSpan(0, 12, 0, 0), new TimeSpan(0, 19, 0, 0),
                    2.5M),
                new ChargeWindow("PM", Vehicle.Car, DayOfWeek.Wednesday, new TimeSpan(0, 12, 0, 0), new TimeSpan(0, 19, 0, 0),
                    2.5M),
                new ChargeWindow("PM", Vehicle.Car, DayOfWeek.Thursday, new TimeSpan(0, 12, 0, 0), new TimeSpan(0, 19, 0, 0),
                    2.5M),
                new ChargeWindow("PM", Vehicle.Car, DayOfWeek.Friday, new TimeSpan(0, 12, 0, 0), new TimeSpan(0, 19, 0, 0),
                    2.5M),
                new ChargeWindow("AM", Vehicle.Van, DayOfWeek.Monday, new TimeSpan(0, 7, 0, 0), new TimeSpan(0, 12, 0, 0),
                    2.0M),
                new ChargeWindow("AM", Vehicle.Van, DayOfWeek.Tuesday, new TimeSpan(0, 7, 0, 0), new TimeSpan(0, 12, 0, 0),
                    2.0M),
                new ChargeWindow("AM", Vehicle.Van, DayOfWeek.Wednesday, new TimeSpan(0, 7, 0, 0), new TimeSpan(0, 12, 0, 0),
                    2.0M),
                new ChargeWindow("AM", Vehicle.Van, DayOfWeek.Thursday, new TimeSpan(0, 7, 0, 0), new TimeSpan(0, 12, 0, 0),
                    2.0M),
                new ChargeWindow("AM", Vehicle.Van, DayOfWeek.Friday, new TimeSpan(0, 7, 0, 0), new TimeSpan(0, 12, 0, 0),
                    2.0M),
                new ChargeWindow("PM", Vehicle.Van, DayOfWeek.Monday, new TimeSpan(0, 12, 0, 0), new TimeSpan(0, 19, 0, 0),
                    2.5M),
                new ChargeWindow("PM", Vehicle.Van, DayOfWeek.Tuesday, new TimeSpan(0, 12, 0, 0), new TimeSpan(0, 19, 0, 0),
                    2.5M),
                new ChargeWindow("PM", Vehicle.Van, DayOfWeek.Wednesday, new TimeSpan(0, 12, 0, 0), new TimeSpan(0, 19, 0, 0),
                    2.5M),
                new ChargeWindow("PM", Vehicle.Van, DayOfWeek.Thursday, new TimeSpan(0, 12, 0, 0), new TimeSpan(0, 19, 0, 0),
                    2.5M),
                new ChargeWindow("PM", Vehicle.Van, DayOfWeek.Friday, new TimeSpan(0, 12, 0, 0), new TimeSpan(0, 19, 0, 0),
                    2.5M),
                new ChargeWindow("AM", Vehicle.Motorbike, DayOfWeek.Monday, new TimeSpan(0, 7, 0, 0),
                    new TimeSpan(0, 12, 0, 0), 1.0M),
                new ChargeWindow("AM", Vehicle.Motorbike, DayOfWeek.Tuesday, new TimeSpan(0, 7, 0, 0),
                    new TimeSpan(0, 12, 0, 0), 1.0M),
                new ChargeWindow("AM", Vehicle.Motorbike, DayOfWeek.Wednesday, new TimeSpan(0, 7, 0, 0),
                    new TimeSpan(0, 12, 0, 0), 1.0M),
                new ChargeWindow("AM", Vehicle.Motorbike, DayOfWeek.Thursday, new TimeSpan(0, 7, 0, 0),
                    new TimeSpan(0, 12, 0, 0), 1.0M),
                new ChargeWindow("AM", Vehicle.Motorbike, DayOfWeek.Friday, new TimeSpan(0, 7, 0, 0),
                    new TimeSpan(0, 12, 0, 0), 1.0M),
                new ChargeWindow("PM", Vehicle.Motorbike, DayOfWeek.Monday, new TimeSpan(0, 12, 0, 0),
                    new TimeSpan(0, 19, 0, 0), 1.0M),
                new ChargeWindow("PM", Vehicle.Motorbike, DayOfWeek.Tuesday, new TimeSpan(0, 12, 0, 0),
                    new TimeSpan(0, 19, 0, 0), 1.0M),
                new ChargeWindow("PM", Vehicle.Motorbike, DayOfWeek.Wednesday, new TimeSpan(0, 12, 0, 0),
                    new TimeSpan(0, 19, 0, 0), 1.0M),
                new ChargeWindow("PM", Vehicle.Motorbike, DayOfWeek.Thursday, new TimeSpan(0, 12, 0, 0),
                    new TimeSpan(0, 19, 0, 0), 1.0M),
                new ChargeWindow("PM", Vehicle.Motorbike, DayOfWeek.Friday, new TimeSpan(0, 12, 0, 0),
                    new TimeSpan(0, 19, 0, 0), 1.0M)
            };

            return chargeWindows;
        }
    }
}
