using System.Collections.Generic;

namespace OOParkingslot
{
    public class ParkingSlot
    {
        List<Car> garage;
        private int maxParking;

        public ParkingSlot()
        {
            InitParkingSlot();
        }

        private void InitParkingSlot()
        {
            garage = new List<Car>();
            maxParking = 20;
        }

        public ParkingSlot(int maxParking)
        {
            InitParkingSlot();
            this.maxParking = maxParking;
        }

        public string Parking(Car carParking)
        {
            if (garage.Count == maxParking) return null;
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
            return carParking.GetLicense()+carParking.GetOwner();
        }

        public Car PickupCarWith(string parkingToken)
        {
            Car carPickup = GetCarWith(parkingToken);
            garage.Remove(carPickup);
            return carPickup;
        }

        public Car GetCarWith(string parkingToken)
        {
            int carCount = garage.Count;
            for (int i = 0; i < carCount; i++)
            {
                if (parkingToken == garage[i].GetParkingToken())
                {
                   return  garage[i];
                }
            }
            return null;
        }
    }
}