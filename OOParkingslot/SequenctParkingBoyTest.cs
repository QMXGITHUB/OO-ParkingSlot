using Xunit;

namespace OOParkingslot
{
    public class SequenctParkingBoyTest
    {
        [Fact]
        public void should_pick_car_when_only_one_parkinglot_parked()
        {
            var parkinglot = new Parkinglot();
            var parkingBoy = ParkingBoy.CreateSequentParkingBoy(parkinglot);

            var car = new Car();
            var parkToken = parkinglot.Park(car);

            Assert.Same(car, parkingBoy.Pick(parkToken));
        }

        [Fact]
        public void should_park_car_when_only_one_parkinglot()
        {
            var parkinglot = new Parkinglot();
            var parkingBoy = ParkingBoy.CreateSequentParkingBoy(parkinglot);

            var car = new Car();
            var parkingToken = parkingBoy.Park(car);

            Assert.Same(car, parkinglot.Pick(parkingToken));
        }

        [Fact]
        public void should_pickup_car_when_there_are_two_parkinglot_parked()
        {
            var parkinglot = new Parkinglot();
            var parkingBoy = ParkingBoy.CreateSequentParkingBoy(new Parkinglot(), parkinglot);

            var car = new Car();
            var parkingToken = parkinglot.Park(car);

            Assert.Same(car, parkingBoy.Pick(parkingToken));
        }

        [Fact]
        public void should_park_car_sequently()
        {
            var firstFullParkinglot = new Parkinglot(0);
            var secondNotFullParkinglot = new Parkinglot(1);
            var parkingBoy = ParkingBoy.CreateSequentParkingBoy(firstFullParkinglot, secondNotFullParkinglot);

            var car = new Car();
            var parkingToken = parkingBoy.Park(car);

            Assert.Same(car, secondNotFullParkinglot.Pick(parkingToken));
        }

        [Fact]
        public void should_failed_pick_car_when_all_parkinglot_is_full()
        {
            var firstParkinglot = new Parkinglot(1);
            firstParkinglot.Park(new Car());
            var secondParkinglot = new Parkinglot(1);
            secondParkinglot.Park(new Car());
            var parkingBoy = ParkingBoy.CreateSequentParkingBoy(firstParkinglot);

            var parkingToken = parkingBoy.Park(new Car());

            Assert.Null(parkingBoy.Pick(parkingToken));
        }
    }
}