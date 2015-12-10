namespace OOParkingslot
{
    public class ParkingBoyFactory
    {
        public static ParkingBoy CreateParkingBoy(
            params Parkinglot[] parkinglots)
        {
            return new ParkingBoy(new SequentParking(), parkinglots);
        }

        public static ParkingBoy CreateSmartParkingBoy(
            params Parkinglot[] parkinglots)
        {
            return new ParkingBoy(new MoreAvaibleStallsParking(), parkinglots);
        }

        public static ParkingBoy CreateSuperParkingBoy(
            params Parkinglot[] parkinglots)
        {
            return new ParkingBoy(new HigherVacancyRateParking(), parkinglots);
        }
    }
}