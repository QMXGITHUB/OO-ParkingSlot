using System.Linq;

namespace OOParkingslot
{
    public class SuperParkingBoy : ParkingBoy, IParkingPolicy
    {
        public SuperParkingBoy(params Parkinglot[] parkinglots):base(parkinglots)
        {
        }

        public Parkinglot FindParkinglotToPark(Parkinglot[] parkinglots)
        {
            return parkinglots.OrderByDescending(parkinglot => parkinglot.GetVacancyRate()).First();
        }
    }
}
