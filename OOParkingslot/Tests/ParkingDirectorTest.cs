using Xunit;

namespace OOParkingslot.Tests
{
    public class ParkingDirectorTest
    {
        [Fact]
        public void
            should_print_report_when_manager_has_only_one_parkinglot()
        {
            var parkinglotWit1Car3Availiable = new Parkinglot(4);
            var parkingDirector = new ParkingDirector(new ParkingManager(parkinglotWit1Car3Availiable));

            parkinglotWit1Car3Availiable.Park(new Car());

            Assert.Equal("M 1 3\r\n  P 1 3\r\n", parkingDirector.Report());
        }
        
        [Fact]
        public void
            should_print_report_when_manager_has_only_two_parkinglot()
        {
            var firstParkinglotWit1Car3Availiable = new Parkinglot(4);
            var secondParkinglotWit1Car3Availiable = new Parkinglot(3);
            var parkingDirector = new ParkingDirector(new ParkingManager(firstParkinglotWit1Car3Availiable, secondParkinglotWit1Car3Availiable));

            firstParkinglotWit1Car3Availiable.Park(new Car());

            Assert.Equal("M 1 6\r\n  P 1 3\r\n  P 0 3\r\n", parkingDirector.Report());
        }

        [Fact]
        public void
            should_print_report_when_manager_has_one_parkingboy_with_one_parklot()
        {
            var parkinglotWit1Car3Availiable = new Parkinglot(4);
            var parkingDirector = new ParkingDirector(new ParkingManager(ParkingBoy.CreateParkingBoy(parkinglotWit1Car3Availiable)));

            parkinglotWit1Car3Availiable.Park(new Car());

            Assert.Equal("M 1 3\r\n  B 1 3\r\n    P 1 3\r\n", parkingDirector.Report());
        }

        [Fact]
        public void
            should_print_report_when_manager_has_one_parkingboy_with_two_parklot()
        {
            var parkinglotWith1Parked2Available = new Parkinglot(3);
            var parkinglotWith1Parked3Availible = new Parkinglot(4);
            var parkingDirector = new ParkingDirector(new ParkingManager(ParkingBoy.CreateParkingBoy(parkinglotWith1Parked2Available, parkinglotWith1Parked3Availible)));

            parkinglotWith1Parked2Available.Park(new Car());
            parkinglotWith1Parked3Availible.Park(new Car());

            Assert.Equal("M 2 5\r\n  B 2 5\r\n    P 1 2\r\n    P 1 3\r\n", parkingDirector.Report());
        }

        [Fact]
        public void
            should_print_report_when_manager_has_two_parklots_and_one_parkingboy_with_two_parklot()
        {
            var parkinglotWith1Parked2Available = new Parkinglot(3);
            var parkinglotWith1Parked3Availible = new Parkinglot(4);
            var parkingDirector = new ParkingDirector(
                new ParkingManager(
                    new Parkinglot(3),
                    ParkingBoy.CreateParkingBoy(parkinglotWith1Parked2Available, parkinglotWith1Parked3Availible),
                    new Parkinglot(4)
                    ));

            parkinglotWith1Parked2Available.Park(new Car());
            parkinglotWith1Parked3Availible.Park(new Car());

            Assert.Equal("M 2 12\r\n  P 0 3\r\n  B 2 5\r\n    P 1 2\r\n    P 1 3\r\n  P 0 4\r\n", parkingDirector.Report());
        }

        [Fact]
        public void
            should_print_report_when_manager_has_two_parklots_and_two_parkingboy_with_two_parklot()
        {
            var parkinglotWith1Parked2Available = new Parkinglot(3);
            var parkinglotWith1Parked3Availible = new Parkinglot(4);
            var smartParkingBoy = ParkingBoy.CreateSmartParkingBoy(new Parkinglot(3));
            var parkingDirector = new ParkingDirector(
                new ParkingManager(
                    new Parkinglot(3),
                    ParkingBoy.CreateParkingBoy(parkinglotWith1Parked2Available, parkinglotWith1Parked3Availible),
                    new Parkinglot(4),
                    smartParkingBoy
                    ));

            smartParkingBoy.Park(new Car());
            parkinglotWith1Parked2Available.Park(new Car());
            parkinglotWith1Parked3Availible.Park(new Car());

            Assert.Equal("M 3 14\r\n  P 0 3\r\n  B 2 5\r\n    P 1 2\r\n    P 1 3\r\n  P 0 4\r\n  B 1 2\r\n    P 1 2\r\n", parkingDirector.Report());
        }
    }
}