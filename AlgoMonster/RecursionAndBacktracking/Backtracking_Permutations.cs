using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.RecursionAndBacktracking
{
    public static class Backtracking_Permutations
    {
        static IList<IList<int>> _permuteRes = new List<IList<int>>();
        public static IList<IList<int>> Permute(int[] nums)
        {
            // 1 2 3
            // 1 3 2
            // 2 1 3

            PermuteHelper(nums, new List<int>());
            return _permuteRes;
        }

        private static void PermuteHelper(int[] nums, List<int> curr)
        {
            if(curr.Count == nums.Length)
            {
                _permuteRes.Add(new List<int>(curr));
                return;
            }

            foreach(int num in nums)
            {
                if (!curr.Contains(num))
                {
                    curr.Add(num);
                    PermuteHelper(nums, curr);
                    curr.Remove(nums.Length - 1);

                }
            }
        }
    }
}
