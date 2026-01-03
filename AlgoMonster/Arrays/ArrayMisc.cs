namespace AlgoMonster.Arrays
{
    public static class ArrayMisc
    {
        /// <summary>
        /// Pascal's Triange
        /// </summary>
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

        /// <summary>
        /// Minimum Absolute Difference
        /// https://leetcode.com/problems/minimum-absolute-difference/description
        /// Input: arr = [4,2,1,3]
        /// Output: [[1, 2],[2, 3],[3, 4]]
        /// </summary>
        public static IList<IList<int>> MinimumAbsDifference(int[] arr)
        {
            // min diff = 4
            // -14 -10 -4 3 8 19 23 24 27
            //                   ^
            //                    ^
            // [-14,-10],[9,23],[23,27]

            if (arr.Length == 0) return null;
            if (arr.Length == 1) return new List<IList<int>>() { new List<int>() { arr[0] } };

            Array.Sort(arr);
            var res = new List<IList<int>>();
            var minAbs = int.MaxValue;
            
            for (int i = 1; i < arr.Length; i++) 
            {
                var diff = arr[i - 1] - arr[i];
                minAbs = Math.Max(minAbs, diff);
                if(diff <= minAbs)
                {
                    res.Add(new List<int>() { arr[i - 1], arr[i] });
                }
            }

            foreach(var elem in res)
            {
                var diff = elem[0] - elem[1];
                if(!(diff <= minAbs)) res.Remove(elem);
            }

            return res;
        }

        /// <summary>
        /// Sort Colors
        /// https://leetcode.com/problems/sort-colors
        /// Input: nums = [2,0,2,1,1,0]
        /// Output: [0, 0, 1, 1, 2, 2]
        /// </summary>
        public static void SortColors(int[] nums)
        {
            int zeroCount = 0, oneCount = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0) { zeroCount++; }
                else if (nums[i] == 1) { oneCount++; }
            
            }

            int index = 0;
            while (index < zeroCount) 
            {
                nums[index] = 0;
                index++;
            }
            while(index < oneCount + zeroCount)
            {
                nums[index] = 1;
                index++;
            }
            while(index < nums.Length)
            {
                nums[index] = 2;
                index++;
            }
        }

    }
}
