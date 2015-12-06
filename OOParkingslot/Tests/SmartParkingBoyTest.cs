using Xunit;

namespace OOParkingslot.Tests
{
    public class SmartParkingBoyTest
    {
        [Fact]
        public void should_park_when_there_is_only_one_parkinglot()
        {
            var parkinglot = new Parkinglot();
            var smartParkingBoy = ParkingBoy.CreateSmartParkingBoyParkedCarInMoreAvaibleStalls(parkinglot);
            var car = new Car();

            var parkingToken = smartParkingBoy.Park(car);

            Assert.Same(car, parkinglot.Pick(parkingToken));
        }

        [Fact]
        public void should_pick_the_car_when_only_one_parkninglot()
        {
            var parkinglot = new Parkinglot();
            var smartParkingBoy = ParkingBoy.CreateSmartParkingBoyParkedCarInMoreAvaibleStalls(parkinglot);
            var car = new Car();

            var parkingToken = parkinglot.Park(car);
            var pickedCar = smartParkingBoy.Pick(parkingToken);

            Assert.Same(car, pickedCar);
        }

        [Fact]
        public void should_pickup_the_car_when_mutiple_parkinglots()
        {
            var parkinglot = new Parkinglot();
            var smartParkingBoy = ParkingBoy.CreateSmartParkingBoyParkedCarInMoreAvaibleStalls(new Parkinglot(), parkinglot);
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
            var smartParkingBoy = ParkingBoy.CreateSmartParkingBoyParkedCarInMoreAvaibleStalls(littleAvailableStallsParkinglot, moreAvailableStallsParkinglot);
            var car = new Car();
            
            var parkingToken = smartParkingBoy.Park(car);

            Assert.Same(car, moreAvailableStallsParkinglot.Pick(parkingToken));
        }

        [Fact]
        public void should_park_in_high_available_stalls_when_no_car_parked_before_with_differet_init_count()
        {
            var moreAvailableStalls = new Parkinglot(2);
            var parkingBoy = ParkingBoy.CreateSmartParkingBoyParkedCarInMoreAvaibleStalls(
                new Parkinglot(1),
                moreAvailableStalls);
            var car = new Car();

            var token = parkingBoy.Park(car);

            Assert.Same(car, moreAvailableStalls.Pick(token));
        }

        [Fact]
        public void should_park_in_high_available_stalls_when_no_car_parked_before_with_same_init()
        {
            var parkinglot = new Parkinglot(1);
            var parkingBoy = ParkingBoy.CreateSmartParkingBoyParkedCarInMoreAvaibleStalls(
                parkinglot,
                new Parkinglot(1));
            var car = new Car();

            var token = parkingBoy.Park(car);

            Assert.Same(car, parkinglot.Pick(token));
        }

        [Fact]
        public void should_park_in_high_available_stalls_when_parked_differently_before_with_same_init()
        {
            var lessAvailableStalls = new Parkinglot(2);
            lessAvailableStalls.Park(new Car());
            var moreAvailableStall = new Parkinglot(2);
            var parkingBoy = ParkingBoy.CreateSmartParkingBoyParkedCarInMoreAvaibleStalls(
                lessAvailableStalls,
                moreAvailableStall);
            var car = new Car();

            var token = parkingBoy.Park(car);

            Assert.Same(car, moreAvailableStall.Pick(token));
        }

        [Fact]
        public void should_park_in_high_available_stalls_when_parked_same_before_with_different_init()
        {
            var lessAvailableStalls = new Parkinglot(2);
            lessAvailableStalls.Park(new Car());
            var moreAvailableStall = new Parkinglot(3);
            moreAvailableStall.Park(new Car());
            var parkingBoy = ParkingBoy.CreateSmartParkingBoyParkedCarInMoreAvaibleStalls(
                lessAvailableStalls,
                moreAvailableStall);
            var car = new Car();

            var token = parkingBoy.Park(car);

            Assert.Same(car, moreAvailableStall.Pick(token));
        }

        [Fact]
        public void should_park_in_high_available_stalls_when_parked_different_before_with_different_init()
        {
            var lessAvailableStalls = new Parkinglot(5);
            lessAvailableStalls.Park(new Car());
            lessAvailableStalls.Park(new Car());
            lessAvailableStalls.Park(new Car());
            var moreAvailableStall = new Parkinglot(4);
            moreAvailableStall.Park(new Car());
            var parkingBoy = ParkingBoy.CreateSmartParkingBoyParkedCarInMoreAvaibleStalls(
                lessAvailableStalls,
                moreAvailableStall);
            var car = new Car();

            var token = parkingBoy.Park(car);

            Assert.Same(car, moreAvailableStall.Pick(token));
        }

        [Fact]
        public void should_failed_pick_when_all_parkinglots_are_full()
        {
            var firstParkinglot = new Parkinglot(1);
            firstParkinglot.Park(new Car());
            var secondParkinglot = new Parkinglot(1);
            secondParkinglot.Park(new Car());
            var smartParkingBoy = ParkingBoy.CreateSmartParkingBoyParkedCarInMoreAvaibleStalls(firstParkinglot, secondParkinglot);

            var parkingToken = smartParkingBoy.Park(new Car());

            Assert.Null(smartParkingBoy.Pick(parkingToken));
        }
    }
}