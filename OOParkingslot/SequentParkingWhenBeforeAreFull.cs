using System.Linq;

namespace OOParkingslot
{
    public class SequentParkingWhenBeforeAreFull: IParkingPolicy
    {
        public Parkinglot FindParkinglotToPark(Parkinglot[] parkinglots)
        {
            return parkinglots.FirstOrDefault(parkinglot => parkinglot.IsFull() == false);
        }
    }
}