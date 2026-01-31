namespace AlgoMonster.LLD._1.ParkingLot
{
    public enum VehicleType
    {
        MOTORCYCLE,
        CAR,
        LARGE
    }

    public class Ticket
    {
        private readonly string _id;
        private readonly string _spotId;
        private readonly VehicleType _vehicleType;
        private readonly long _entryTime;

        public Ticket(string id, string spotId, VehicleType vehicleType, long entryTime)
        {
            _id = id;
            _spotId = spotId;
            _vehicleType = vehicleType;
            _entryTime = entryTime;
        }

        public string GetId() => _id;

        public string GetSpotId() => _spotId;

        public VehicleType GetVehicleType() => _vehicleType;

        public long GetEntryTime() => _entryTime;
    }
}
