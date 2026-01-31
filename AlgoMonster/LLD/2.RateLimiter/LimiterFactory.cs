namespace AlgoMonster.LLD._2.RateLimiter
{
    using System;
    using System.Collections.Generic;

    public class LimiterFactory
    {
        public ILimiter Create(Dictionary<string, object> config)
        {
            var algorithm = config.GetValueOrDefault("algorithm") as string;
            var algoConfig = config.GetValueOrDefault("algoConfig") as Dictionary<string, object> ?? new();

            if (algorithm == "TokenBucket")
            {
                var capacity = Convert.ToInt32(algoConfig.GetValueOrDefault("capacity", 0));
                var refillRate = Convert.ToInt32(algoConfig.GetValueOrDefault("refillRatePerSecond", 0));
                return new TokenBucketLimiter(capacity, refillRate);
            }

            if (algorithm == "SlidingWindowLog")
            {
                var maxRequests = Convert.ToInt32(algoConfig.GetValueOrDefault("maxRequests", 0));
                var windowMs = Convert.ToInt64(algoConfig.GetValueOrDefault("windowMs", 0));
                return new SlidingWindowLogLimiter(maxRequests, windowMs);
            }

            throw new ArgumentException($"Unknown algorithm: {algorithm}");
        }
    }

}
