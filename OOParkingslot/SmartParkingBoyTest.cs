using Xunit;

namespace OOParkingslot
{
    public class SmartParkingBoyTest
    {
        [Fact]
        public void should_park_a_car_the_car_when_there_is_only_one_parkinglot()
        {
            var parkinglot = new Parkinglot();
            var smartParkingBoy = new SmartParkingBoy(parkinglot);
            var car = new Car();

            var parkingToken = smartParkingBoy.Park(car);

            Assert.Same(car, parkinglot.Pick(parkingToken));
        }

        [Fact]
        public void should_pickup_the_car_after_there_is_only_one_parkninglot()
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
        public void should_park_the_car_in_the_parking_lot_with_more_available_stalls_when_no_car_parked()
        {
            var parkinglotMoreAvailableStall = new Parkinglot(3);
            var smartParkingBoy = new SmartParkingBoy(new Parkinglot(2), parkinglotMoreAvailableStall);
            var car = new Car();
            
            var parkingToken = smartParkingBoy.Park(car);

            Assert.Same(car, parkinglotMoreAvailableStall.Pick(parkingToken));
        }

        [Fact]
        public void should_park_the_car_in_the_last_parking_lot_if_the_two_parking_lots_have_same_available_stalls_when_no_car_parked()
        {
            var lastParkingLot = new Parkinglot(2);
            var smartParkingBoy = new SmartParkingBoy(new Parkinglot(2), lastParkingLot);
            var car = new Car();

            var parkingToken = smartParkingBoy.Park(car);

            Assert.Same(car, lastParkingLot.Pick(parkingToken));
        }

        [Fact]
        public void should_park_the_car_in_the_last_parking_lot_if_the_two_parking_lots_have_same_stalls_after_parking()
        {
            var lastParkingLot = new Parkinglot(2);
            var firstParkingLot = new Parkinglot(3);
            var smartParkingBoy = new SmartParkingBoy(firstParkingLot, lastParkingLot);
            firstParkingLot.Park(new Car());

            var car = new Car();
            var parkingToken = smartParkingBoy.Park(car);

            Assert.Same(car, lastParkingLot.Pick(parkingToken));
        }
   
        [Fact]
        public void should_park_the_car_in_the_parking_lot_with_more_available_stalls_after_pick_a_car()
        {
            var toBeMoreAvailableStallsParkingLot = new Parkinglot(2);
            var smartParkingBoy = new SmartParkingBoy(toBeMoreAvailableStallsParkingLot, new Parkinglot(1));
            var parkToken = toBeMoreAvailableStallsParkingLot.Park(new Car());


            toBeMoreAvailableStallsParkingLot.Pick(parkToken);
            var car = new Car();
            var parkingToken = smartParkingBoy.Park(car);
            var pickedCar = toBeMoreAvailableStallsParkingLot.Pick(parkingToken);

            Assert.Same(car, pickedCar);
        }
   
    }
}