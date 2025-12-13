using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.Basic
{
    public static class WithCopilotOn
    {
        // sliding window method
        // Contains Nearby Duplicate
        // Return true if there exist indices i != j with nums[i] == nums[j] and |i - j| <= k.

        public static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            if (nums == null || nums.Length < 2 || k <= 0) return false;

            var window = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (window.Contains(nums[i]))
                    return true;

                window.Add(nums[i]);

                // keep at most k previous values in the set
                if (window.Count > k)
                    window.Remove(nums[i - k]);
            }

            return false;
        }
    }
}
