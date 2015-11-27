using Xunit;

namespace OOParkingslot
{
    public class SmartParkingBoyTest
    {
        [Fact]
        public void should_park_when_there_is_only_one_parkinglot()
        {
            var parkinglot = new Parkinglot();
            var smartParkingBoy = new SmartParkingBoy(parkinglot);
            var car = new Car();

            var parkingToken = smartParkingBoy.Park(car);

            Assert.Same(car, parkinglot.Pick(parkingToken));
        }

        [Fact]
        public void should_pick_the_car_when_only_one_parkninglot()
        {
            var parkinglot = new Parkinglot();
            var smartParkingBoy = new SmartParkingBoy(parkinglot);
            var car = new Car();

            var parkingToken = parkinglot.Park(car);
            var pickedCar = smartParkingBoy.Pick(parkingToken);

            Assert.Same(car, pickedCar);
        }

        [Fact]
        public void should_pickup_the_car_when_mutiple_parkinglots()
        {
            var parkinglot = new Parkinglot();
            var smartParkingBoy = new SmartParkingBoy(new Parkinglot(), parkinglot);
            var car = new Car();

            var parkingToken = parkinglot.Park(car);
            var pickedCar = smartParkingBoy.Pick(parkingToken);

            Assert.Same(car, pickedCar);
        }

        [Fact]
        public void should_park_the_car_in_more_available_stalls_parkinglot()
        {
            var littleAvailableStallsParkinglot = new Parkinglot(2);
            littleAvailableStallsParkinglot.Park(new Car());
            var moreAvailableStallsParkinglot = new Parkinglot(4);
            moreAvailableStallsParkinglot.Park(new Car());
            var smartParkingBoy = new SmartParkingBoy(littleAvailableStallsParkinglot, moreAvailableStallsParkinglot);
            var car = new Car();
            
            var parkingToken = smartParkingBoy.Park(car);

            Assert.Same(car, moreAvailableStallsParkinglot.Pick(parkingToken));
        }

        [Fact]
        public void should_failed_pick_when_all_parkinglots_are_full()
        {
            var firstParkinglot = new Parkinglot(1);
            firstParkinglot.Park(new Car());
            var secondParkinglot = new Parkinglot(1);
            secondParkinglot.Park(new Car());
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy(firstParkinglot, secondParkinglot);

            var parkingToken = smartParkingBoy.Park(new Car());

            Assert.Null(smartParkingBoy.Pick(parkingToken));
        }
    }
}