using System;
using System.Collections.Generic;

namespace OOParkingslot
{
    public class ParkingBoy : IParkable
    {
        private readonly IParkable[] parkinglots;
        private readonly Func<Car, IParkable[], string> parkService;

        public ParkingBoy(Func<Car, IParkable[], string> action, params Parkinglot[] parkinglots)
        {
            this.parkinglots = parkinglots;
            parkService = action;
        }

        public string Park(Car value)
        {
            return parkService(value, parkinglots);
        }

        public Car Pick(string token)
        {
            return PickService.SequencePick(token, parkinglots);
        }

        public ReportData[] GenerateReportDatas()
        {
            var parkables = new List<IParkable>() {};
            parkables.AddRange(parkinglots);
            return ReportService.GenerateReportDatas(parkables.ToArray(), "B");
        }
    }
}