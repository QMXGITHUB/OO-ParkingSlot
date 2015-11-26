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
            var parkingLotWithMoreAvailableStalls =
            parkingLots.GroupBy(lot => lot.availableStallCount, lot => lot)
                .OrderByDescending(group => group.Key)
                .First()
                .Last();

            return parkingLotWithMoreAvailableStalls.Park(car);
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