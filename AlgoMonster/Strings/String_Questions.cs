using System.Reflection.Metadata.Ecma335;

public class String_Questions
{
    public int RomanToInt(string s)
    {
        var map = new Dictionary<char, int>
        {
            {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50},
            {'C', 100}, {'D', 500}, {'M', 1000}
        };

        int result = 0;

        for(int i = 0; i < s.Length; i++)
        {
            int curr = map[s[i]];
            int next = i + 1 < s.Length ? map[s[i + 1]] : 0;

            result += curr < next ? -curr : curr;
        }

        return result;
    }

    public static int Compress(char[] chars)
    {
        // ["a","a","b","b","c","c","c"]
        // a2b3c3 -> 6


        return 0;
    }

    public IList<List<string>> GroupStrings(string[] strings) 
    {
        var map = new Dictionary<string, List<string>>();

        foreach(var s in strings)
        {
            var key = CreateHash(s);

            if(!map.ContainsKey(key))
            {
                map[key] = new List<string>();
            }
            map[key].Add(s);
        }

        var res = new List<List<string>>();

        foreach(var elem in map)
        {
            res.AddRange((IEnumerable<List<string>>)elem.Value);
        }

        return res;

        string CreateHash(string str)
        {
            var parts = new List<string>();

            for(int i = 1; i < str.Length; i++)
            {
                var diff = (str[i] - str[i - 1] + 26) % 26;
                parts.Add(diff.ToString());
            }

            return string.Join(',', parts);
        }
    }

}