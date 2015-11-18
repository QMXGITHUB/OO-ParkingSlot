using System;
using System.Collections.Generic;
using Xunit;

namespace OOParkingslot
{
    public class ParkingSlotTest
    {
        [Fact]
        public void Should_return_not_null_When_pickup_the_car_after_park()
        {
            Car carParking = new Car();
            Parkinglot parkinglot = new Parkinglot();

            string parkingToken = parkinglot.Parking(carParking);

            Car carPickup = parkinglot.PickupCarWith(parkingToken);
            Assert.NotNull(carPickup);
        }

        [Fact]
        public void Should_same_car_When_pickup_the_car_after_park()
        {
            Car carParking = new Car();
            Parkinglot parkinglot = new Parkinglot();
            string parkingToken = parkinglot.Parking(carParking);
            Car carPickup = parkinglot.PickupCarWith(parkingToken);
            Assert.Same(carParking, carPickup);
        }

        [Fact]
        public void Should_return_right_car_when_mutiple_cars_in_parkinglot()
        {
            Car bam = new Car();
            Car qq = new Car();
            Parkinglot parkinglot = new Parkinglot();
            parkinglot.Parking(bam);

            var carPickup = parkinglot.PickupCarWith(parkinglot.Parking(qq));

            Assert.Same(qq, carPickup);
        }

        [Fact]
        public void Should_failed_when_pick_up_car_again()
        {
            Car carParking = new Car();
            var parkinglot = new Parkinglot();
            var parkingToken = parkinglot.Parking(carParking);
            parkinglot.PickupCarWith(parkingToken);

            var carPickUp = parkinglot.PickupCarWith(parkingToken);

            Assert.Null(carPickUp);
        }

        [Fact]
        public void Should_not_get_token_when_parkinglot_is_full()
        {
            Car bmw= new Car();
            var qq = new Car();             
            var parkinglot = new Parkinglot(1);
            parkinglot.Parking(bmw);

            var parkingTokenQQ = parkinglot.Parking(qq);

            Assert.Null(parkingTokenQQ);
        }

        [Fact]
        public void should_success_when_park_bmw_after_pick_up_bmw()
        {
            var bmw = new Car();
            var parkinglot = new Parkinglot();
            parkinglot.PickupCarWith(parkinglot.Parking(bmw));

            var parkingToken = parkinglot.Parking(bmw);

            Assert.NotNull(parkingToken);
        }
    }
}