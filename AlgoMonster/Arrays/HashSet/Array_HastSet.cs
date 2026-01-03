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

        /// <summary>
        /// Contains Duplicate II
        /// https://leetcode.com/problems/contains-duplicate-ii
        /// 1,2,3,1,2,3, k = 2
        /// false
        /// </summary>
        public static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            // this solution is not optimal
            // needs to be implemented with sliding window
            // to do

            // 1 2 3 1 2 3
            // {1,0}, {2,1},{3,2}, {1,3}, {2,4} {3,5}
            // {1, {0, 3}} {2, {1,4}}, {3, {2,5}}

            var dict = new Dictionary<int, List<int>>();

            for(int i = 0; i < nums.Length; i++)
            {
                if (dict.TryGetValue(nums[i], out var indices))
                {
                    indices.Add(i);
                    dict[nums[i]] = indices;
                }
                else
                {
                    dict.Add(nums[i], new List<int>() { i });
                }
            }

            foreach(var item in dict)
            {
               if(item.Value.Count >= 2)
                {
                    for (int i = 0; i <= item.Value.Count - 2; i++)
                    {
                        if (item.Value[i + 1] - item.Value[i] <= k) return true;
                    }
                }
                
            }

            return false;
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

        /// <summary>
        /// Isomorphic strings
        /// https://leetcode.com/problems/isomorphic-strings/description
        /// </summary>
        public bool IsIsomorphic(string s, string t)
        {
            // egg
            // add
            //   ^
            // {e,s}, {g,d} 
            if(s.Length != t.Length) return false;

            var dict = new Dictionary<char, char>();
            
            for(int i =0; i <s.Length; i++)
            {
                // if same
                if (s[i] != t[i])
                {
                    if (dict.TryGetValue(s[i], out var mapp))
                    {
                        if(mapp != t[i]) return false;
                    }
                    else
                    {
                        dict.Add(s[i], t[i]);
                    }   
                }

            }

            return true;
        }

        /// <summary>
        /// Majority Element
        /// https://leetcode.com/problems/majority-element/description
        /// O(n) space (quesstion asked for O(1))
        /// O(n) time 
        /// </summary>
        public int MajorityElement(int[] nums)
        {
            // 2 2 1 1 1 2 2
            //             ^
            // {2,4}, {1,3} 
            // maxNumber = 2
            // maxCount = 4

            var maxNumber = 0;
            var maxCount = int.MinValue;
            var dict = new Dictionary<int, int>();

            foreach (var n in nums)
            {
                if(dict.TryGetValue(n, out var num))
                {
                    num++;
                    dict[n] = num;

                    if(num > maxCount)
                    {
                        maxCount = num;
                        maxNumber = n;
                    }
                }
                else
                {
                    dict.Add(n, 1);

                    if(1 > maxCount)
                    {
                        maxCount = 1;
                        maxNumber = n;
                    }
                }
            }

            return maxNumber;
        }

        /// <summary>
        /// Majority Element
        /// https://leetcode.com/problems/majority-element/description
        /// O(1) space
        /// O(nlogn) time 
        /// </summary
        public int MajorityElement2(int[] nums)
        {
            Array.Sort(nums);
            return nums[nums.Length / 2];
        }


    }
}
