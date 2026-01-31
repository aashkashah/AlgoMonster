namespace AlgoMonster.LLD._2.RateLimiter
{
    using System;
    using System.Collections.Generic;

    public class TokenBucketLimiter : ILimiter
    {
        private readonly int _capacity;
        private readonly int _refillRatePerSecond;
        private readonly Dictionary<string, TokenBucket> _buckets = new();

        public TokenBucketLimiter(int capacity, int refillRatePerSecond)
        {
            _capacity = capacity;
            _refillRatePerSecond = refillRatePerSecond;
        }

        public RateLimitResult Allow(string key)
        {
            var bucket = GetOrCreateBucket(key);

            var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var elapsed = now - bucket.LastRefillTime;
            var tokensToAdd = (elapsed * _refillRatePerSecond) / 1000.0;
            bucket.Tokens = Math.Min(_capacity, bucket.Tokens + tokensToAdd);
            bucket.LastRefillTime = now;

            if (bucket.Tokens >= 1)
            {
                bucket.Tokens -= 1;
                var remaining = (int)Math.Floor(bucket.Tokens);
                return new RateLimitResult(true, remaining, null);
            }

            var tokensNeeded = 1 - bucket.Tokens;
            var retryAfterMs = (long)Math.Ceiling((tokensNeeded * 1000) / _refillRatePerSecond);
            return new RateLimitResult(false, 0, retryAfterMs);
        }

        private TokenBucket GetOrCreateBucket(string key)
        {
            if (!_buckets.TryGetValue(key, out var bucket))
            {
                bucket = new TokenBucket(_capacity, DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
                _buckets[key] = bucket;
            }
            return bucket;
        }

        private class TokenBucket
        {
            public double Tokens { get; set; }
            public long LastRefillTime { get; set; }

            public TokenBucket(double tokens, long lastRefillTime)
            {
                Tokens = tokens;
                LastRefillTime = lastRefillTime;
            }
        }
    }

}
