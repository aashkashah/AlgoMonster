using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.DynamicProgramming
{
    public static class DP_String
    {

        /// <summary>
        /// The deletion distance of two strings is the minimum number of characters you need to 
        /// delete in the two strings in order to get the same string. For instance, 
        /// the deletion distance between "heat" and "hit" is 3:
        /// By deleting 'e' and 'a' in "heat", and 'i' in "hit", we get the string "ht" in both cases.
        /// We cannot get the same string from both strings by deleting 2 letters or fewer.
        /// </summary>
        /// <returns></returns>
        public static int FindDeletionDistance(string str1, string str2)
        {
            int m = str1.Length;
            int n = str2.Length;

            // dp[i, j] = deletion distance between
            // str1[0..i-1] and str2[0..j-1]
            int[,] dp = new int[m + 1, n + 1];

            // Base cases: one of the strings is empty
            for (int i = 0; i <= m; i++)
            {
                dp[i, 0] = i; // delete all i chars from str1
            }

            for (int j = 0; j <= n; j++)
            {
                dp[0, j] = j; // delete all j chars from str2
            }

            // Fill the DP table
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (str1[i - 1] == str2[j - 1])
                    {
                        // Chars match: carry over
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        // Chars differ: delete one char (from str1 or str2)
                        dp[i, j] = 1 + Math.Min(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            return dp[m, n];
        }

        /// <summary>
        /// Given two strings of uppercase letters source and target, list (in string form)
        /// a sequence of edits to convert from source to target that uses the least edits possible.
        /// 
        /// For example, with strings source = "ABCDEFG", and target = "ABDFFGH" 
        /// we might return: ["A", "B", "-C", "D", "-E", "F", "+F", "G", "+H"
        /// In the example, the answer of A B -C D -E F +F G +H has total number of 
        /// edits 4 (the minimum possible), and ignoring subtraction-tokens, 
        /// spells out A, B, D, F, +F, G, +H which represents the string target.

        /// If there are multiple answers, use the answer that favors removing from the source last.
        /// </summary>
        public static class DifferenceBetweenTwoStrings
        {
            public static List<char> DiffBetweenTwoString(string str1, string str2)
            {

                return null;
            }

        }
    }
}
