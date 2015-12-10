using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        private const string PrefixUnit = "  ";

        public static string FormatEachLineInReport(ReportData reportdata)
        {
            return String.Format(
                "{0}{1} {2} {3}\r\n", GeneratePrefix(reportdata.Level),
                reportdata.Style,
                reportdata.CarsParked,
                reportdata.AvailableStalls);
        }

        public static string GeneratePrefix(int prefixCount)
        {
            var prefix = new StringBuilder();
            for (var j = 0; j < prefixCount; j++)
            {
                prefix.Append(PrefixUnit);
            }
            return prefix.ToString();
        }

        public static string FormatReportDatas(ReportData[] reportdatas)
        {
            var report = new StringBuilder();
            foreach (var reportdata in reportdatas)
            {
                report.Append(FormatEachLineInReport(reportdata));
            }
            return report.ToString();
        }
    }
}