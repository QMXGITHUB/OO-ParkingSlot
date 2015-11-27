using System.Linq;

namespace OOParkingslot
{
    public class SuperParkingBoy : BaseParkingBoy, IParkingPolicy
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
