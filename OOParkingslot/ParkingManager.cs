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

        public string Park(Car car)
        {
            return ParkService.SequencePark(car, parkables);
       }

        public Car Pick(string token)
        {
            return PickService.SequencePick(token, parkables);
        }

        public ReportData[] GenerateReportDatas()
        {
            return ReportService.GenerateReportDatas(parkables, "M");
        }
    }
}