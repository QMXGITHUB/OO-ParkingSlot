﻿using System;
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

        public string Park(Car car)
        {
            var actions = parkables.Select(parkable => (Func<Car, String>)parkable.Park).ToList();
            foreach (var action in actions)
            {
                var token = action(car);
                if (token != null) return token;
            }
            return null;
       }

        public Car Pick(string token)
        {
            var pickers = parkables.Select(parkable => (Func<string, Car>) parkable.Pick).ToList();
            return PickService.SequencePick(token, pickers);
        }

        public ReportData[] GenerateReportDatas()
        {
            return ReportService.GenerateReportDatas(parkables, "M");
        }
    }
}