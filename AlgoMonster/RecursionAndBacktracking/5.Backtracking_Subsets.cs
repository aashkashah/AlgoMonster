using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.RecursionAndBacktracking
{
    public static class Backtracking_Subsets
    {
        /// <summary>
        /// Input: { "Jane", "Marty", "Joe", "Susan" }
        /// </summary>
        /// <returns></returns>
        public static void GenerateAllCombinationOfSublists()
        {
            GenerateSublistHelper(
               new List<string>() { "Jane", "Marty", "Joe", "Susan" },
               new List<string>()
               );
        }

        public static void GenerateSublistHelper(List<string> list, List<string> chosen)
        {
            //base case
            if (list.Count == 0) Console.WriteLine(chosen);

            // recursion
            for (int i = 0; i < list.Count; i++)
            {
                string s = list[i];

                // choose
                list.RemoveAt(i);

                // explore with
                chosen.Add(s);
                GenerateSublistHelper(list, chosen);

                // explore without
                chosen.RemoveAt(i);
                GenerateSublistHelper(list, chosen);

                //unchoose
                list.Add(s);
            }

        }


        /// <summary>
        /// Given an array of distinct integers nums, return all possible subsets.
        /// Input: [2,4,3]
        /// Output: [[], [2], [4], [3], [2, 4], [2, 3], [4, 3], [2, 4, 3]]
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static List<List<int>> GenerateSubsets(int[] nums)
        {
            // your code goes here
            var res = new List<List<int>>();
            //GenerateSubsetsHelper(nums, nums.Length - 1, new List<int>(), res);
            GenerateSubsetsHelperForwardIndx(nums, 0, new List<int>(), res);
            return res;
        }

        private static void GenerateSubsetsHelper(int[] nums, int indx, List<int> subset, List<List<int>> subsets)
        {
            // return condition
            if(indx <0)
            {
                subsets.Add(new List<int>(subset));
                return;
            }

            // include
            subset.Add(nums[indx]);
            // explore
            GenerateSubsetsHelper(nums, indx -1, subset, subsets);

            // exclude
            subset.RemoveAt(subset.Count - 1);
            // explore
            GenerateSubsetsHelper(nums, indx - 1, subset, subsets);
        }

        private static void GenerateSubsetsHelperForwardIndx(int[] nums, int indx, List<int> subset, List<List<int>> subsets)
        {
            if(indx ==  nums.Length)
            {
                subsets.Add(new List<int>(subset));
                return;
            }

            // 1) include nums[idx]
            subset.Add(nums[indx]);
            GenerateSubsetsHelperForwardIndx(nums, indx + 1, subset, subsets);

            // undo include
            subset.RemoveAt(subset.Count - 1);

            // 2) exclude nums[idx] (just move on without adding)
            GenerateSubsetsHelperForwardIndx(nums, indx + 1, subset, subsets);
        }

        //public static int SubsetXORSum(int[] nums)
        //{

        //}

        //private static int SubsetXORSumHelper(int[] nums)
        //{
        //    // return condition

        //    // backtracking

        //    // choose

        //    // explore

        //    // undo choose
        //}


    }
    

}
