public class AuthenticationManager
{
    private Dictionary<string, int> tokens = new Dictionary<string, int>();
    private int TTL = 0;
    
    public AuthenticationManager(int timeToLive) {

        this.TTL = timeToLive;
    }

    public void Generate(string tokenId, int currentTime) {
        if(tokens.ContainsKey(tokenId))
            return; // token already exists

        var expiry = TTL + currentTime;
        tokens.Add(tokenId, expiry);
    }
    
    public void Renew(string tokenId, int currentTime) {
        if(!tokens.TryGetValue(tokenId, out var expiry))
            return; // token does not exist
        
        if(expiry < currentTime)
            return; // token expired

        tokens[tokenId] = TTL + currentTime;
    }
    
    public int CountUnexpiredTokens(int currentTime) {
        
        var count = 0;
        foreach(var (tokenId, expiry) in tokens)
        {
            if(expiry > currentTime)
            {
                count++;
                lazyCleanUp(tokenId);
            }
        }
        return count;
    }

    private void lazyCleanUp(string token)
    {
        // remove expired tokens, to avoid map size growing with expired tokens 
        tokens.Remove(token);
    }
}