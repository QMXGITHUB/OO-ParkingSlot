using System;
using System.Collections.Generic;

namespace OOParkingslot
{
    public class Parkinglot
    {
        Dictionary<string, Car> garage = new Dictionary<string, Car>();
        private int maxParking;

        public Parkinglot(int maxParking)
        {
            this.maxParking = maxParking;
        }

        public Parkinglot():this(20)
        {
        }

        public string Parking(Car car)
        {
            if (garage.Count == maxParking) return null;
            var parkingToken = ParkingToken.CreateParkingToken();
            garage.Add(parkingToken, car);
            return parkingToken;
        }

        public Car PickupCarWith(string parkingToken)
        {
            if (!garage.ContainsKey(parkingToken)) return null;
            var car = garage[parkingToken];
            garage.Remove(parkingToken);
            return car;
        }
    }

    public class ParkingToken
    {
        public static string CreateParkingToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}