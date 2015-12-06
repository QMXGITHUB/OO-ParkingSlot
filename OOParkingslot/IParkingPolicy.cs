using System.Linq;

namespace OOParkingslot
{
    public class MoreAvaibleStallsParking : IParkingPolicy
    {
        public Parkinglot FindParkinglotToPark(Parkinglot[] parkinglots)
        {
            return parkinglots.OrderByDescending(parkinglot => parkinglot.GetAvailableStallsCount())
                .First();
        }
    }

    public class HigherVacancyRateParking : IParkingPolicy
    {
        public Parkinglot FindParkinglotToPark(Parkinglot[] parkinglots)
        {
            return parkinglots.OrderByDescending(parkinglot => parkinglot.GetVacancyRate()).First();
        }
    }

    public class SequentParking: IParkingPolicy
    {
        public Parkinglot FindParkinglotToPark(Parkinglot[] parkinglots)
        {
            return parkinglots.FirstOrDefault(parkinglot => parkinglot.IsFull() == false);
        }
    }

    public interface IParkingPolicy
    {
        Parkinglot FindParkinglotToPark(Parkinglot[] parkinglots);
    }
}
