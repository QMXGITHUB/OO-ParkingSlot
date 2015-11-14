using System;
using System.Collections.Generic;

namespace OOParkingslot
{
    public class ParkingSlot
    {
        List<Car> garage;

        public ParkingSlot()
        {
            garage = new List<Car>();
        }

        public string Parking(Car carParking)
        {
            garage.Add(carParking);
            return SetParkingToken(carParking);
        }

        private string SetParkingToken(Car carParking)
        {
            string parkingToken = GenerateParkingToken(carParking);
            carParking.SetParkingToken(parkingToken);
            return parkingToken;
        }

        private string GenerateParkingToken(Car carParking)
        {
            return carParking.GetLicense();
        }

        public Car PickupCarWith(string parkingToken)
        {
            int carCount = garage.Count;
            for (int i = 0; i < carCount; i++)
            {
                if (parkingToken == garage[i].GetParkingToken())
                {
                    return garage[i];
                }
            }
            throw new Exception("I didn't find car with Parking Token: "+parkingToken);
        }
    }
}