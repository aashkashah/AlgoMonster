namespace AlgoMonster.Arrays.PrefixSum
{   
    public static class PrefixSumQ
    {   
        /// <summary>
        /// 238. Product of Array Except Self
        /// https://leetcode.com/problems/product-of-array-except-self
        /// </summary>>
        public static int[] ProductExceptSelf(int[] nums)
        {
            // i = 0
            // 1 2 3 4  nums
            // 1 2 6 24 prefix
            //    24  12  4  suffix  
            // 24 12 8 6  result 

            int n = nums.Length;
            int[] ans = new int[n];

            // 1) Prefix pass: ans[i] = product of nums[0..i-1]
            int prefix = 1;
            for (int i = 0; i < n; i++)
            {
                ans[i] = prefix;
                prefix *= nums[i];
            }

            // 2) Suffix pass: multiply by product of nums[i+1..n-1]
            int suffix = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                ans[i] *= suffix;
                suffix *= nums[i];
            }

            return ans;
        }

        /// <summary>
        /// 560. Subarray Sum Equals K
        /// https://leetcode.com/problems/subarray-sum-equals-k
        /// </summary>
        public static int SubarraySum(int[] nums, int k)
        {

            var sum = 0;
            var count = 0;

            // prefix sum -> how many times it's been seen
            var map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                // prefix
                sum += nums[i];

                if (sum == k) count++;

                // if (sum - k) exists as a past prefix sum,
                // those are valid subarrays ending here
                if (map.TryGetValue((sum - k), out var val))
                {
                    count += val;
                }

                // record current prefix sum
                if (!map.ContainsKey(sum)) map[sum] = 1;
                else
                    map[sum]++;
            }

            return count;
        }

        /// <summary>
        /// 523. Continuous Subarray Sum
        /// https://leetcode.com/problems/continuous-subarray-sum/
        /// </summary>

        public static bool CheckSubarraySum(int[] nums, int k)
        {
            // 0  23, 2, 4,  6,  7 
            // 0  23  25 29  35  42
            // 0  5   1  5   5 

            // prefix sum + dictionary

            var seen = new Dictionary<int, int>();
            seen[0] = 0;

            int sum = 0;

            for (int i = 1; i <= nums.Length; i++)
            {
                sum += nums[i - 1];
                int rem = sum % k;

                if (seen.ContainsKey(rem))
                {
                    if (i - seen[rem] >= 2) return true;
                }
                else
                {
                    seen[rem] = i;
                }
            }

            return false;
        }

    }
}
