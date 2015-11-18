using Xunit;

namespace OOParkingslot
{
    public class ParkingBoyTest
    {
        [Fact]
        public void should_pick_up_car_when_parkingboy_parked()
        {
            var parkingBoy = new ParkingBoy(new Parkinglot[]{new Parkinglot()});
            
            var parkingToken = parkingBoy.Parking(new Car());

            Assert.NotNull(parkingBoy.Pickupwith(parkingToken));
        }

        public void should_success_when_parkinglota_is_not_full_and_parkinglotB_is_full()
        {
            var parkingBoy = new ParkingBoy(new Parkinglot[2] { new Parkinglot(1), new Parkinglot(0) });
            parkingBoy.Parking(new Car());

            var parkingToken = parkingBoy.Parking(new Car());

            Assert.NotNull(parkingToken);
        }

        [Fact]
        public void should_success_when_parkinglotA_is_full_and_parkinglotB_is_not_full()
        {
            var parkingBoy = new ParkingBoy(new Parkinglot[2] {new Parkinglot(0), new Parkinglot(2)});
            parkingBoy.Parking(new Car());
            
            var parkingToken = parkingBoy.Parking(new Car());

            Assert.NotNull(parkingToken);
        }

        [Fact]
        public void should_failed_when_parkinglotA_and_parkinglotB_are_all_full()
        {
            var parkingBoy = new ParkingBoy(new Parkinglot[2] { new Parkinglot(1), new Parkinglot(1) });
            parkingBoy.Parking(new Car());
            parkingBoy.Parking(new Car());

            var parkingToken = parkingBoy.Parking(new Car());

            Assert.Null(parkingToken);
        }

        [Fact]
        public void should_pick_up_success_when_car_parked_in_parkinglotB()
        {
            var parkingBoy = new ParkingBoy(new Parkinglot[2] { new Parkinglot(0), new Parkinglot(1) });
            var qq = new Car();
            var parkingTokenQq = parkingBoy.Parking(qq);

            var pickupQq = parkingBoy.Pickupwith(parkingTokenQq);

            Assert.Same(qq, pickupQq);
        }


    }
}