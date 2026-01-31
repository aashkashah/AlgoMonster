namespace AlgoMonster.LLD._1.ParkingLot
{
    public enum SpotType
    {
        MOTORCYCLE,
        CAR,
        LARGE
    }

    public class ParkingSpot
    {
        private readonly string _id;
        private readonly SpotType _spotType;

        public ParkingSpot(string id, SpotType spotType)
        {
            _id = id;
            _spotType = spotType;
        }

        public SpotType GetSpotType() => _spotType;

        public string GetId() => _id;
    }
}
