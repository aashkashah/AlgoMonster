using System.Security.Cryptography.X509Certificates;

namespace AlgoMonster.LLD.PvZ
{
    public class GameSession
    {
        public const int MaxPlayers = 4;
        public int GameId { get; set; }
        public int Difficulty { get; set; }
        public string Region { get; set; }
        public List<User> Players { get; set; }

        public GameSession(int gameId, int difficulty, string region)
        {
            this.GameId = gameId;
            this.Difficulty = difficulty;
            this.Region = region;
            this.Players = new List<User>();
        }
        public bool AddPlayer(User user) 
        {
            if (Players.Count == 0) return false;

            Players.Add(user);
            return true; 
        }
        public bool RemovePlayer(User user) 
        {
            Players.Remove(user);
            return true; 
        }
    }

    /// <summary>
    /// Orchestrator
    /// Initalize with?
    ///     game servers
    /// </summary>
    public class GameServer
    {
        Dictionary<int, GameSession> activeSessions = new();
        int currentSessionId = 0;

        public GameServer() { }

        public GameSession CreateSession(int difficulty, string region)
        {
            currentSessionId++;
            var game = new GameSession(currentSessionId, difficulty, region);
            activeSessions.Add(currentSessionId, game);
            return game;
        }

        public List<GameSession> Search(int difficulty, string region)
        {
            var matchingSessions = activeSessions.
                    Where(
                        x => x.Value.Difficulty == difficulty &&
                        x.Value.Region == region
                    ).ToList();

            return null;
        }
    }
}
