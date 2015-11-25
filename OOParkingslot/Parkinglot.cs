using System;
using System.Collections.Generic;

namespace OOParkingslot
{
    public class Parkinglot
    {
        Dictionary<string, Car> garage = new Dictionary<string, Car>();
        private int maxParking;
        public int availableStallCount { set; get; }

        public Parkinglot(int maxParking)
        {
            this.maxParking = maxParking;
            availableStallCount = maxParking;
        }

        public Parkinglot():this(20)
        {
        }

        public string Park(Car car)
        {
            if (IsFull()) return null;
            var parkingToken = ParkingToken.CreateParkingToken();
            garage.Add(parkingToken, car);
            availableStallCount = availableStallCount - 1;
            return parkingToken;
        }

        public Car Pick(string parkingToken)
        {
            if (parkingToken == null ||!garage.ContainsKey(parkingToken)) return null;
            var car = garage[parkingToken];
            garage.Remove(parkingToken);
            availableStallCount = availableStallCount + 1;
            return car;
        }

        public bool IsFull()
        {
            return garage.Count == maxParking;
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