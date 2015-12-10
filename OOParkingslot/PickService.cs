using System;
using System.Collections.Generic;

namespace OOParkingslot
{
    public class PickService
    {
        public static Car SequencePick(string value, IParkable[] parkers)
        {
            foreach (var parkable in parkers)
            {
                var result = parkable.Pick(value);
                if (result != null) return result;
            }
            return null;
        }
    }
}