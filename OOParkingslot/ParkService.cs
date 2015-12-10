using System.Linq;

namespace OOParkingslot
{
    public class ParkService
    {
        public static string SequencePark(Car car, IParkable[] parkables)
        {
            return
                parkables.Select(parkable => parkable.Park(car))
                    .FirstOrDefault(token => token != null);
        }

        public static string MoreAvailableStallsPark(Car car, IParkable[] parkables)
        {
            var parkinglotFilter =
                ((Parkinglot[]) parkables).OrderByDescending(
                    parkinglot => parkinglot.GetAvailableStallsCount())
                    .First();
            return parkinglotFilter == null ? null : parkinglotFilter.Park(car);
        }

        public static string HighVacancyRatePark(Car car, IParkable[] parkables)
        {
            var parkinglotFilter =
                ((Parkinglot[]) parkables).OrderByDescending(
                    parkinglot => parkinglot.GetVacancyRate()).First();
            return parkinglotFilter == null ? null : parkinglotFilter.Park(car);
        }
    }
}