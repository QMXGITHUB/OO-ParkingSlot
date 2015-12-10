using System.Collections.Generic;
using System.Text;

namespace OOParkingslot
{
    public class ParkingDirector
    {
        private const string PrefixUnit = "  ";
        private readonly ParkingManager parkingManager;

        public ParkingDirector(ParkingManager parkingManager)
        {
            this.parkingManager = parkingManager;
        }

        public string Report()
        {
            var report = new StringBuilder();
            var reportdatas = parkingManager.GenerateReportDatas();
            foreach (var reportdata in reportdatas) {
                report.AppendFormat(
                    "{0}{1} {2} {3}\r\n",
                    GeneratePrefix(reportdata.Level),
                    reportdata.Style,
                    reportdata.CarsParked,
                    reportdata.AvailableStalls);
            }
            return report.ToString();
        }

        private static string GeneratePrefix(int prefixCount)
        {
            var prefix = new StringBuilder();
            for (int j = 0; j < prefixCount; j++)
            {
                prefix.Append(PrefixUnit);
            }
            return prefix.ToString();
        }
    }
}