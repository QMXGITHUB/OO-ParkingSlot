using System;
using System.Collections.Generic;
using System.Linq;

namespace OOParkingslot
{
    public class ParkingBoy: IParkable
    {
        private readonly Parkinglot[] parkinglots;
        private readonly IParkingPolicy parkingPolicy;

        public ParkingBoy(IParkingPolicy parkingPolicy, params Parkinglot[] parkinglots)
        {
            this.parkingPolicy = parkingPolicy;
            this.parkinglots = parkinglots;
        }

        public string Park(Car value)
        {
            var parkinglotFilter = parkingPolicy.FindParkinglotToPark(parkinglots);
            return parkinglotFilter == null ? null : parkinglotFilter.Park(value);
        }

        public Car Pick(string token)
        {
            var pickers = parkinglots.Select(parkable => (Func<string, Car>)parkable.Pick).ToList();
            return PickService.SequencePick(token, pickers);
        }

        public ReportData[] GenerateReportDatas()
        {
            var parkables = new List<IParkable>() {};
            parkables.AddRange(parkinglots);
            return ReportService.GenerateReportDatas(parkables.ToArray(), "B");
        }
    }
}