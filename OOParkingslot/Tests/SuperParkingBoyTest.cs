using Xunit;

namespace OOParkingslot
{
    public class SuperParkingBoyTest
    {
        [Fact]
        public void Should_pick_car_after_parked()
        {
            var car = new Car();
            var superParkingBoy = ParkingBoy.CreateSuperParkingBoyParkedCarInHigherVacancyRate(new Parkinglot());
            var parkingToken = superParkingBoy.Park(car);

            Car carPick = superParkingBoy.Pick(parkingToken);

            Assert.Same(car, carPick);
        }

        [Fact]
        public void Should_pick_when_there_are_two_parkinglots()
        {
            var parkinglot = new Parkinglot();
            var superParkingBoy = ParkingBoy.CreateSuperParkingBoyParkedCarInHigherVacancyRate(new Parkinglot(), parkinglot);
            var car = new Car();
            var parkingToken = parkinglot.Park(car);

            var pickedCar = superParkingBoy.Pick(parkingToken);

            Assert.Same(car, pickedCar);
        }

        [Fact]
        public void
            should_parked_in_higher_vacancy_rate_parkinglot_when_two_parkinglot_with_different_vacancy_rate_0_8_and_0_9()
        {
            var lowerVacancyRateParkinglot = new Parkinglot(10);
            lowerVacancyRateParkinglot.Park(new Car());
            lowerVacancyRateParkinglot.Park(new Car());
            var higherVacancyRateParkinglot = new Parkinglot(10);
            higherVacancyRateParkinglot.Park(new Car());
            var superParkingBoy = ParkingBoy.CreateSuperParkingBoyParkedCarInHigherVacancyRate(lowerVacancyRateParkinglot, higherVacancyRateParkinglot);
            var car = new Car();

            var parkingToken = superParkingBoy.Park(car);

            Assert.Same(car, higherVacancyRateParkinglot.Pick(parkingToken));
        }

        [Fact]
        public void should_pick_failed_when_all_parkinglots_vacancy_rate_is_zero()
        {
            var firstParkinglot = new Parkinglot(1);
            firstParkinglot.Park(new Car());
            var secondParkinglot = new Parkinglot(1);
            secondParkinglot.Park(new Car());
            var superParkingBoy = ParkingBoy.CreateSuperParkingBoyParkedCarInHigherVacancyRate(firstParkinglot, secondParkinglot);

            var parkingToken = superParkingBoy.Park(new Car());

            Assert.Null(superParkingBoy.Pick(parkingToken));
        }
    }
}