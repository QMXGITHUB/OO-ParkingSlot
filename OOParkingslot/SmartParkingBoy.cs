using System.Linq;

namespace OOParkingslot
{
    public class SmartParkingBoy: ParkingBoy, IParkingPolicy
    {

        public SmartParkingBoy(params Parkinglot[] parkinglots):base(parkinglots)
        {
        }

        public Parkinglot FindParkinglotToPark(Parkinglot[] parkinglots)
        {
            return parkinglots.OrderByDescending(parkinglot => parkinglot.availableStallCount)
                .First();
        }
    }
}