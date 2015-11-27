﻿using System.Linq;

namespace OOParkingslot
{
    public class ParkingBoy
    {
        private Parkinglot[] parkinglots;

        public ParkingBoy(params Parkinglot[] parkinglots)
        {
            this.parkinglots = parkinglots;
        }

        public Car Pick(string parkToken)
        {
            Car car = null;
            foreach (var parkinglot in parkinglots)
            {
                car = parkinglot.Pick(parkToken);
                if (car == null) continue;
            }
            return car;
        }

        public string Park(Car car)
        {
            var parkinglotFilter = parkinglots.FirstOrDefault(parkinglot => parkinglot.IsFull() == false);
            if (parkinglotFilter == null) return null;
            return parkinglotFilter.Park(car);
        }
    }
}