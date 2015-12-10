using System;
using System.Collections.Generic;

namespace OOParkingslot
{
    public class PickService
    {
        public static Car SequencePick(string value, List<Func<string, Car>> pickers)
        {
            Car result = null;
            foreach (var action in pickers)
            {
                result = action(value);
                if (result != null) break;
            }
            return result;
        }
    }
}