namespace AlgoMonster.LLD.MovieTicketBooking
{
    public class BookingSystem
    {
        private List<Theatre> _theatres;
        private Dictionary<string, Movie> _moviesById = new();
        private Dictionary<string, List<Showtime>> _showtimesByMovieId = new();
        private Dictionary<string, Showtime> _showtimesById = new();
        private Dictionary<string, Reservation> _reservationsById = new();
        public BookingSystem(List<Theatre> theatres)
        {
            _theatres = theatres;

            foreach(var theatre in _theatres)
            {
                foreach(var showtime in theatre.GetShowtimes())
                {
                    var movie = showtime._Movie;
                    _moviesById[movie._MovieId] = movie;
                    _showtimesById[showtime._Id] = showtime;

                    if(!_showtimesByMovieId.ContainsKey(movie._MovieId))
                    {
                        _showtimesByMovieId[movie._MovieId] = new List<Showtime>();
                    }
                    _showtimesByMovieId[movie._MovieId].Add(showtime);
                }
            }
        }
        public List<Showtime> SearchMovies(string title)
        {
            if (string.IsNullOrEmpty(title))
                return new List<Showtime>();

            var results = new List<Showtime>(); 
            var movieTitleLower = title.ToLower();

            foreach(var movie in _moviesById.Values)
            {
                if(movie._Title.Contains(movieTitleLower))
                {
                    if(_showtimesByMovieId.TryGetValue(movie._MovieId, out var movieshowtimes))
                    {
                        foreach(var showtime in movieshowtimes)
                        {
                            if(showtime._Date > DateTime.Now)
                                results.Add(showtime);
                        }
                    }
                }
            }

            return results;
        }

        public List<Showtime> GetShowTimesAtTheatre(Theatre theatre)
        {
            var res = new List<Showtime>();

            foreach(var showtime in theatre.GetShowtimes())
            {
                if(showtime._Date > DateTime.Now)
                    res.Add(showtime);
            }

            return res;
        }

        public Reservation BookShow(string showTimeId, List<string> seats)
        {
            if (string.IsNullOrEmpty(showTimeId))
                throw new ArgumentException("Invalid showtimeId");

            if(!_showtimesById.TryGetValue(showTimeId, out var showtime))
            {
                throw new KeyNotFoundException($"Showtime not found: {showTimeId}");
            }

            var res = new Reservation(
                Guid.NewGuid().ToString(),
                showtime,
                seats);

            showtime.Book(res);

            _reservationsById[res._ConfirmationId] = res;

            return res;
        }

        public void CancelReservation(string confirmationId)
        {
            if(string.IsNullOrEmpty(confirmationId))
                throw new ArgumentException("..");

            if(!_reservationsById.TryGetValue(confirmationId, out var res))
            {
                throw new KeyNotFoundException("..");
            }

            var showtime = res._Showtime;
            showtime.Cancel(res);

            _reservationsById.Remove(confirmationId);
        }
    }
}
