namespace AlgoMonster.Arrays.PrefixSum
{
    /// <summary>
    /// 238. Product of Array Except Self https://leetcode.com/problems/product-of-array-except-self/description/
    /// </summary>
    public static class PrefixSumQ
    {
        /// <summary>
        /// Given an array of integers arr and a target value, 
        /// find a subarray that sums to the target. Return the start and end indices of the subarray.
        /// Input: arr = [1, -20, -3, 30, 5, 4], target = 7
        /// Output: [1, 4]
        /// Explanation: The subarray [-20, -3, 30] from index 1 (inclusive) to 4 (exclusive) sums to 7.
        /// </summary>
        /// <returns></returns>
        public static int FindPrefixSum()
        {
            // 10 1 -20 -3 30 5 4  target= 7
            // ^   
            //           ^
            //           


            return -1;
        }
        /// <summary>
        /// 238. Product of Array Except Self
        /// https://leetcode.com/problems/product-of-array-except-self/description/
        /// </summary>>
        /// <returns></returns>
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

    }
}
