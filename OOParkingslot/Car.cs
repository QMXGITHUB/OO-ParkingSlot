namespace OOParkingslot
{
    public class Car
    {
        readonly string license;
        readonly string owner;
        private string parkingToken;
        public Car(string owner, string license)
        {
            this.owner = owner;
            this.license = license;
        }

        public void SetParkingToken(string parkingToken)
        {
            this.parkingToken = parkingToken;
        }
        public string GetParkingToken()
        {
            return parkingToken;
        }

        public string GetLicense()
        {
            return license;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            if (this == obj) return true;
            Car car = (Car) obj;
            if (owner == car.GetOwner() && license == car.GetLicense()) return true;
            return false;
        }

        public string GetOwner()
        {
            return owner;
        }
    }
}
