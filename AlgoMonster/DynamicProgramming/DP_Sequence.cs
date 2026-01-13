namespace AlgoMonster.DynamicProgramming
{
    public static class DP_Sequence
    {
        public static int HouseRobber(List<int> houseStash)
        {
            // bottom up approach 

            //return conditions
            if (houseStash.Count == 0) return 0;
            if (houseStash.Count == 1) return houseStash[0];

            // dp array
            var len = houseStash.Count;
            var dp = new int[len];

            // base conditions
            dp[0] = houseStash[0];
            dp[1] = Math.Max(houseStash[0], houseStash[1]);

            for(int i = 2; i < houseStash.Count; i++)
            {
                // at every house, check this and use previous dp
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + houseStash[i]);
            }

            return dp[len - 1];

        }

        /// <summary>
        /// You are climbing a staircase with n steps. 
        /// Each time you can climb either 1 or 2 steps. 
        /// Return the number of distinct ways to reach the top.
        /// Input: n = 3
        /// Output: 3
        /// Explanation:
        /// There are three ways: (1+1+1), (1+2), or (2+1).
        /// </summary>
        /// <returns></returns>
        public static int ClimbingStairs(int n)
        {
            // bottom up approach 

            // return conditions
            if (n == 1) return 1;
            if (n == 2) return 2;

            // dp array
            var dp = new int[n+1];

            // base conditions
            dp[1] = 1;
            dp[2] = 2;
            

            // dp logic
            for(int i = 3; i < n; i++)
            {
                dp[i] = dp[i-1] + dp[i-2];
            }

            return dp[n];
        }

        public static int NumDecodings(string s)
        {

            if (string.IsNullOrEmpty(s)) return 0;
            var memo = new int?[s.Length + 1];
            return NumDecodingsHelper(s, 0, memo);

        }

        private static int NumDecodingsHelper(string s, int indx, int?[] memo)
        {
            // return conditions
            if (s.Length == indx) return 1;
            // handle 0 case
            if (s[indx] == '0') return 0;
            if (memo[indx].HasValue) return memo[indx].Value;


            // backtracking
            // single digit
            int ways = NumDecodingsHelper(s, indx + 1, memo);

            // double digits exploration
            if (indx + 1 < s.Length)
            {
                int two = (s[indx] - '0') * 10 + (s[indx + 1] - '0');
                if (two >= 10 && two <= 26)
                    ways += NumDecodingsHelper(s, indx + 2, memo);
            }

            memo[indx] = ways;
            return ways;
        }
    }
}
