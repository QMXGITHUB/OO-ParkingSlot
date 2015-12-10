namespace OOParkingslot
{
    public interface IParkable
    {
        string Park(Car car);
        Car Pick(string parkingToken);
        ReportData[] GenerateReportDatas();
    }
}