using System;
using System.Collections.Generic;
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

        [Fact]
        public void Should_return_null_when_Hao_pick_up_car_with_an_unexist_token()
        {
            string parkingToken = "12345lsjl";
            ParkingSlot parkingSlot = new ParkingSlot();
            Car carPickup = parkingSlot.PickupCarWith(parkingToken);
            Assert.Equal(null, carPickup);
        }

        [Fact]
        public void ParkingToken_should_be_null_when_parkingslot_which_Hao_parking_is_full()
        {
            Car carExist = new Car("Hao", "644KVT");
            ParkingSlot parkingSlot = new ParkingSlot(1);
            string parkingTokenExist = parkingSlot.Parking(carExist);
            Car carParking = new Car("Hao", "645KVT");
            string parkingToken = parkingSlot.Parking(carParking);
            Assert.Equal(null, parkingToken);
        }

        [Fact]
        public void Should_return_carA_when_input_parkingToken_of_carA_Given_carA_and_carB_are_all_in_parkingSlot()
        {
            Car carA = new Car("Hao", "644KVT");
            Car carB = new Car("Hao", "645KVT");
            ParkingSlot parkingSlot = new ParkingSlot();
            string parkingTokenCarA = parkingSlot.Parking(carA);
            string parkingTokenCarB = parkingSlot.Parking(carB);
            Car carPickupWithTokenA = parkingSlot.PickupCarWith(parkingTokenCarA);
            Assert.Equal(carA,carPickupWithTokenA);
            Assert.Equal(null, parkingSlot.GetCarWith(parkingTokenCarA));
            Assert.Equal(carB, parkingSlot.GetCarWith(parkingTokenCarB));
        }
    }
}