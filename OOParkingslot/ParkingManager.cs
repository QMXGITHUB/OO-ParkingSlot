using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.VisualStyles;

namespace OOParkingslot
{
    public class ParkingManager:IParkable 
    {
        IParkable[] parkables;

        public ParkingManager(params IParkable[] iParkables) 
        {
            parkables = iParkables;
        }

        public string Park(Car value)
        {
            var actions = parkables.Select(parkable => (Func<Car, String>)parkable.Park).ToList();
            foreach (var action in actions)
            {
                var result = action(value);
                if (value != null) return result;
            }
            return null;
       }

        public Car Pick(string value)
        {
            var actions = parkables.Select(parkable => (Func<string, Car>) parkable.Pick).ToList();
            foreach (var action in actions)
            {
                var result = action(value);
                if (result != null) return result;
            }
            return null;
        }

        public ReportData[] GenerateReportDatas()
        {
            return ReportService.GenerateReportDatas(parkables, "M");
        }
    }
}