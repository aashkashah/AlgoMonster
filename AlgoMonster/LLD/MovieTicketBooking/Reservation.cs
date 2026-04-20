namespace AlgoMonster.LLD.MovieTicketBooking
{
    public class Reservation
    {
        public string _ConfirmationId { get; set; }

        public List<string> _SeatIds { get; set; }

        public Showtime _Showtime { get; set; }

        public Reservation(
            string confirmationId,
            Showtime showtime,
            List<string> seatIds
            ) 
        {
            _ConfirmationId = confirmationId;
            _Showtime = showtime;
            _SeatIds = seatIds;
        }
        public string GetConfirmation()
        {
            return _ConfirmationId;
        }

        public List<string> GetSeatIds()
        {
            return _SeatIds; 
        }

        public Showtime GetShowtime()
        {
            return _Showtime;
        }
    }
}
