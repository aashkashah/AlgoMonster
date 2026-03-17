namespace AlgoMonster.Arrays.SlidingWindow
{
    public class SW_CountValid
    {

        /// <summary>
        /// Different pattern
        /// 713. Subarray Product Less Than K
        /// https://leetcode.com/problems/subarray-product-less-than-k/
        /// </summary>
        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            // went down incorrect prefix, suffix path.
            // this is asimple sliding windw, where
            // the trick is to divide the removed elem to make window valid again

            if (k <= 1) return 0;

            var l = 0;
            var product = 1;
            var res = 0;

            for (int r = 0; r < nums.Length; r++)
            {
                // calculate window
                product = product * nums[r];

                // make window valid again
                while (product >= k)
                {
                    product = product / nums[l];
                    l++;
                }

                // add/compute new correct window size
                res += r - l + 1;
            }

            return res;

        }
    }
}
