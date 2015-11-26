using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOParkingslot
{
    class SuperParkingBoy
    {
        private Parkinglot[] parkinglots;
        readonly SmartParkingBoy smartParkingBoy;

        public SuperParkingBoy(params Parkinglot[] parkinglots)
        {
            this.parkinglots = parkinglots;
            smartParkingBoy = new SmartParkingBoy(parkinglots);
        }

        public Car Pick(string parkingToken)
        {
            foreach (var parkingLot in parkinglots)
            {
                var car = parkingLot.Pick(parkingToken);
                if (car != null)
                    return car;
            }
            return null;
        }

        public string Park(Car car)
        {
            return parkinglots.OrderByDescending(parkinglot => parkinglot.GetVacancyRate()).First().Park(car);
        }
    }
}
