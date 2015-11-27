using System;

namespace OOParkingslot.Tools
{
    public class TwoDoubleData
    {
        public static bool Equal(double date1, double data2, double precision)
        {
            return Math.Abs(date1 - data2) < precision;
        }
    }
}