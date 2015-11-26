using System.Collections.Generic;
using System.Linq;

namespace OOParkingslot
{
    public class SmartParkingBoy
    {
        private readonly Parkinglot[] parkingLots;

        public SmartParkingBoy(params Parkinglot[] parkinglots)
        {
            parkingLots = parkinglots;
        }

        public string Park(Car car)
        {
            return parkingLots.OrderByDescending(parkinglot => parkinglot.availableStallCount)
                .First()
                .Park(car);
        }

        public Car Pick(string parkingToken)
        {
            foreach (var parkingLot in parkingLots)
            {
                var car = parkingLot.Pick(parkingToken);
                if (car != null)
                    return car;
            }
            return null;
        }
    }
}