using System;
using System.Collections.Generic;
using System.Linq;

namespace CongestionCharge
{
    public class ChargeCalculator
    {
        private IEnumerable<ChargeWindow> applicableChargeWindows;
        public ChargeReceipt Calculate(Vehicle vehicle, DateTime startDateTime, DateTime endDateTime, IEnumerable<ChargeWindow> chargeWindows)
        {
            var chargeReceipt = new ChargeReceipt();
            if (chargeWindows == null)
                return chargeReceipt;
            if (endDateTime < startDateTime)
                return chargeReceipt;

            var currentDateTime = startDateTime;

            applicableChargeWindows = chargeWindows.Where(x => x.Vehicle == vehicle).ToList();
            //Walk through the time windows
            while (currentDateTime < endDateTime)
            {
                var charge = GetApplicableCharge(ref currentDateTime, endDateTime);
                if (charge != null)
                {
                    chargeReceipt.Add(charge);
                }
            }
            return chargeReceipt;
        }

        private Charge GetApplicableCharge(ref DateTime startDateTime, DateTime endDateTime)
        {
            //Due to ref
            var start = startDateTime;

            TimeSpan chargeableWindow;

            //Is today a chargeable day?
            var todaysChargePeriods = applicableChargeWindows.Where(x => x.DayOfWeek == start.DayOfWeek).OrderBy(x => x.StartTime).ToList();
            if (!todaysChargePeriods.Any())
            {
                startDateTime = IncrementDay(startDateTime);
                return null;
            }
            
            //Calculate today's charges

            var minStart = todaysChargePeriods.Min(x => x.StartTime);
            //Is the current time before the next charging window
            if (startDateTime.TimeOfDay < minStart)
            {
                //Move to start of new charging window
                startDateTime = new DateTime(startDateTime.Year, startDateTime.Month, startDateTime.Day, minStart.Hours,
                    minStart.Minutes, 0);
                return null;
            }

            //Get first charging window of the day
            var chargingWindow = todaysChargePeriods.FirstOrDefault(x => x.StartTime <= start.TimeOfDay && x.EndTime > start.TimeOfDay);

            if (chargingWindow == null)
            {
                startDateTime = IncrementDay(startDateTime);
                return null;
            }
            
            if (endDateTime.Date == startDateTime.Date && endDateTime.TimeOfDay < chargingWindow.EndTime)
            {
                //End time within current charging window
                chargeableWindow = endDateTime.TimeOfDay - startDateTime.TimeOfDay;
                //Move to end of current charging window
                startDateTime = endDateTime;
            }
            else
            {
                //End time is past the current charging window
                chargeableWindow = chargingWindow.EndTime - startDateTime.TimeOfDay;
                startDateTime = new DateTime(startDateTime.Year,startDateTime.Month,startDateTime.Day,chargingWindow.EndTime.Hours,chargingWindow.EndTime.Minutes,0);
            }

            return new Charge(chargingWindow.Name, chargingWindow.HourlyCharge, chargeableWindow.TotalMinutes);
        }

        private static DateTime IncrementDay(DateTime startDateTime)
        {
            //Increment to start of next day
            startDateTime = new DateTime(startDateTime.Year,startDateTime.Month,startDateTime.Day);
            return startDateTime.AddDays(1);
        }
    }
}
