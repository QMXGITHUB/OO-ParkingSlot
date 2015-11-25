using Xunit;

namespace OOParkingslot
{
    public class ParkingBoyTest
    {
        [Fact]
        public void should_pickup_car()
        {
            var parkinglot = new Parkinglot();
            var parkingBoy = new ParkingBoy(parkinglot);

            var car = new Car();
            var parkingToken = parkinglot.Park(car);

            Assert.Same(car, parkingBoy.Pick(parkingToken) );
        }

    }
}