using Xunit;

namespace OOParkingslot.Tests
{
    public class ParkingManagerTest
    {
        [Fact]
        public void should_park_in_parkinglot_with_no_parkingboy()
        {
            var parkinglot = new Parkinglot();
            var parkingManager = new ParkingManager(parkinglot, new Parkinglot());
            var car = new Car();

            var token = parkingManager.Park(car);

            Assert.Same(car, parkinglot.Pick(token));
        }

        [Fact]
        public void should_pick_from_parkinglot_with_no_parkingboy()
        {
            var parkinglot = new Parkinglot(1);
            var parkingManager = new ParkingManager(parkinglot, new Parkinglot(1));
            var car = new Car();

            var token = parkinglot.Park(car);

            Assert.Same(car, parkingManager.Pick(token));
        }

        [Fact]
        public void should_parkingmanager_park_in_parkinglot_with_parkingboy()
        {
            var parkingBoy = ParkingBoy.CreateSequentParkingBoy(new Parkinglot());
            var parkingManager = new ParkingManager(
                new ParkingBoy[]
                {
                    parkingBoy,
                    ParkingBoy.CreateSmartParkingBoyParkedCarInMoreAvaibleStalls(new Parkinglot()),
                    ParkingBoy.CreateSuperParkingBoyParkedCarInHigherVacancyRate(new Parkinglot())
                },
                new Parkinglot(0));
            var car = new Car();

            var token = parkingManager.Park(car);

            Assert.Same(car, parkingBoy.Pick(token));
        }

        [Fact]
        public void should_parkingmanager_park_in_parkinglot_with_samrtParkingBoy()
        {
            var smartParkingBoy =
                ParkingBoy.CreateSmartParkingBoyParkedCarInMoreAvaibleStalls(new Parkinglot());
            var parkingManager = new ParkingManager(
                new ParkingBoy[]
                {
                    ParkingBoy.CreateSequentParkingBoy(new Parkinglot(0)), 
                    smartParkingBoy,
                    ParkingBoy.CreateSuperParkingBoyParkedCarInHigherVacancyRate(),
                },
                new Parkinglot(0));
            var car = new Car();

            var token = parkingManager.Park(car);

            Assert.Same(car, smartParkingBoy.Pick(token));
        }

        [Fact]
        public void should_parkingManager_pick_when_parkingboy_parked()
        {
            var parkingBoy = ParkingBoy.CreateSequentParkingBoy(new Parkinglot());
            var parkingManager = new ParkingManager(
                new ParkingBoy[]
                {
                    parkingBoy,
                    ParkingBoy.CreateSmartParkingBoyParkedCarInMoreAvaibleStalls(new Parkinglot()),
                    ParkingBoy.CreateSuperParkingBoyParkedCarInHigherVacancyRate(new Parkinglot()),
                },
                new Parkinglot());
            var car = new Car();

            var token = parkingBoy.Park(car);

            Assert.Same(car, parkingManager.Pick(token));
        }

        [Fact]
        public void should_parkingmanager_park_in_parkinglot_with_superParkingBoy()
        {
            var superParkingboy =
                ParkingBoy.CreateSmartParkingBoyParkedCarInMoreAvaibleStalls(new Parkinglot());
            var parkingManager = new ParkingManager(
                new ParkingBoy[]
                {
                    ParkingBoy.CreateSequentParkingBoy(new Parkinglot(0)),
                    ParkingBoy.CreateSmartParkingBoyParkedCarInMoreAvaibleStalls(new Parkinglot(0)),
                    superParkingboy
                },
                new Parkinglot(0));
            var car = new Car();

            var token = parkingManager.Park(car);

            Assert.Same(car, superParkingboy.Pick(token));
        }

        [Fact]
        public void should_parkingManager_pick_when_smarPparkingboy_parked()
        {
            var smartParkingboy = ParkingBoy.CreateSmartParkingBoyParkedCarInMoreAvaibleStalls(new Parkinglot());
            var parkingManager = new ParkingManager(
                new ParkingBoy[]
                {
                    ParkingBoy.CreateSequentParkingBoy(new Parkinglot()),
                    smartParkingboy,
                    ParkingBoy.CreateSuperParkingBoyParkedCarInHigherVacancyRate(new Parkinglot()),
                },
                new Parkinglot());
            var car = new Car();

            var token = smartParkingboy.Park(car);

            Assert.Same(car, parkingManager.Pick(token));
        }

        [Fact]
        public void should_parkingManager_pick_when_superParkingboy_parked()
        {
            var superParkingboy = ParkingBoy.CreateSuperParkingBoyParkedCarInHigherVacancyRate(new Parkinglot());
            var parkingManager = new ParkingManager(
                new ParkingBoy[]
                {
                    ParkingBoy.CreateSequentParkingBoy(new Parkinglot()),
                    ParkingBoy.CreateSmartParkingBoyParkedCarInMoreAvaibleStalls(new Parkinglot()),
                    superParkingboy,
                },
                new Parkinglot());
            var car = new Car();

            var token = superParkingboy.Park(car);

            Assert.Same(car, parkingManager.Pick(token));
        }
    }
}