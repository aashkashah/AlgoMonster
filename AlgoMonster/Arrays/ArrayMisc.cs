using System.Text;

namespace AlgoMonster.Arrays
{
    /// <summary>
    /// 163. Missing Ranges https://leetcode.com/problems/missing-ranges
    /// 1200. Minimum Absolute Difference https://leetcode.com/problems/minimum-absolute-difference
    /// </summary>
    public static class ArrayMisc
    {
        /// <summary>
        /// 163. Missing Ranges https://leetcode.com/problems/missing-ranges
        /// </summary>
        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {

            var res = new List<IList<int>>();

            if (nums.Count() == 0)
            {
                res.Add(new List<int>() { lower, upper });
                return res;
            }

            // single element
            if (nums.Count() == 1)
            {
                if (lower - nums[0] > 1) res.Add(new List<int>() { lower, upper });

                if (upper - nums[0] > 1) res.Add(new List<int>() { upper, upper });

                return res;
            }

            var len = nums.Length;

            // first element 
            if (lower - nums[0] > 1) res.Add(new List<int> { lower, nums[0] - 1 });

            for (int i = 1; i < len; i++)
            {
                // check right - left
                if (nums[i] - nums[i - 1] > 1)
                {
                    var el = new List<int> { nums[i - 1] + 1, nums[i] - 1 };
                    res.Add(el);
                }
            }
            if (upper - nums[len - 1] > 1)
            {
                res.Add(new List<int>() { nums[len - 1] + 1, upper });
            }

            return res;
        }

        /// <summary>
        /// 1200 Minimum Absolute Difference
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


        public static string StringShift(string s, int[][] shift)
        {
            // abc
            // bca
            // [[1,1],[1,1],[0,2],[1,3]]
            // l = 2
            // r = 5
            // r =  3
            // abcdefg
            //  left = 3
            // defgabc
            // right = 3
            // efgabcd

            var l = 0;
            var r = 0;
            var shiftLeft = false;

            for (int i = 0; i < shift.Length; i++)
            {
                if (shift[i][0] == 0)
                {
                    // left
                    l += shift[i][1];
                }
                else
                {
                    r += shift[i][1];
                }
            }

            var len = s.Length;
            if (l > r)
            {
                // shifting left
                l = (l - r) % len;
                shiftLeft = true;
            }
            else
            {
                r = (r - l) % len;
            }

            var res = new StringBuilder();
            if (shiftLeft)
            {
                for (int i = l; i < s.Length; i++)
                {
                    res.Append(s[i]);
                }
                for (int i = 0; i < l; i++)
                {
                    res.Append(s[i]);
                }
            }
            else
            {
                for (int i = s.Length - r; i < s.Length; i++)
                {
                    res.Append(s[i]);
                }
                for (int i = 0; i < s.Length - r; i++)
                {
                    res.Append(s[i]);
                }
            }

            return res.ToString();
        }

    }
}
