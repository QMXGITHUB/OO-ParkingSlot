using System.Collections.Generic;
using System.Linq;

namespace OOParkingslot
{
    public class ReportService
    {
        public static ReportData[] GenerateReportDatas(IParkable[] parkables, string style)
        {
            var reportDatas = new List<ReportData>();
            var summary = new ReportData()
            {
                AvailableStalls = 0,
                CarsParked = 0,
                Level = 0,
                Style = style
            };
            reportDatas.Add(summary);
            foreach (var parkable in parkables)
            {
                var datas = parkable.GenerateReportDatas();
                UpdateLevelFor(datas);
                UpdateSummaryData(summary, datas.First());
                reportDatas.AddRange(datas);
            }
            return reportDatas.ToArray();
        }

        private static void UpdateSummaryData(ReportData dataForManager, ReportData reportData)
        {
            dataForManager.AvailableStalls += reportData.AvailableStalls;
            dataForManager.CarsParked += reportData.CarsParked;
        }

        private static void UpdateLevelFor(ReportData[] reportDatas)
        {
            foreach (var reportModule in reportDatas)
            {
                reportModule.Level++;
            }
        }
    }
}