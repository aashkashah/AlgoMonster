namespace AlgoMonster.LLD.AmazonLocker
{
    public class Locker
    {
        public Compartment[] Compartments;

        public Dictionary<string, AccessToken> accessTokenMappings;

        private Random random;
        
        public Locker(Compartment[] compartments)
        {
            this.Compartments = compartments;  
            this.accessTokenMappings = new Dictionary<string, AccessToken>();
            random = new Random();
        }

        public string DepositPackage(Size size)
        {
            var cmp = GetAvailableCompartment(size);

            if (cmp == null)
                throw new Exception("No compartments available");

            cmp.Open();
            cmp.MarkOccupied();
            var accesstoken = GenerateAccessToken(cmp);
            accessTokenMappings[accesstoken.Code] = accesstoken;

            return accesstoken.Code;
        }

        public bool PickupPackage(string token)
        {
            if(string.IsNullOrWhiteSpace(token))
            {
                throw new InvalidOperationException("Invalid access token code");
            }

            if (!accessTokenMappings.TryGetValue(token, out var accesstoken))
            {
                throw new InvalidOperationException("Invalid access token code");
            }

            if(accesstoken.IsExpired())
            {
                throw new InvalidOperationException("Access token has expired");
            }

            var cmp = accesstoken.GetCompartment();
            cmp.Open();
            ClearDeposit(accesstoken);

            return false; 
        }

        public void OpenExpiredCompartments()
        {
            foreach (var accessToken in accessTokenMappings.Values)
            {
                if(accessToken.IsExpired())
                {
                    var cmp = accessToken.GetCompartment();
                    cmp.Open();
                }
            }

        }

        public Compartment GetAvailableCompartment(Size size)
        {
            foreach(var c in Compartments)
            {
                if(c.Size == size && !c.IsOccupied())
                {
                    return c;
                }
            }

            Size[] sizesInOrder = [Size.Small, Size.Medium, Size.Large];

            var startIndex = (int)size;
            for(int i =  startIndex; i <= sizesInOrder.Length; i++)
            {
                var s = sizesInOrder[i];
                foreach(var c in Compartments)
                {
                    if (c.GetSize() == s && !c.IsOccupied())
                        return c;
                }
            }

            return null;
        }

        public AccessToken GenerateAccessToken(Compartment cmp)
        {
            var code = random.Next(0, 1_000_000).ToString("D6");
            var exp = DateTime.UtcNow.AddDays(7);
            return new AccessToken(code, exp, cmp);
        }

        public void ClearDeposit(AccessToken accessToken)
        {
            var cmp = accessToken.GetCompartment();
            cmp.MarkFree();
            accessTokenMappings.Remove(accessToken.Code);
        }
    }
}
