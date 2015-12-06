using OOParkingslot.Tools;
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
        public void should_not_pick_with_wrong_parkingToken()
        {
            var parkinglot = new Parkinglot();
            parkinglot.Park(new Car());

            var parkingToken = "123324";

            Assert.Null(parkinglot.Pick(parkingToken));
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
    }
}