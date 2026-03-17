using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.DynamicProgramming
{
    /// <summary>
    /// Longest Palindromic Substring
	/// Palindromic Substrings
    /// Longest Palindromic Subsequence
    /// </summary>
    public class DP_Interval
    {
        public string LongestPalindrome(string s)
        {
            int n = s.Length;
            bool[,] dp = new bool[n, n];
            int[] ans = new int[] { 0, 0 };

            for (int i = 0; i < n; i++)
            {
                dp[i, i] = true;
            }

            for (int i = 0; i < n - 1; i++)
            {
                if (s[i] == s[i + 1])
                {
                    dp[i, i + 1] = true;
                    ans = new int[] { i, i + 1 };
                }
            }

            for (int diff = 2; diff < n; diff++)
            {
                for (int i = 0; i < n - diff; i++)
                {
                    int j = i + diff;
                    if (s[i] == s[j] && dp[i + 1, j - 1])
                    {
                        dp[i, j] = true;
                        ans = new int[] { i, j };
                    }
                }
            }

            int start = ans[0];
            int end = ans[1];
            return s.Substring(start, end - start + 1);
        }

        /// <summary>
        /// 647. Palindromic Substrings
        /// https://leetcode.com/problems/palindromic-substrings/
        /// </summary>
        public int CountSubstrings(string s)
        {

            var res = 0;

            // countodd length palindrome
            for(int i = 0; i < s.Length;i++)
            {
                var l = i;
                var r = i;
                while (l >= 0 && r < s.Length && s[l] == s[r])
                {
                    res++;
                    l--;
                    r++;
                }

                l = i; r = i + 1;
                while (l >= 0 && r < s.Length && s[l] == s[r])
                {
                    res++;
                    l--;
                    r++;
                }
            }

            return res;

        }
    }


}
