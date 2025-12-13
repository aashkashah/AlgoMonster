using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AlgoMonster.Search
{
    public class BinarySearch
    {
        /// <summary>
        /// There is an integer array nums sorted in ascending order (with distinct values).
        /// Prior to being passed to your function, nums is possibly left rotated at an 
        /// unknown index k(1 <= k<nums.length) such that the resulting 
        /// array is [nums[k], nums[k + 1], ..., nums[n - 1], nums[0], nums[1], ..., nums[k - 1]] (0-indexed). 
        /// For example, [0, 1, 2, 4, 5, 6, 7] might be left rotated by 3 indices and become [4, 5, 6, 7, 0, 1, 2].
        /// Given the array nums after the possible rotation and an integer target, 
        /// return the index of target if it is in nums, or -1 if it is not in nums.
        /// You must write an algorithm with O(log n) runtime complexity.
        /// 
        /// Input: nums = [4,5,6,7,0,1,2], target = 0
        /// Output: 4
        /// Input: nums = [4,5,6,7,0,1,2], target = 3
        /// Output: -1
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SiftedSearchArray(int[] nums, int target)
        {
            // 4 5 6 7 8 9 0 1 2 target = 9
            //         ^
            //         ^  
            //             ^

            // mid, check if target < left then move left to mid+1
            //      if target > left 
            //            if target < mid, right mid - 1
            //            if target > mid, left mid +1

            var left = 0;
            var right = nums.Length - 1;   
            
            while (left < right)
            {
                var mid = (left + right) / 2;
                if(target < left)
                {
                    left = mid + 1;
                }
                else if (target > mid) 
                {
                    if (target < mid)
                    {
                        right = mid - 1;
                    }
                    else if (target > mid)
                    {
                        left = mid + 1;
                    }
                }
            }

            return -1;
        }
    }
}
