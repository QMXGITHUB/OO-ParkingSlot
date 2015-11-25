namespace OOParkingslot
{
    public class ParkingBoy
    {
        private Parkinglot[] parkinglots;

        public ParkingBoy(params Parkinglot[] parkinglots)
        {
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

        public string Park(Car car)
        {
            string parkingToken = null;
            foreach (var parkinglot in parkinglots)
            {
                parkingToken = parkinglot.Park(car);
                if (parkingToken != null) break;
            }
            return parkingToken;
        }
    }
}