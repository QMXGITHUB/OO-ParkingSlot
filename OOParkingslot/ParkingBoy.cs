using System.Linq;

namespace OOParkingslot
{
    public class ParkingBoy
    {
        private Parkinglot parkinglot;

        public ParkingBoy(Parkinglot parkinglot)
        {
            this.parkinglot = parkinglot;
        }

        public Car Pick(string parkingToken)
        {
            return parkinglot.Pick(parkingToken);
        }

    }
}