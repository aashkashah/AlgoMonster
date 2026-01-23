using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.Design
{

    /// <summary>
    /// https://leetcode.com/problems/design-file-system
    /// Input: 
    /// ["FileSystem", "createPath", "get"]
    /// [[], ["/a", 1], ["/a"]]
    /// Output: 
    /// [null, true, 1]
    /// </summary>
    public class FileSystem
    {
        // if path exists or parent doesnt exist -> return false
        // if path doesn't exist -> create path
        // associate value to new path (if possible)
        // /leet/code val =2
        // /c/d val=1

        private Dictionary<string, int> freq = new Dictionary<string, int>();

        public FileSystem()
        {

        }

        public bool CreatePath(string path, int value)
        {
            // extract path values, split by /
            // if more than one splits present
            // last value is new creation
            // if multiple, check parent string present
            // remove parent and add new path 
            // if single /
            // create new path

            // StringSplitOptions.RemoveEmptyEntries is the key,
            // without string split options, result for "/a" would be ["", "a"]

            if (string.IsNullOrEmpty(path) || path == "/" || freq.ContainsKey(path))
                return false;

            var parts = path.Split("/", StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) return false;

            // creating directory under root
            if (parts.Length == 1)
            {
                freq.Add(path, value);
                return true;
            }

            // parent present
            var sb = new StringBuilder();

            for (int i = 0; i < parts.Length - 1; i++)
            {
                sb.Append("/");
                sb.Append(parts[i]);
            }

            var parent = sb.ToString();

            // parent must exist
            if (!freq.ContainsKey(parent))
                return false;

            freq.Add(path, value);
            return true;

        }

        public int Get(string path)
        {
            if(freq.ContainsKey(path)) return freq[path];
            return -1;
        }
    }
}
