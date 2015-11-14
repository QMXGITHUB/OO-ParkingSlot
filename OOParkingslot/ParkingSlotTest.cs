using Xunit;

namespace OOParkingslot
{
    public class ParkingSlotTest
    {
        [Fact]
        public void When_Hao_parked_a_car_in_Parkingslot_he_can_pick_up_the_car_away()
        {
            Car carParking = new Car("Hao", "644KVT");
            ParkingSlot parkingSlot = new ParkingSlot();
            string parkingToken = parkingSlot.Parking(carParking);
            Car carPickup = parkingSlot.PickupCarWith(parkingToken);
            Assert.Equal(carParking, carPickup);
        }
    }
}