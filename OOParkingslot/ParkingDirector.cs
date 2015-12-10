using System.Collections.Generic;
using System.Text;

namespace OOParkingslot
{
    public class ParkingDirector
    {
        private const string PrefixUnit = "  ";
        private ParkingManager parkingManager;

        public ParkingDirector(ParkingManager parkingManager)
        {
            this.parkingManager = parkingManager;
        }

        public string Report()
        {
            var report = new StringBuilder();
            var reportdatas = parkingManager.GenerateData();
            for (int i = 0; i < reportdatas.Length ; i++)
            {
                var reportdata = reportdatas[i];
                report.Append(GeneratePrefixForEachLine(reportdata.Level));
                report.Append(reportdata.Style+" "+reportdata.CarsParked+" "+reportdata.AvailableStalls+"\r\n");
            }
            return report.ToString();
        }

        private static string GeneratePrefixForEachLine(int prefixCount)
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