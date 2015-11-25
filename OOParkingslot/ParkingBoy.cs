using System.Linq;

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
            var parkinglot = parkinglots.FirstOrDefault(parkingLot => !parkingLot.IsFull());
            if (parkinglot == null) return null;
            return parkinglot.Park(car);
        }

        public Car Pickupwith(string parkingToken)
        {
            Car car = null;
            foreach (var parkinglot in parkinglots)
            {
                if ((car = parkinglot.Pick(parkingToken)) != null) break;
            }
            return car;
        }
    }
}