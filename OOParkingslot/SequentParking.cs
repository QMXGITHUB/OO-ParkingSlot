using System.Linq;

namespace OOParkingslot
{
    public class SequentParking: IParkingPolicy
    {
        public Parkinglot FindParkinglotToPark(Parkinglot[] parkinglots)
        {
            return parkinglots.FirstOrDefault(parkinglot => parkinglot.IsFull() == false);
        }
    }
}