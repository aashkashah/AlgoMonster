namespace AlgoMonster.LLD.AmazonLocker
{
    public class AccessToken
    {
        public string Code;

        public DateTime TokenExpiry;

        public Compartment Compartment;

        public AccessToken(string tokenValue, DateTime expiration, Compartment compartment) 
        {
            Code = tokenValue;
            TokenExpiry = expiration;
            Compartment = compartment;
        }

        public bool IsExpired()
        {
            return DateTime.UtcNow >= TokenExpiry;
        }

        public Compartment GetCompartment() 
        {
            return Compartment;
        }
    }
}
