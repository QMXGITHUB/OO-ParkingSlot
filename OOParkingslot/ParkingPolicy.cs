using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOParkingslot
{
    public interface ParkingPolicy
    {
        Parkinglot FindParkinglotToPark(Parkinglot[] parkinglots);
    }
}
