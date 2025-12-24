using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.Arrays
{
    public static class ArrayMisc
    {
        /// <summary>
        /// Pascal's Triange
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public static IList<IList<int>> Generate(int numRows)
        {
            var result = new List<IList<int>>();

            // i = 0
            // dp[i] = dp[i] + dp[i+1]
            var dp = new List<List<int>>();
            var elem = new List<int>() { 1 };
            dp.Add(elem);
            dp.Add(new List<int> { 1, 1 });
            
            // f this
           

            return result;
        }

        /// <summary>
        ///  Missing Ranges
        ///  https://leetcode.com/problems/missing-ranges/description/?envType=problem-list-v2&envId=array
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <returns></returns>
        public static List<List<int>> FindMissingRanges(int[] nums, int lower, int upper) 
        {
            var res = new List<List<int>>();
            // 0 1 3 50 75
            //        ^ ^ 

            // -1 lw = -2 up 50
            //   -2 -2 , 0 50

            // single element
            if (nums.Count() == 1)
            {
                if (lower - nums[0] > 1)
                {
                    res.Add(new List<int>() { lower, lower });
                }
                if(upper - nums[0] > 1)
                {
                    res.Add(new List<int>() {upper, upper });
                }
                return res;
            }

            var left = 0;
            var right = 1;

            while(right < nums.Length -1)
            {
                // check right - left
                if (nums[right] - nums[left] > 1)
                {
                    // missing num found
                    var elem = new List<int>() { nums[left]+1, nums[right]-1 };
                    res.Add(elem);
                }
                left++;
                right++;
            }
            if(upper - nums[right] > 1)
            {
                res.Add(new List<int>() { nums[right]+1, upper });
            }

            return res;
        }

    }
}
