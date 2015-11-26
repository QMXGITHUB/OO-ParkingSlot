using Xunit;

namespace OOParkingslot
{
    public class SuperParkingBoyTest
    {
        [Fact]
        public void Should_pick_car_after_parked()
        {
            var car = new Car();
            var superParkingBoy = new SuperParkingBoy(new Parkinglot());
            var parkingToken = superParkingBoy.Park(car);

            Car carPick = superParkingBoy.Pick(parkingToken);

            Assert.Same(car, carPick);
        }

        [Fact]
        public void Should_pick_when_there_are_two_parkinglots()
        {
            var parkinglot = new Parkinglot();
            var superParkingBoy = new SuperParkingBoy(new Parkinglot(), parkinglot);
            var car = new Car();
            var parkingToken = parkinglot.Park(car);

            var pickedCar = superParkingBoy.Pick(parkingToken);

            Assert.Same(car, pickedCar);
        }
    }
}