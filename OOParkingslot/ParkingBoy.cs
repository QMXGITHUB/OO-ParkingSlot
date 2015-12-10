using System.Collections.Generic;

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

        public string Park(Car car)
        {
            var parkinglotFilter = parkingPolicy.FindParkinglotToPark(parkinglots);
            return parkinglotFilter == null ? null : parkinglotFilter.Park(car);
        }

        public Car Pick(string parkToken)
        {
            Car car = null;
            foreach (var parkinglot in parkinglots)
            {
                car = parkinglot.Pick(parkToken);
                if (car != null)  break;
            }
            return car;
        }

        public ReportData[] GenerateReportDatas()
        {
            var parkables = new List<IParkable>() {};
            parkables.AddRange(parkinglots);
            return ReportService.GenerateReportDatas(parkables.ToArray(), "B");
        }

        public static ParkingBoy CreateParkingBoy(
            params Parkinglot[] parkinglots)
        {
            return new ParkingBoy(new SequentParking(), parkinglots);
        }

        public static ParkingBoy CreateSmartParkingBoy(
            params Parkinglot[] parkinglots)
        {
            return new ParkingBoy(new MoreAvaibleStallsParking(), parkinglots);
        }

        public static ParkingBoy CreateSuperParkingBoy(
            params Parkinglot[] parkinglots)
        {
            return new ParkingBoy(new HigherVacancyRateParking(), parkinglots);
        }
    }
}