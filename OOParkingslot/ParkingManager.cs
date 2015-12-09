using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.VisualStyles;

namespace OOParkingslot
{
    public class ParkingManager 
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

        public ReportModule[] GenerateReportData()
        {
            var reportDatas = new List<ReportModule>();
            var moduleForManager = new ReportModule()
            {
                AvailableStalls = 0,
                CarsParked = 0,
                Level = 0,
                Style = "M"
            };
            foreach (var parkable in parkables)
            {
                var reportModules = parkable.GenerateData();
                UpdateLevelInReportData(reportModules);
                UpdateManageReportModule(moduleForManager, reportModules.Last());
                reportDatas.AddRange(reportModules);
            }
            reportDatas.Add(moduleForManager);
            return reportDatas.ToArray();
        }

        private void UpdateManageReportModule(ReportModule moduleForManager, ReportModule reportModule)
        {
            moduleForManager.AvailableStalls += reportModule.AvailableStalls;
            moduleForManager.CarsParked += reportModule.CarsParked;
        }

        private void UpdateLevelInReportData(ReportModule[] reportModules)
        {
            foreach (var reportModule in reportModules)
            {
                reportModule.Level++;
            }
        }
    }
}