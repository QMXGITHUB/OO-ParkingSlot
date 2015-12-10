namespace OOParkingslot
{
    public class ParkingBoyFactory
    {
        public static ParkingBoy CreateParkingBoy(
            params IParkable[] parkinglots)
        {
            return new ParkingBoy(ParkService.SequencePark, parkinglots);
        }

        public static ParkingBoy CreateSmartParkingBoy(
            params Parkinglot[] parkinglots)
        {
            return new ParkingBoy(ParkService.HighAvailableStallsPark, parkinglots);
        }

        public static ParkingBoy CreateSuperParkingBoy(
            params Parkinglot[] parkinglots)
        {
            return new ParkingBoy(ParkService.HighVacancyRatePark, parkinglots);
        }
    }
}