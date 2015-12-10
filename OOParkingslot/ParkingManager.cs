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
            foreach (var parkable in parkables)
            {
                var token = parkable.Park(car);
                if (token != null) return token;
            }
            return null;
       }

        public Car Pick(string token)
        {
            foreach (var parkable in parkables)
            {
                var car = parkable.Pick(token);
                if (car != null) return car;
            }
            return null;
        }

        public static ReportModule[] GenerateReportDatas(IParkable[] parkables, string style)
        {
            var reportDatas = new List<ReportModule>();
            var dataSummary = new ReportModule()
            {
                AvailableStalls = 0,
                CarsParked = 0,
                Level = 0,
                Style = style
            };
            foreach (var parkable in parkables)
            {
                var innerData = parkable.GenerateData();
                UpdateLevelFor(innerData);
                UpdateSummaryData(dataSummary, innerData.First());
                reportDatas.AddRange(innerData);
            }
            reportDatas.Insert(0, dataSummary);
            return reportDatas.ToArray();
        }

        private static void UpdateSummaryData(ReportModule moduleForManager, ReportModule reportModule)
        {
            moduleForManager.AvailableStalls += reportModule.AvailableStalls;
            moduleForManager.CarsParked += reportModule.CarsParked;
        }

        private static void UpdateLevelFor(ReportModule[] reportModules)
        {
            foreach (var reportModule in reportModules)
            {
                reportModule.Level++;
            }
        }


        public ReportModule[] GenerateData()
        {
            return GenerateReportDatas(parkables, "M");
        }
    }
}