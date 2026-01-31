namespace AlgoMonster.LLD._2.RateLimiter
{
    using System.Collections.Generic;

    public class RateLimiter
    {
        private readonly Dictionary<string, ILimiter> _limiters = new();
        private readonly ILimiter _defaultLimiter;

        public RateLimiter(IEnumerable<Dictionary<string, object>> configs, Dictionary<string, object> defaultConfig)
        {
            var factory = new LimiterFactory();
            foreach (var config in configs)
            {
                if (!config.TryGetValue("endpoint", out var endpointObj))
                {
                    continue;
                }

                var endpoint = endpointObj as string;
                if (string.IsNullOrEmpty(endpoint))
                {
                    continue;
                }

                _limiters[endpoint] = factory.Create(config);
            }

            _defaultLimiter = factory.Create(defaultConfig);
        }

        public RateLimitResult Allow(string clientId, string endpoint)
        {
            var limiter = _limiters.TryGetValue(endpoint, out var match) ? match : _defaultLimiter;
            return limiter.Allow(clientId);
        }
    }

}
