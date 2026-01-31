namespace AlgoMonster.LLD._2.RateLimiter
{
    public class RateLimitResult
    {
        public bool Allowed { get; }
        public int Remaining { get; }
        public long? RetryAfterMs { get; }

        public RateLimitResult(bool allowed, int remaining, long? retryAfterMs)
        {
            Allowed = allowed;
            Remaining = remaining;
            RetryAfterMs = retryAfterMs;
        }
    }

}
