using System;
using System.Collections.Generic;
using Xunit;

namespace OOParkingslot
{
    public class ParkingSlotTest
    {
        [Fact]
        public void Should_success_When_pickup_the_car_after_park()
        {
            Car carParking = new Car("Hao", "644KVT");
            ParkingSlot parkingSlot = new ParkingSlot();
            string parkingToken = parkingSlot.Parking(carParking);
            Car carPickup = parkingSlot.PickupCarWith(parkingToken);
            Assert.Equal(carParking, carPickup);
        }

        [Fact]
        public void Should_failed_when_token_not_exist()
        {
            string parkingToken = "12345lsjl";
            ParkingSlot parkingSlot = new ParkingSlot();
            Car carPickup = parkingSlot.PickupCarWith(parkingToken);
            Assert.Equal(null, carPickup);
        }

        [Fact]
        public void Should_failed_when_parkingslot_full()
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