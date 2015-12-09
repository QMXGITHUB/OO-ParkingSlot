using Xunit;

namespace OOParkingslot
{
    public class ParkingDirectorTest
    {
        [Fact]
        public void
            should_print_report_when_manager_has_only_one_parkinglot_1_car_parked_3_available()
        {
            var parkinglot = new Parkinglot(4);
            var parkingDirector = new ParkingDirector(new ParkingManager(parkinglot));

            parkinglot.Park(new Car());

            Assert.Equal("M 1 3\r\n  P 1 3\r\n", parkingDirector.Report());
        }
    }
}