﻿using System;
using System.Collections.Generic;

namespace OOParkingslot
{
    public class Parkinglot
    {
        Dictionary<string, Car> garage = new Dictionary<string, Car>();
        private int maxParking;
        public int availableStallCount {
            get { return maxParking - garage.Count; } 
        }

        public Parkinglot(int maxParking)
        {
            this.maxParking = maxParking;
        }

        public Parkinglot():this(20)
        {
        }

        public string Park(Car car)
        {
            if (IsFull()) return null;
            var parkingToken = ParkingToken.CreateParkingToken();
            garage.Add(parkingToken, car);
            return parkingToken;
        }

        public Car Pick(string parkingToken)
        {
            if (parkingToken == null ||!garage.ContainsKey(parkingToken)) return null;
            var car = garage[parkingToken];
            garage.Remove(parkingToken);
            return car;
        }

        private bool IsFull()
        {
            return availableStallCount == 0;
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