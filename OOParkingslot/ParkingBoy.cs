namespace OOParkingslot
{
    public class ParkingBoy
    {
        private Parkinglot parkinglot;

        public ParkingBoy(Parkinglot parkinglot)
        {
            this.parkinglot = parkinglot;
        }

        public Car Pick(string parkToken)
        {
            return parkinglot.Pick(parkToken);
        }
    }
}