using Xunit;

namespace OOParkingslot
{
    public class ParkingSlotTest
    {
        [Fact]
        public void should_pickup_car_after_the_car_parked()
        {
            Parkinglot parkinglot = new Parkinglot();

            Car carPickup = parkinglot.Pick(parkinglot.Park(new Car()));

            Assert.NotNull(carPickup);
        }

        [Fact]
        public void should_pickup_right_car_when_mutiple_cars_in_parkinglot()
        {
            Car qq = new Car();
            Parkinglot parkinglot = new Parkinglot();
            parkinglot.Park(new Car());

            var carPickup = parkinglot.Pick(parkinglot.Park(qq));

            Assert.Same(qq, carPickup);
        }

        [Fact]
        public void should_not_pickup_car_twice()
        {
            var parkinglot = new Parkinglot();
            var parkingToken = parkinglot.Park(new Car());
            parkinglot.Pick(parkingToken);

            var carPickUp = parkinglot.Pick(parkingToken);

            Assert.Null(carPickUp);
        }

        [Fact]
        public void should_not_park_a_car_when_parkinglot_is_full()
        {
            var parkinglot = new Parkinglot(1);
            parkinglot.Park(new Car());

            var parkingToken = parkinglot.Park(new Car());

            var carPickup = parkinglot.Pick(parkingToken);

            Assert.Null(carPickup);
        }

        [Fact]
        public void should_not_pickup_car_with_wrong_parkingToken()
        {
            var parkinglot = new Parkinglot();
            parkinglot.Park(new Car());

            var parkingToken = "123324";

            Assert.Null(parkinglot.Pick(parkingToken));
        }


        [Fact]
        public void should_return_1_when_no_cars_parked()
        {
            var parkinglot = new Parkinglot();

            Assert.Equal(1, parkinglot.GetVacancyRate());
        }

        [Fact]
        public void should_return_0_857_when_parkinglot_size_7_parked_1_car()
        {
            var parkinglot = new Parkinglot(7);

            parkinglot.Park(new Car());

            Assert.True(CompareTwoDoubleData.Equal(0.857, parkinglot.GetVacancyRate(), 0.001));
        }
    }
}