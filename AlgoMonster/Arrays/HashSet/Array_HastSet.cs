using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.Arrays.HashSet
{
    public static class Array_HastSet
    {
        /// <summary>
        ///  Longest Harmonious Subsequence
        ///  This is a “frequency map + neighbor” pattern.
        ///  https://leetcode.com/problems/longest-harmonious-subsequence/description/?envType=problem-list-v2&envId=sliding-window
        ///  
        /// A harmonious subsequence only cares about values and counts (order doesn’t matter for subsequence length). 
        /// If max − min = 1, that means the subsequence uses exactly two numbers: x and x+1 (both must appear at least once).
        /// So: count all numbers, 
        /// then for each x, if x+1 exists, candidate length = count[x] + count[x + 1].Take max.
        /// </summary>
        public static int FindLHS(int[] nums)
        {
            var freq = new Dictionary<int, int>();

            foreach (var x in nums)
            {
                //if(!freq.ContainsKey(x)) freq.Add(x, 1);
                //else freq[x]++;

                freq[x] = freq.TryGetValue(x, out int val) ? val + 1 : 1;
            }

            int best = 0;
            foreach (var kvp in freq)
            {
                var x = kvp.Key;

                if (freq.TryGetValue(x + 1, out int c))
                    best = Math.Max(best, kvp.Value + c);
            }
            return best;
        }

    }


    /// <summary>
    /// Logger rate limiter
    /// https://leetcode.com/problems/logger-rate-limiter/description
    /// Input
    /// ["Logger", "shouldPrintMessage", "shouldPrintMessage", "shouldPrintMessage", "shouldPrintMessage", "shouldPrintMessage", "shouldPrintMessage"]
    /// [[], [1, "foo"], [2, "bar"], [3, "foo"], [8, "bar"], [10, "foo"], [11, "foo"]]
    /// Output
    /// [null, true, true, false, false, false, true]
    /// </summary>
    public class Logger 
    {
        private Dictionary<string, int> log;
        public Logger()
        {
            log = new Dictionary<string, int>();
        }
        
        public bool ShouldPrintMessage(int timestamp, string message)
        {
            if(!log.ContainsKey(message))
            {
                this.log.Add(message, timestamp);
                return true;
            }

            log.TryGetValue(message, out int oldTimeStamp);

            if(timestamp - oldTimeStamp >= 10)
            {
                log.Add(message, timestamp);
                return true;
            }

            return false;
        }


    }
}
