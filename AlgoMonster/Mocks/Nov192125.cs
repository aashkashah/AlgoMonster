namespace AlgoMonster.Mocks
{
    public static class Nov192125
    {
        /// <summary>
        /// Find the length of Longest Substring Without Repeating Characters
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            var lastIndex = new Dictionary<char, int>();
            int left = 0;
            int maxLen = 0;

            for (int right = 0; right < s.Length; right++)
            {
                char c = s[right];

                if (lastIndex.TryGetValue(c, out int prevIndex) && prevIndex >= left)
                {
                    // Move left pointer just past the previous occurrence
                    left = prevIndex + 1;
                }

                // Update last seen index of this character
                lastIndex[c] = right;

                int currentLen = right - left + 1;
                if (currentLen > maxLen)
                {
                    maxLen = currentLen;
                }
            }

            return maxLen;
        }

    }
}
