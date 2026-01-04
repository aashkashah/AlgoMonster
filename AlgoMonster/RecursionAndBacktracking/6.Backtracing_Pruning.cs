using System.Text;

namespace AlgoMonster.RecursionAndBacktracking
{
    public static class Backtracing_Pruning
    {

        private static List<string> _validStrings = new List<string>();

        /// <summary>
        /// Combination Sum
        /// https://leetcode.com/problems/combination-sum/description
        /// Input: candidates = [2, 3, 5], target = 8
        /// Output: [[2, 2, 2, 2],[2, 3, 3],[3, 5]]
        /// </summary>
        public static IList<List<int>> CombinationSum(int[] candidates, int target)
        {
            var res = new List<List<int>>();
            CombinationSumHelper(candidates, 0, target, new List<int>(), ref res);

            return res;
        }

        private static void CombinationSumHelper(int[] nums, int start, int remain, List<int> currList, ref List<List<int>> res)
        {
            // 2, 3, 5
            if (remain < 0) return;
            if(remain == 0)
            {
                res.Add(currList);
                return;
            }

            for (int i = start; i < nums.Length; i++) 
            {
                // i = 0, elem = 2, list = {2}
                // i = 0, elem = 2, list = {2, 2}
                // i = 0, elem = 2, list = {2, 2, 2}
                // i = 0, elem = 2, list = {2, 2, 2, 2} -- add to result list
                // next remove 2 -- i = 0, elem = 2, list = {2, 2, 2}
                // i = 1, elem = 3, list = {2, 2, 2, 3} -- return 
                // next remove 3, list = {2, 2, 2}
                // i = 2, elem = 5, list = {2, 2, 2, 5} -- return 
                // next remove 5, list {2, 2, 2}

                var elem = nums[i];
                
                // choose
                currList.Add(elem);

                // explore -- important thing sending i
                CombinationSumHelper(nums, i, remain - nums[i], currList, ref res);

                //unchoose
                currList.Remove(elem);
            }
        }

        /// <summary>
        /// https://leetcode.com/problems/combination-sum-ii/
        /// same number (index) can't be re-used
        /// </summary>
        public static IList<List<int>> CombinationSum2(int[] candidates, int target)
        {
            var res = new List<List<int>>();
            Array.Sort(candidates);
            CombinationSum2Helper(candidates, 0, target, new List<int>(), ref res);

            return res;
        }

        private static void CombinationSum2Helper(int[] nums, int index, int remain, List<int> currList, ref List<List<int>> res)
        {
            // return 
            if (remain < 0) return;
            if (remain == 0)
            {
                res.Add(currList);
                return;
            }

            for (int i = index; i < nums.Length && remain >= nums[i]; i++)
            {
                //choose
                var elem = nums[i];
                currList.Add(nums[i]);

                CombinationSum2Helper(nums, i + 1, remain - nums[i], currList, ref res);

                currList.Remove(elem);
            }
        }

        /// <summary>
        /// https://leetcode.com/problems/combination-sum-iii/description/
        /// same number can't be re-used + list can have only 3 numbers
        /// </summary>
        public static List<List<int>> CombinationSum3(int k, int n)
        {
            var res = new List<List<int>>();
            var nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            CombinationSum2Helper(nums, 0, n, new List<int>(), ref res);

            return res;
        }

        private static void CombinationSum3Helper(int[] nums, int index, int remain, List<int> currList, ref List<List<int>> res)
        {
            if(remain < 0 || currList.Count > 3) return;
            if (remain == 0 && currList.Count != 3) return;
            if (remain == 0 && currList.Count == 3)
            {
                res.Add(currList);
                return;
            }

            // recurse
            for (int i = index; i < nums.Length; i++)
            {
                var elem = nums[i];

                // choose
                currList.Add(elem);

                //explore
                CombinationSum3Helper(nums, i+1, remain - nums[i], currList,ref res);

                // unchoose
                currList.RemoveAt(currList.Count - 1);
            }
                
        }

        /// <summary>
        /// Generate Parenthesis
        /// https://leetcode.com/problems/generate-parentheses/
        /// </summary>
        public static IList<string> GenerateParenthesis(int n)
        {
            // n = 3
            // ((())), ()()(), (())(), ()(())
            // (((
            var res = new List<string>();
            GenerateParenthesisHelper(n, 0, 0, res, new StringBuilder());
            return res;
        }

       private static void GenerateParenthesisHelper(
           int n, int openBraceCount, int closeBraceCount, 
           List<string> res, StringBuilder curr)
       {
            // exit condition
            if(curr.Length == 2*n)
            {
                res.Add(curr.ToString());
                return;
            }

            // recursion

            // explore '('
            if(openBraceCount < n)
            {
                curr.Append("(");
                GenerateParenthesisHelper(n, openBraceCount + 1, closeBraceCount, res, curr);
                curr.Remove(curr.Length - 1, 1);
            }

            if(openBraceCount > closeBraceCount)
            {
                curr.Append(")");
                GenerateParenthesisHelper(n, openBraceCount, closeBraceCount + 1, res, curr);
                curr.Remove(curr.Length - 1, 1);
            }
        }

        /// <summary>
        /// Generate Binary strings without adjacent zeros
        /// https://leetcode.com/problems/generate-binary-strings-without-adjacent-zeros/description/
        /// Input: n = 3
        /// Output: ["010", "011", "101", "110", "111"]
        /// </summary>
        public static IList<string> ValidStrings(int n)
        {
            ValidStringsHelper(new StringBuilder(), n);
            return _validStrings;
        }

        private static void ValidStringsHelper(StringBuilder curr, int n)
        {
            // exit condition
            if (curr.Length == n)
            {
                _validStrings.Add(curr.ToString());
                return;
            }

            // backtracting 
            // choice 1: 0
            curr.Append("1");
            ValidStringsHelper(curr, n);
            curr.Length--;

            if(curr.Length == 0 || curr[curr.Length -1] != '0')
            {
                curr.Append("0");
                ValidStringsHelper(curr, n);
                curr.Length--;
            }
        }

    }
    
}
