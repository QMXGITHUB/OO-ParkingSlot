using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.VisualStyles;

namespace OOParkingslot
{
    public class ParkingManager 
    {
        IParkable[] parkables;

        public ParkingManager(params IParkable[] iParkables) 
        {
            parkables = iParkables;
        }

        public string Park(Car car)
        {
            foreach (var parkable in parkables)
            {
                var token = parkable.Park(car);
                if (token != null) return token;
            }
            return null;
       }

        public Car Pick(string token)
        {
            foreach (var parkable in parkables)
            {
                var car = parkable.Pick(token);
                if (car != null) return car;
            }
            return null;
        }
    }
}