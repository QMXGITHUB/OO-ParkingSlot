using System.Linq;

namespace OOParkingslot
{
    public class MoreAvaibleStallsParking: IParkingPolicy
    {
        public Parkinglot FindParkinglotToPark(Parkinglot[] parkinglots)
        {
            return parkinglots.OrderByDescending(parkinglot => parkinglot.GetAvailableStallsCount())
                .First();
        }
    }
}