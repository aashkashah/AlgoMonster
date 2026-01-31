namespace AlgoMonster.LLD._2.RateLimiter
{
    public interface ILimiter
    {
        RateLimitResult Allow(string key);
    }

}
