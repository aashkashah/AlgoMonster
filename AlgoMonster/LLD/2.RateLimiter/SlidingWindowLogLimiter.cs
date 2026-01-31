namespace AlgoMonster.LLD._2.RateLimiter
{
    using System;
    using System.Collections.Generic;

    public class SlidingWindowLogLimiter : ILimiter
    {
        private readonly int _maxRequests;
        private readonly long _windowMs;
        private readonly Dictionary<string, RequestLog> _logs = new();

        public SlidingWindowLogLimiter(int maxRequests, long windowMs)
        {
            _maxRequests = maxRequests;
            _windowMs = windowMs;
        }

        public RateLimitResult Allow(string key)
        {
            var log = GetOrCreateLog(key);

            var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var cutoff = now - _windowMs;

            while (log.Timestamps.Count > 0 && log.Timestamps.Peek() < cutoff)
            {
                log.Timestamps.Dequeue();
            }

            if (log.Timestamps.Count < _maxRequests)
            {
                log.Timestamps.Enqueue(now);
                var remaining = _maxRequests - log.Timestamps.Count;
                return new RateLimitResult(true, remaining, null);
            }

            var oldestTimestamp = log.Timestamps.Peek();
            var retryAfterMs = (oldestTimestamp + _windowMs) - now;
            return new RateLimitResult(false, 0, retryAfterMs);
        }

        private RequestLog GetOrCreateLog(string key)
        {
            if (!_logs.TryGetValue(key, out var log))
            {
                log = new RequestLog();
                _logs[key] = log;
            }
            return log;
        }

        private class RequestLog
        {
            public Queue<long> Timestamps { get; } = new();
        }
    }

}
