namespace AlgoMonster.Design
{
    public class Twitter
    {
        int time = 0;
        // user -> tweets
        private Dictionary<int, List<(int time, int tweetId)>> _tweets = new Dictionary<int, List<(int time, int tweetId)>>();

        // user(follower) -> follows(followee)
        private Dictionary<int, HashSet<int>> _followees = new Dictionary<int, HashSet<int>>();

        public Twitter() { }

        public void PostTweet(int userId, int tweetId)
        {
            if (!_tweets.TryGetValue(userId, out var tweets))
            {
                tweets = new List<(int time, int tweetId)>();
            }
            tweets.Add((++time, tweetId));
            _tweets[userId] = tweets;
        }

        public List<int> GetTweets(int userId)
        {
            // tweets of user + followee
            // order by time desc
            // select top 10

            var users = new HashSet<int>();

            if(_followees.ContainsKey(userId))
            {
                users = _followees[userId];
            }

            users.Add(userId);

            var tweetList = new List<(int time, int tweetId)>();

            foreach(var user in users)
            {
                if(_tweets.ContainsKey(userId))
                {
                    tweetList.AddRange(_tweets[user]);
                }
            }

            var res = tweetList
                    .OrderByDescending(x => x.time)
                    .Take(10)
                    .Select(x => x.tweetId)
                    .ToList();


            return res;
        }

        public void Follow(int followerId, int followeeId) 
        { 
            if(!_followees.TryGetValue(followerId, out var followees))
            {
                followees = new HashSet<int>();
            }
            followees.Add(followeeId);
            _followees[followerId] = followees;
        }
        public void UnFollow(int followerId, int followeeId)
        {
            if(_followees.TryGetValue(followeeId, out var followees))
            {
                _followees.Remove(followeeId);
            }
        }
    }
}
