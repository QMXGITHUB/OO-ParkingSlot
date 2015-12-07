using System.Linq;
using System.Windows.Forms.VisualStyles;

namespace OOParkingslot
{
    public class ParkingManager : ParkingBoy
    {
        private readonly ParkingBoy[] parkingBoys;

        public ParkingManager(params Parkinglot[] parkinglots) : this(new ParkingBoy[0],parkinglots)
        {
        }

        public ParkingManager(ParkingBoy[] parkingBoys, params Parkinglot[] parkinglots)
            : base(new SequentParking(), parkinglots)
        {
            this.parkingBoys = parkingBoys;
        }

        public new string Park(Car car)
        {
            var token = base.Park(car);
            if (token != null) return token;
            foreach (var parkingBoy in parkingBoys)
            {
                token = parkingBoy.Park(car);
                if (token != null) return token;
            }
            return null;
        }

        public new Car Pick(string token)
        {
            var car = base.Pick(token);
            if (car != null) return car;
            foreach (var parkingBoy in parkingBoys)
            {
                car = parkingBoy.Pick(token);
                if (car != null) return car;
            }
            return null;
        }
    }
}