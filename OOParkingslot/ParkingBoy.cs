namespace OOParkingslot
{
    public class ParkingBoy
    {
        private readonly Parkinglot[] parkinglots;
        private readonly IParkingPolicy parkingPolicy;

        public ParkingBoy(IParkingPolicy parkingPolicy, Parkinglot[] parkinglots)
        {
            this.parkingPolicy = parkingPolicy;
            this.parkinglots = parkinglots;
        }

        public string Park(Car car)
        {
            var parkinglotFilter = parkingPolicy.FindParkinglotToPark(parkinglots);
            if (parkinglotFilter == null) return null;
            return parkinglotFilter.Park(car);
        }

        public Car Pick(string parkToken)
        {
            Car car = null;
            foreach (var parkinglot in parkinglots)
            {
                car = parkinglot.Pick(parkToken);
                if (car == null) continue;
            }
            return car;
        }

        public static ParkingBoy CreateSequentParkingBoy(
            params Parkinglot[] parkinglots)
        {
            return new ParkingBoy(new SequentParking(), parkinglots);
        }

        public static ParkingBoy CreateSmartParkingBoyParkedCarInMoreAvaibleStalls(
            params Parkinglot[] parkinglots)
        {
            return new ParkingBoy(new MoreAvaibleStallsParking(), parkinglots);
        }

        public static ParkingBoy CreateSuperParkingBoyParkedCarInHigherVacancyRate(
            params Parkinglot[] parkinglots)
        {
            return new ParkingBoy(new HigherVacancyRateParking(), parkinglots);
        }
    }
}