namespace AlgoMonster.LLD.MovieTicketBooking
{
    public class Theatre
    {
        public int _Id { get; set; }
        public string _Name { get; set; }
        public List<Showtime> _Showtimes { get; set; }

        public List<Showtime> GetShowtimes()
        {
            return _Showtimes; 
        }

        public List<Showtime> GetShowtimesForMovie(Movie movie)
        {
            var showtimes = new List<Showtime>();

            foreach(var show in showtimes)
            {
                if(show._Movie._MovieId == movie._MovieId)
                    showtimes.Add(show);
            }

            return showtimes;
        }
    }
}
