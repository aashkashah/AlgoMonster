namespace AlgoMonster.LLD._1.ParkingLot
{
    public class ParkingLot
    {
        private readonly List<ParkingSpot> _spots;
        private readonly Dictionary<string, Ticket> _activeTickets;
        private readonly HashSet<string> _occupiedSpotIds;
        private readonly long _hourlyRateCents;

        public ParkingLot(List<ParkingSpot> spots, long hourlyRateCents)
        {
            _spots = spots;
            _activeTickets = new Dictionary<string, Ticket>();
            _occupiedSpotIds = new HashSet<string>();
            _hourlyRateCents = hourlyRateCents;
        }

        public Ticket Enter(VehicleType vehicleType)
        {
            ParkingSpot spot = FindAvailableSpot(vehicleType);
            if (spot == null)
            {
                throw new Exception($"No available spots for vehicle type {vehicleType}");
            }

            _occupiedSpotIds.Add(spot.GetId());

            string ticketId = Guid.NewGuid().ToString();
            long entryTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            Ticket ticket = new Ticket(ticketId, spot.GetId(), vehicleType, entryTime);

            _activeTickets[ticketId] = ticket;

            return ticket;
        }

        public long Exit(string ticketId)
        {
            if (string.IsNullOrEmpty(ticketId))
            {
                throw new Exception("Invalid ticket ID");
            }

            if (!_activeTickets.TryGetValue(ticketId, out Ticket ticket))
            {
                throw new Exception("Ticket not found or already used");
            }

            long exitTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            long fee = ComputeFee(ticket.GetEntryTime(), exitTime);

            _occupiedSpotIds.Remove(ticket.GetSpotId());
            _activeTickets.Remove(ticketId);

            return fee;
        }

        private ParkingSpot FindAvailableSpot(VehicleType vehicleType)
        {
            SpotType requiredSpotType = MapVehicleTypeToSpotType(vehicleType);

            foreach (ParkingSpot spot in _spots)
            {
                if (!_occupiedSpotIds.Contains(spot.GetId()) && spot.GetSpotType() == requiredSpotType)
                {
                    return spot;
                }
            }

            return null;
        }

        private SpotType MapVehicleTypeToSpotType(VehicleType vehicleType)
        {
            if (vehicleType == VehicleType.MOTORCYCLE) return SpotType.MOTORCYCLE;
            if (vehicleType == VehicleType.CAR) return SpotType.CAR;
            if (vehicleType == VehicleType.LARGE) return SpotType.LARGE;
            throw new Exception("Unknown vehicle type");
        }

        private long ComputeFee(long entryTime, long exitTime)
        {
            long durationMillis = exitTime - entryTime;
            long durationHours = durationMillis / (1000 * 60 * 60);

            if (durationMillis % (1000 * 60 * 60) > 0)
            {
                durationHours++;
            }

            return durationHours * _hourlyRateCents;
        }
    }
}
