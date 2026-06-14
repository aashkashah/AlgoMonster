namespace AlgoMonster.Arrays.TwoPointers
{  
    public static class OppositeDirection
    {
        /// <summary>
        /// 16. 3Sum Closest
        /// https://leetcode.com/problems/3sum-closest
        /// </summary>
        public static int ThreeSumClosest(int[] nums, int target)
        {
            var n = nums.Length;

            Array.Sort(nums);
            var res = 0;
            var diff = int.MaxValue;

            for(int i = 0; i < n - 2; i++)
            {
                var l = i + 1;
                var r = n - 1;

                while(l < r)
                {
                    var sum = nums[l] + nums[r] + nums[i];

                    if (Math.Abs(target - sum) < Math.Abs(diff))
                    {
                        diff = target - sum;
                    }
                    if(sum < target)
                    {
                        l++;
                    }
                    else
                    {
                        r--;
                    }
                }
            }

            return target - diff;

        }

        /// <summary>
        /// 259. 3Sum Smaller
        /// https://leetcode.com/problems/3sum-smaller/
        /// find number of triplets i, j, k that satisfy
        /// nums[i] + nums[j] + nums[k]
        /// </summary>
        public static int ThreeSumSmaller(int[] nums, int target)
        {
            // -2, 0, 1, 3 target = 2

            var n = nums.Length;
            if (n < 3) return 0;

            Array.Sort(nums);
            var res = 0;

            for(int i = 0; i < n - 2; i++)
            {
                var l = i + 1;
                var r = n - 1;

                while (l < r)
                {
                    var sum = (nums[l] + nums[r] + nums[i]);

                    if(sum < target)
                    {
                        res += r - l;
                        l++;
                    }
                    else
                    {
                        r--;
                    }
                }
            }

            return res;
        }

        public static (int, int) TwoSumSorted(int[] nums, int sum)
        {
            // 2 3 5 6 8 11 18
            //   ^
            //       ^   

            var left = 0;
            var right = nums.Length;

            // loop until left < right
            while (left < right)
            {
                // left + right > sum, then right --;
                // left + right < sum, then left ++;

                var currSum = nums[left] + nums[right];

                if (currSum > sum)
                {
                    right--;
                }
                else if (currSum < sum)
                {
                    left++;
                }
                else if (currSum == sum)
                {
                    return (left, right);
                }
            }

            return (-1, -1);
        }

        public static bool IsValidPalindrome(string str)
        {
            // Do geese see God?
            //    ^
            //              ^

            // ignore alphanumeric, case agnostic 
            // until left < right..

            var left = 0;
            var right = str.Length;
            var strArray = str.ToCharArray();

            while(left < right)
            {

                while (!char.IsLetterOrDigit(strArray[left]) && left < right)
                {
                    left++;
                }

                while (!char.IsLetterOrDigit(strArray[right]) && left < right)
                {
                    right--;
                }

                if (strArray[left] != strArray[right])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
