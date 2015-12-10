namespace OOParkingslot
{
    public interface IParkable
    {
        string Park(Car value);
        Car Pick(string value);
        ReportData[] GenerateReportDatas();
    }
}