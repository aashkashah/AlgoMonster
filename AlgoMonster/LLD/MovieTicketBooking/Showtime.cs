using System.Globalization;

namespace AlgoMonster.LLD.MovieTicketBooking
{
    public class Showtime
    {
        public string _Id { get; set; }
        public Theatre _Theatre { get; set; }    
        public DateTime _Date { get; set; }
        public string _ScreenLabel { get; set; }
        public Movie _Movie { get; set; }    
        public List<Reservation> _Reservations { get; set; }

        private object _lock = new();

        public Showtime(
            string Id,
            Theatre theatre,
            DateTime date,
            string label,
            Movie movie) 
        {
            _Id = Id;
            _Theatre = theatre;
            _Movie = movie;
            _Date = date;
            _ScreenLabel = label;
        }

        public string GetId()
        {  
            return _Id; 
        }

        public Theatre GetTheatre()
        {
            return _Theatre;
        }

        public string GetScreenLabel()
        {
            return _ScreenLabel; 
        }
        public Movie GetMovie()
        {
            return _Movie;
        }

        public bool IsSeatAvailable(string seatId)
        {
            foreach(var res in _Reservations)
            {
                if (res._SeatIds.Contains(seatId))
                    return false;
            }

            return true;
        }

        public List<string> GetAvailableSeats()
        {
            var booked = new HashSet<string>();

            foreach (var reservation in _Reservations)
            {
                foreach(var seat in reservation._SeatIds)
                {
                    booked.Add(seat);
                }
            }

            var available = new List<string>();
            for(char row = 'A'; row <= 'Z'; row++)
            {
                for(int num = 0; num <= 20; num++)
                {
                    var seatId = $"{row}{num}";
                    if(!booked.Contains(seatId))
                    {
                        available.Add(seatId);
                    }
                }
            }

            return available;
        }

        public void Book(Reservation reservation)
        {
            lock (_lock)
            {
                var seatIds = reservation._SeatIds;

                if (seatIds == null || seatIds.Count == 0)
                {
                    throw new ArgumentException("Must select at least one seat");
                }

                foreach(var seatid in seatIds)
                {
                    if(!IsValidSeatId(seatid))
                    {
                        throw new ArgumentException("Invalid seat Id");
                    }
                }

                _Reservations.Add(reservation);
            }
        }

        public void Cancel(Reservation reservation)
        {
            lock (_lock) 
            {
                _Reservations.Remove(reservation);
            }
        }

        public bool IsValidSeatId(string seatId)
        {
            if(string.IsNullOrEmpty(seatId) || seatId.Length < 2)
                return false;

            char row = seatId[0];
            if (!int.TryParse(seatId.AsSpan(1), out int num))
                return false;

            if(row >= 'A' && row <= 'Z' && num >= 0 && num <= 20)
                return true;

            return false;
        }
    }
}
