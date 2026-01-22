using AlgoMonster.Grid;
using System.Linq;

namespace AlgoMonster.Greedy
{
    public static class JumpGame
    {

        /// <summary>
        /// Jump Game
        /// https://leetcode.com/problems/jump-game/
        /// </summary>
        public static bool CanJump(int[] nums)
        {
            int maxreach = 0;

            for(int i =0; i < nums.Length; i++)
            {
                if (i > maxreach)
                    return false;

                maxreach = Math.Max(maxreach, i+ nums[i]);
            }

            return true;
        }


        /// <summary>
        /// Jump Game II
        /// https://leetcode.com/problems/jump-game-ii
        /// </summary>
        public static int JumpGame2(int[] nums)
        {
            // 2 3 1 1 4
            int jumps = 0;

            // End of current BFS layer (reachable with `jumps` moves)
            int currentEnd = 0;

            // Farthest end of next BFS layer (reachable with `jumps + 1` moves)
            int farthest = 0;

            // We stop at n-2 because we don't need to jump from the last index
            for (int i = 0; i < nums.Length - 1; i++)
            {
                // While scanning the current layer, compute the next layer's boundary
                farthest = Math.Max(farthest, i + nums[i]);

                // Finished scanning this BFS layer -> must take a jump to advance
                if (i == currentEnd)
                {
                    jumps++;
                    currentEnd = farthest;
                }
            }

            return jumps;
        }


        /// <summary>
        /// https://leetcode.com/problems/jump-game-iii/description/
        /// </summary>
        public static bool JumpGame3(int[] arr, int start)
        {
            // This is not a greedy solution
            // Added it here for comparision
            // Graph BFS / DFS

            int n = arr.Length;
            var visited = new bool[n];
            var queue = new Queue<int>();

            queue.Enqueue(start);
            visited[start] = true;

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                if (arr[node] == 0)
                    return true;

                int jump = arr[node];

                int right = node + jump;
                int left = node - jump;

                if (right < n && !visited[right])
                {
                    visited[right] = true;
                    queue.Enqueue(right);
                }

                if (left >= 0 && !visited[left])
                {
                    visited[left] = true;
                    queue.Enqueue(left);
                }
            }

            return false;
        }
    }
}
