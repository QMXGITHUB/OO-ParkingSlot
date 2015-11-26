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
            return smartParkingBoy.Pick(parkingToken);
        }

        public string Park(Car car)
        {
            return parkinglots[0].Park(car);
        }
    }
}
