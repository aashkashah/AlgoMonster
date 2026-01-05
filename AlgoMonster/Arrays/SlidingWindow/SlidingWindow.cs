namespace AlgoMonster.Arrays.SlidingWindow
{
    public static class SlidingWindow
    {
        /// <summary>
        /// Find the length of the longest substring of a given string without repeating characters.
        /// Input: abccabcabcc
        /// Output: 3
        /// Input: aaaabaaa
        /// Output: 2
        /// </summary>
        public static int LongestSubstringWithoutRepeatingChars(string str)
        {
            // abccabcabec
            //       ^  ^  
            // max = 3
            // curr sum = 3
            // (c, 5) (b,7) (a,6) (e, 8)
            var left = 0;
            var charArr = str.ToCharArray();
            //var dict = new Dictionary<char, int>();
            var window = new HashSet<char>();
            var maxSum = 0;
            //var currSum = 0;

            // abccabcabcc
            for (int right = 0; right < charArr.Length; right++)
            {
                var currChar = charArr[right]; // c , ind = 2
                //if(!dict.ContainsKey(currChar))
                //{
                //    dict.Add(currChar, right); // (a,0), (b,1). (c,3)
                //    currSum++; // 3
                //    if (currSum > maxSum) maxSum = currSum; // max = 3
                //}
                //else // 
                //{
                //    // present then remove from dict and move left ptr to dict inx + 1
                //    var dictElemIndex = dict[currChar]; 
                //    left = dictElemIndex + 1; // left 3
                //    dict[currChar] = right; // (c, 3)
                //}

                while (window.Contains(currChar))
                {
                    window.Remove(charArr[left]);
                    left++;
                }
                window.Add(currChar);
                maxSum = Math.Max(maxSum, right - left + 1);
            }

            return maxSum;
        }

        /// <summary>
        /// Length Of Longest Substring
        /// https://leetcode.com/problems/longest-substring-without-repeating-characters
        /// </summary>
        public static int LengthOfLongestSubstring(string s)
        {
            var dict = new Dictionary<char, int>();
            int maxLen = 0;
            int left = 0;

            for(int right = 0; right < s.Length; right++)
            {
                if(dict.ContainsKey(s[right]))
                {
                    left = Math.Max(left, dict[s[right]]);
                }

                maxLen = Math.Max(maxLen, right - left + 1);
                dict[s[right]] = right + 1;
            }

            return maxLen;

        }

        /// <summary>
        /// https://leetcode.com/problems/longest-substring-with-at-most-two-distinct-characters/
        /// </summary>
        public static int LengthOfLongestSubstringTwoDistinct(string s)
        {
            // ccaabbb
            //   ^
            //       ^
            // atmost2 = 2
            // {c,1}, {a,3}, {b,6}
            // maxlen = 5

            if (s.Length == 0) return 0;

            var dict = new Dictionary<char, int>();
            var left = 0;
            var maxLen = 0;

            for(int right = 0; right < s.Length; right++)
            {
                var currChar = s[right];

                // at most check
                if(dict.Count < 2)
                {
                    if (!dict.ContainsKey(currChar))
                    {
                        // add element
                        dict.Add(currChar, right);
                    }
                    else
                    {
                        // update index
                        dict[currChar] = right;
                    }
                }
                else
                {
                    // count == 2
                    if (dict.ContainsKey(currChar))
                    {
                        // update index
                        dict[currChar] = right;
                    }
                    else
                    {
                        // new char encountered
                        // updated/move left ptr
                        // remove that char from dict
                        char ch = ' ';
                        int minIndex = int.MaxValue;
                        foreach(var elem in dict)
                        {
                            if(elem.Value < minIndex)
                            {
                                ch = elem.Key;  
                                minIndex = elem.Value;
                            }
                        }
                        left = minIndex + 1;
                        dict.Remove(ch);
                        dict.Add(currChar, right);
                    }

                }

                maxLen = Math.Max(maxLen, right - left + 1);

            }

            return maxLen;

        }

        /// <summary>
        /// Maximum Erasure Value
        /// https://leetcode.com/problems/maximum-erasure-value/
        /// </summary>
        public static int MaximumUniqueSubarray(int[] nums)
        {
            if (nums.Length == 0) return 0;
            // 5,2,1,2,5,2,1,2,5
            // ^
            //       ^
            //  {5, 0} {2,1} {1,2}
            var dict = new Dictionary<int, int>();
            var left = 0;
            var maxValue = 0;
            var currSum = 0;

            for(int right = 0; right < nums.Length; right++)
            {
                var currNum = nums[right];
                currSum += currNum;
                
                if(!dict.ContainsKey(currNum))
                {
                    // if not present in dict
                    dict.Add(currNum, right);
                }
                else
                {
                    // if present 
                    var index = dict[currNum];
                    while(left <= index)
                    {
                        var n = nums[left];
                        dict.Remove(n);
                        currSum -= n;

                        left++;
                    }
                    dict.Add(currNum, right);
                }

                maxValue = Math.Max(maxValue, currSum);

            }

            return maxValue;

        }

        /// <summary>
        /// Longest Nice Subarray
        /// https://leetcode.com/problems/longest-nice-subarray/
        /// </summary>
        public static int LongestNiceSubarray(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return 1;
            // 1,3,8,48,10
            //   ^
            //           ^
            // maxlen 2
            var maxlen = 0;
            var left = 0;
            int usedBits = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                while ((usedBits & nums[right]) != 0)
                {
                    usedBits = usedBits ^ nums[left];
                    left++;
                }

                // add current number to the window
                usedBits = usedBits | nums[right];

                maxlen = Math.Max(maxlen, right - left + 1);

            }

            return maxlen;

        }

        /// <summary>
        /// Longest Repeating Character Replacement
        /// Input: s = "XYYX", k = 2
        /// Output: 4
        /// Explanation: Either replace the 'X's with 'Y's, or replace the 'Y's with 'X's
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int CharacterReplacement(string s, int k)
        {
            Dictionary<char, int> count = new Dictionary<char, int>();
            int res = 0;

            int l = 0, maxf = 0;
            for (int r = 0; r < s.Length; r++)
            {
                if (count.ContainsKey(s[r]))
                {
                    count[s[r]]++;
                }
                else
                {
                    count[s[r]] = 1;
                }
                maxf = Math.Max(maxf, count[s[r]]);

                while (r - l + 1 - maxf > k)
                {
                    count[s[l]]--;
                    l++;
                }
                res = Math.Max(res, r - l + 1);
            }

            return res;
        }

        /// <summary>
        /// Minimum Size Subarray Sum
        /// Given an array of positive integers nums and a positive integer target, 
        /// return the minimal length of a subarray whose sum is greater than or equal to target. 
        /// If there is no such subarray, return 0 instead.
        /// Input: target = 7, nums = [2,3,1,2,4,3]
        /// Output: 2
        /// Explanation: The subarray[4, 3] has the minimal length under the problem constraint.
        /// </summary>
        /// <returns></returns>
        public static int MinimumSizeSubArraySum(int[] nums, int target)
        {
            int left = 0;
            int sum = 0;
            int best = int.MaxValue;

            for (int right = 0; right < nums.Length; right++)
            {
                sum = sum + nums[right];
                while(sum >= target)
                {
                    best = Math.Min(best, right - left + 1);
                    sum = sum - nums[left];
                    left++;
                }
                
            }
            return best;
        }

        /// <summary>
        /// Product of Array Except Self
        /// Given an integer array nums, return an array answer such that answer[i] is equal to 
        /// the product of all the elements of nums except nums[i].
        /// The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
        /// You must write an algorithm that runs in O(n) time and without using the division operation.
        /// Input: nums = [1,2,3,4]
        /// Output: [24, 12, 8, 6]
        /// </summary>
        /// <param name="nums"></param>
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

        /// <summary>
        ///  Maximum Average Subarray I
        ///  https://leetcode.com/problems/maximum-average-subarray-i/description/?envType=problem-list-v2&envId=sliding-window
        /// </summary>
        public static double FindMaxAverage(int[] nums, int k)
        {
            // maxAvg = 12.75
            // 2 51 42
            // 1 12 -5 -6 50 3 k = 4
            //       ^
            //               ^
            // loop start l = 2, r = 5  k-1
            // dp[l] = dp[l-1] - nums[l-1] + nums[r] 

            // init dp
            var dp = new double[nums.Length - 1]; // todo 

            // prefill dp
            for (int i = 0; i < k - 1; i++)
            {
                dp[0] += nums[i];
            }

            double avgSum = dp[0];
            int l = 1, r = k;
            while (r < nums.Length - 1)
            {
                dp[l] = dp[l - 1] - nums[l - 1] + nums[r];
                Math.Max(avgSum, dp[l] / 4);
                l++; r++;
            }

            return avgSum;
        }

        /// <summary>
        /// Fixed size sliding window
        /// Diet plan performance
        /// https://leetcode.com/problems/diet-plan-performance/description/?envType=problem-list-v2&envId=sliding-window
        /// </summary>
        public static int DietPlanPerformance(int[] calories, int k, int lower, int upper)
        {
            // lower = 1, upper = 5, k = 2
            // calPoints = 1
            // runningSum = 0
            // 6 5 0 0
            //     ^
            //       ^
            // loop r < calories.len
            // runningSum = runningSum - calories[l-1] + calories[r]

            if (k > calories.Length) return 0;

            int l = 0, r = k - 1;
            var runningSum = 0;
            var calPoints = 0;
            // initialize
            for(int i = 0; i <= r; i++) 
            {
                runningSum += calories[i];
            }
            updateCalories(runningSum);

            // sliding window
            l = 1; r = r + 1;
            while (r < calories.Length)
            {
                runningSum = runningSum - calories[l - 1] + calories[r];
                updateCalories(runningSum);
                l++; r++;
            }

            // better approach than above sliding window for loop
            // 6 5 0 0
            for(int i = k; i < calories.Length; i++) // i = k = cal[2] = 0
            {
                // sum = sum - cal[2-2] = 0
                // l++ l = 3, cal[3] = 0
                // sum = sum - cal[3-20]
                runningSum = runningSum - calories[i - k];
                updateCalories(runningSum);
            }
            // approach ends

            void updateCalories(int sum)
            {
                if (sum > upper) calPoints++;
                else if (sum < lower) calPoints--;
            }

            return calPoints;
        }

        /// <summary>
        /// Contains Duplicate II
        /// https://leetcode.com/problems/contains-duplicate-ii
        /// 1,2,3,1,2,3, k = 2
        /// false
        /// </summary>
        public static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            var hash = new HashSet<int>();

            for(int i = 0; i < nums.Length; i++)
            {
                if (i > k)
                {
                    hash.Remove(nums[i - k - 1]);
                }

                if (!hash.Add(nums[i])) return true;
            }

            return false;
        }

        /// <summary>
        /// TO DO
        /// https://leetcode.com/problems/minimum-window-substring/
        /// Input: s = "ADOBECODEBANC", t = "ABC"
        /// Output: "BANC"
        /// Explanation: The minimum window substring "BANC" includes 'A', 'B', and 'C' from string t.
        /// </summary>
        public static string MinWindow(string s, string t)
        {
            // ABC
            // ADOBECODEBANC
            // ^
            //      ^
            // {A, 1}, {D,1}, {o,1}, {b,1}, {e,1}
            var left = 0;
            var right = 0;
            var dict = new Dictionary<char, int>();
            var sArr = s.ToCharArray();

            var hash = new HashSet<char>();
            foreach(var ch in t)
            {
                hash.Add(ch);
            }

            while(left < right && right < s.Length)
            {
                // check if all chars in t are present in dict
                // if so, we found one option
                // add that option to semi-result
                if(AreAllCharsPresentinDictionary())
                {
                    // found one combination
                    // add this to semi result set
                }
                

                // char that we want in s
                if(hash.Contains(sArr[left]))
                {
                    if (!dict.ContainsKey(sArr[left]))
                    {
                        dict.Add(sArr[left], left);
                    }
                    else
                    {
                        continue;
                    }
                }

                right++;
            }


            bool AreAllCharsPresentinDictionary()
            {
                foreach(var c in hash)
                {
                    if (!dict.ContainsKey(c)) return false;
                }
                return true;
            }

            return "";
        }
    }
}
