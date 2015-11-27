namespace OOParkingslot
{
    public class ParkingBoy
    {
        protected Parkinglot[] parkinglots;
        private IParkingPolicy parkingPolicy;

        public ParkingBoy(params Parkinglot[] parkinglots1)
        {
            this.parkinglots = parkinglots1;
        }

        public ParkingBoy(IParkingPolicy parkingPolicy, Parkinglot[] parkinglots)
        {
            this.parkingPolicy = parkingPolicy;
            this.parkinglots = parkinglots;
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

        public string Park(Car car, IParkingPolicy parkingPolicy)
        {
            var parkinglotFilter = parkingPolicy.FindParkinglotToPark(parkinglots);
            if (parkinglotFilter == null) return null;
            return parkinglotFilter.Park(car);
        }


        public string Park(Car car)
        {
            var parkinglotFilter = parkingPolicy.FindParkinglotToPark(parkinglots);
            if (parkinglotFilter == null) return null;
            return parkinglotFilter.Park(car);
        }

        public static ParkingBoy CreateSequentParkingBoy(
            IParkingPolicy parkingPolicy,
            params Parkinglot[] parkinglots)
        {
            return new ParkingBoy(parkingPolicy, parkinglots);
        }
    }
}