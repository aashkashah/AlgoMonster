namespace AlgoMonster.SlidingWindow
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

                while ((r - l + 1) - maxf > k)
                {
                    count[s[l]]--;
                    l++;
                }
                res = Math.Max(res, r - l + 1);
            }

            return res;
        }
    }
}
