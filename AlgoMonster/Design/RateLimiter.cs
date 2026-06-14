namespace AlgoMonster.Design
{
    public class RateLimiter
    {
        private int tokens;
        private int maxTokens;
        private long lastRefill;
        private int refillRate; // tokens per second

        public RateLimiter(int maxTokens, int refillRate)
        { 
            this.maxTokens  = maxTokens;
            this.refillRate = refillRate;
            this.tokens = maxTokens;
            this.lastRefill = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
         }

        public bool AllowRequest()
        {
            Refill();
            if (tokens > 0) { tokens--; return true; }
            return false;
        }

        public void Refill()
        {
            var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            int newTokens = (int)((now - lastRefill) / 1000) * refillRate;
            tokens = Math.Min(maxTokens, tokens + newTokens);
            lastRefill = now;
        }

    }
}
