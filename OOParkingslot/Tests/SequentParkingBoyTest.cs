using Xunit;

namespace OOParkingslot.Tests
{
    public class SequentParkingBoyTest
    {
        [Fact]
        public void should_pick_car_when_only_one_parkinglot_parked()
        {
            var parkinglot = new Parkinglot();
            var parkingBoy = ParkingBoyFactory.CreateParkingBoy(parkinglot);

            var car = new Car();
            var parkToken = parkinglot.Park(car);

            Assert.Same(car, parkingBoy.Pick(parkToken));
        }

        [Fact]
        public void should_park_car_when_only_one_parkinglot()
        {
            var parkinglot = new Parkinglot();
            var parkingBoy = ParkingBoyFactory.CreateParkingBoy(parkinglot);

            var car = new Car();
            var parkingToken = parkingBoy.Park(car);

            Assert.Same(car, parkinglot.Pick(parkingToken));
        }

        [Fact]
        public void should_pick_car_when_there_are_two_parkinglot_parked()
        {
            var parkinglot = new Parkinglot();
            var parkingBoy = ParkingBoyFactory.CreateParkingBoy(new Parkinglot(), parkinglot);

            var car = new Car();
            var parkingToken = parkinglot.Park(car);

            Assert.Same(car, parkingBoy.Pick(parkingToken));
        }

        [Fact]
        public void should_park_car_sequently_when_first_parkinglot_is_full_and_second_not()
        {
            var firstFullParkinglot = new Parkinglot(1);
            firstFullParkinglot.Park(new Car());
            var secondNotFullParkinglot = new Parkinglot(1);
            var parkingBoy = ParkingBoyFactory.CreateParkingBoy(firstFullParkinglot, secondNotFullParkinglot);

            var car = new Car();
            var parkingToken = parkingBoy.Park(car);

            Assert.Same(car, secondNotFullParkinglot.Pick(parkingToken));
        }

        [Fact]
        public void should_park_car_sequently_when_first_is_not_full_and_second_is()
        {
            var firstFullParkinglot = new Parkinglot(1);
            var secondNotFullParkinglot = new Parkinglot(1);
            secondNotFullParkinglot.Park(new Car());
            var parkingBoy = ParkingBoyFactory.CreateParkingBoy(firstFullParkinglot, secondNotFullParkinglot);

            var car = new Car();
            var parkingToken = parkingBoy.Park(car);

            Assert.Same(car, firstFullParkinglot.Pick(parkingToken));
        }

        [Fact]
        public void should_failed_pick_car_after_parked_when_all_parkinglot_is_full()
        {
            var firstParkinglot = new Parkinglot(1);
            firstParkinglot.Park(new Car());
            var secondParkinglot = new Parkinglot(1);
            secondParkinglot.Park(new Car());
            var parkingBoy = ParkingBoyFactory.CreateParkingBoy(firstParkinglot);

            var parkingToken = parkingBoy.Park(new Car());

            Assert.Null(parkingBoy.Pick(parkingToken));
        }
    }
}