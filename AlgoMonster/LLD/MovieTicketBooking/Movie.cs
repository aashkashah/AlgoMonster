namespace AlgoMonster.LLD.MovieTicketBooking
{
    public class Movie
    {
        public  string _MovieId { get; set; }
        public string _Title { get; set; }   

        public string GetTitle(int id)
        {
            return _Title; 
        }

        public string GetId()
        {
            return _MovieId;
        }
    }
}
