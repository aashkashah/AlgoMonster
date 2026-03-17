namespace AlgoMonster.Search
{
    public class BinarySearchWPrefixSum
    {
        /// <summary>
        /// 528. Random Pick with Weight
        /// https://leetcode.com/problems/random-pick-with-weight/description
        /// </summary>

        public int PickIndex(int[] w)
        {
            // idea:
            // build prefix sum, generate a random number and find where it lands

            var prefixSums = new int[w.Length];
            var random = new Random();

            prefixSums[0] = w[0];
            for (int i = 1; i < w.Length; i++)
            {
                prefixSums[i] = prefixSums[i - 1] + w[i];
            }

            int totalweights = prefixSums[prefixSums.Length - 1];

            // pick a randowm number between 1 and totalweight (inclusive)
            int target = random.Next(1, totalweights + 1);

            // binary search, find the first prefix sum >= target
            int l = 0;
            int r = prefixSums.Length - 1;

            while (l < r)
            {
                int m = (l + r) / 2;

                if (prefixSums[m] < target)
                    l = m + 1;
                else
                    r = m; // mid could be the answer, don't exclude it
            }

            return l;
        }
    }
}
