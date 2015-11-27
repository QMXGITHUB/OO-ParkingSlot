using System.Linq;

namespace OOParkingslot
{
    public class HigherVacancyRateParking : IParkingPolicy
    {
        public Parkinglot FindParkinglotToPark(Parkinglot[] parkinglots)
        {
            return parkinglots.OrderByDescending(parkinglot => parkinglot.GetVacancyRate()).First();
        }
    }
}
