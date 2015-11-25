using Xunit;

namespace OOParkingslot
{
    public class ParkingSlotTest
    {
        [Fact]
        public void should_pickup_right_car_after_the_car_parked()
        {
            Car carParking = new Car();
            Parkinglot parkinglot = new Parkinglot();

            Car carPickup = parkinglot.PickupCarWith(parkinglot.Parking(carParking));

            Assert.Same(carParking, carPickup);
        }

        [Fact]
        public void should_pickup_right_car_when_mutiple_cars_in_parkinglot()
        {
            Car qq = new Car();
            Parkinglot parkinglot = new Parkinglot();
            parkinglot.Parking(new Car());

            var carPickup = parkinglot.PickupCarWith(parkinglot.Parking(qq));

            Assert.Same(qq, carPickup);
        }

        [Fact]
        public void should_not_pickup_car_twice()
        {
            var parkinglot = new Parkinglot();
            var parkingToken = parkinglot.Parking(new Car());
            parkinglot.PickupCarWith(parkingToken);

            var carPickUp = parkinglot.PickupCarWith(parkingToken);

            Assert.Null(carPickUp);
        }

        [Fact]
        public void should_not_park_a_car_when_parkinglot_is_full()
        {
            var parkinglot = new Parkinglot(1);
            parkinglot.Parking(new Car());

            var parkingToken = parkinglot.Parking(new Car());

            var carPickup = parkinglot.PickupCarWith(parkingToken);

            Assert.Null(carPickup);
        }
    }
}