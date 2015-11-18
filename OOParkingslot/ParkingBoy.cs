namespace OOParkingslot
{
    public class ParkingBoy
    {
        private Parkinglot[] parkinglots;

        public ParkingBoy(Parkinglot[] parkinglots)
        {
            this.parkinglots = parkinglots;
        }

        public string Parking(Car car)
        {
            var count = parkinglots.Length;
            for (int i = 0; i < count; i++)
            {
                if (parkinglots[i].IsFull()) continue;
                return parkinglots[i].Parking(car);
            }
            return null;
        }

        public Car Pickupwith(string parkingToken)
        {
            Car car = null;
            foreach (var parkinglot in parkinglots)
            {
                if ((car = parkinglot.PickupCarWith(parkingToken)) != null) break;
            }
            return car;
        }
    }
}