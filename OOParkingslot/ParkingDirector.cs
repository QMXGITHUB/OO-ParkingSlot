namespace OOParkingslot
{
    public class ParkingDirector
    {
        private readonly ParkingManager parkingManager;

        public ParkingDirector(ParkingManager parkingManager)
        {
            this.parkingManager = parkingManager;
        }

        public string Report()
        {
            return ReportService.FormatReportDatas(parkingManager.GenerateReportDatas());
        }
    }
}