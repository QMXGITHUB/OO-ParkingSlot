namespace OOParkingslot
{
    public class BaseParkingBoy
    {
        protected Parkinglot[] parkinglots;

        public BaseParkingBoy(params Parkinglot[] parkinglots1)
        {
            this.parkinglots = parkinglots1;
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
    }
}