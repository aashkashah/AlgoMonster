namespace AlgoMonster.LLD.PvZ
{
    public class GameSession
    {
        public const int MaxPlayers = 4;
        public int GameId { get; set; }
        public int Difficulty { get; set; }
        public List<User> Players { get; set; }
        public bool AddPlayer(User user) 
        {
            return false; 
        }
        public bool RemovePlayer(User user) 
        {
            return false; 
        }


        //public bool JoinGame(int gameId, int userId)
        //{
        //    if (games.TryGetValue(gameId, out var users)) return false;

        //    if (users == null || users.Count == 0)
        //    {
        //        users = new List<int>();
        //    }

        //    if (users.Count == 4) return false;

        //    users.Add(userId);
        //    games[gameId] = users;

        //    return true;
        //}

        //public bool LeaveGame(int gameId, int userId)
        //{
        //    if (games.TryGetValue(gameId, out var users)) return false;

        //    games[gameId].Remove(userId);
        //    return true;
        //}
    }

    /// <summary>
    /// Orchestrator
    /// Initalize with?
    ///     game servers
    /// </summary>
    public class GameServer
    {
        Dictionary<int, GameSession> activeSessions = new();

        public GameServer() { }

        public GameSession CreateSession(int difficulty)  
        {
            return null;
        }

        public List<GameSession> Search(int difficulty, string region)
        {
            return null;
        }

    }
}
