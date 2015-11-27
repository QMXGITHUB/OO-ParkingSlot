using Xunit;

namespace OOParkingslot.Tests
{
    public class ParkinglotTest
    {
        [Fact]
        public void should_pick_car_after_the_car_parked()
        {
            Parkinglot parkinglot = new Parkinglot();

            Car carPickup = parkinglot.Pick(parkinglot.Park(new Car()));

            Assert.NotNull(carPickup);
        }

        [Fact]
        public void should_pick_right_car_when_mutiple_cars_parked()
        {
            Parkinglot parkinglot = new Parkinglot();
            parkinglot.Park(new Car());
            Car qq = new Car();
            var parkingTokenForQQ = parkinglot.Park(qq);
            parkinglot.Park(new Car());

            var carPickup = parkinglot.Pick(parkingTokenForQQ);

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
        public void should_not_park_when_parkinglot_is_full()
        {
            var parkinglot = new Parkinglot(1);
            parkinglot.Park(new Car());

            var parkingToken = parkinglot.Park(new Car());

            var carPickup = parkinglot.Pick(parkingToken);

            Assert.Null(carPickup);
        }

        [Fact]
        public void should_not_pick_with_wrong_parkingToken()
        {
            var parkinglot = new Parkinglot();
            parkinglot.Park(new Car());

            var parkingToken = "123324";

            Assert.Null(parkinglot.Pick(parkingToken));
        }

        [Fact]
        public void should_available_stalls_equal_parkinglot_size_10_when_no_cars_parked()
        {
            var parkinglot = new Parkinglot(10);

            Assert.Equal(10, parkinglot.GetAvailableStallsCount());
        }

        [Fact]
        public void should_available_stalls_decrease_1_to_be_9_when_parkinglot_size_10_parked_1_car()
        {
            var parkinglot = new Parkinglot(10);

            parkinglot.Park(new Car());

            Assert.Equal(9, parkinglot.GetAvailableStallsCount());
        }

        [Fact]
        public void
            should_available_stall_increase_1_to_be_7_when_parkinglot_size_8_parked_2_cars_and_picked_one
            ()
        {
            var parkinglot = new Parkinglot(8);
            parkinglot.Park(new Car());

            parkinglot.Pick(parkinglot.Park(new Car()));

            Assert.Equal(7, parkinglot.GetAvailableStallsCount());
        }

        [Fact]
        public void should_vacancy_rate_be_1_when_no_cars_parked()
        {
            var parkinglot = new Parkinglot();

            Assert.Equal(1, parkinglot.GetVacancyRate());
        }

        [Fact]
        public void should_vacancy_rate_be_0_857_when_parkinglot_size_7_parked_1_car()
        {
            var parkinglot = new Parkinglot(7);

            parkinglot.Park(new Car());

            Assert.True(TwoDoubleData.Equal(0.857, parkinglot.GetVacancyRate(), 0.001));
        }

        [Fact]
        public void should_vacancy_rate_be_0_9_when_parkinglot_size_10_parked_2_cars_first_then_picked_1_car
            ()
        {
            var parkinglot = new Parkinglot(10);
            parkinglot.Park(new Car());

            parkinglot.Pick(parkinglot.Park(new Car()));

            Assert.True(TwoDoubleData.Equal(0.9, parkinglot.GetVacancyRate(), 0.001));
        }

        [Fact]
        public void should_isfull_be_true_when_parkinglot_cannot_park()
        {
            var parkinglot = new Parkinglot(1);
            parkinglot.Park(new Car());
            var isFull = parkinglot.IsFull();

            Assert.Null(parkinglot.Pick(parkinglot.Park(new Car())));
            Assert.True(isFull);
        }

        [Fact]
        public void should_isfull_be_false_when_parkinglot_can_park()
        {
            var parkinglot = new Parkinglot(2);
            var isFull = parkinglot.IsFull();

            var car = new Car();
            Assert.Same(car, parkinglot.Pick(parkinglot.Park(car)));
            
            Assert.False(isFull);
        }
    }
}