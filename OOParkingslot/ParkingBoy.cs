namespace OOParkingslot
{
    public class ParkingBoy
    {
        protected Parkinglot[] Parkinglots;
        private readonly IParkingPolicy parkingPolicy;

        public ParkingBoy(IParkingPolicy parkingPolicy, Parkinglot[] parkinglots)
        {
            this.parkingPolicy = parkingPolicy;
            this.Parkinglots = parkinglots;
        }

        public Car Pick(string parkToken)
        {
            Car car = null;
            foreach (var parkinglot in Parkinglots)
            {
                car = parkinglot.Pick(parkToken);
                if (car == null) continue;
            }
            return car;
        }

        public string Park(Car car)
        {
            var parkinglotFilter = parkingPolicy.FindParkinglotToPark(Parkinglots);
            if (parkinglotFilter == null) return null;
            return parkinglotFilter.Park(car);
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