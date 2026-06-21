namespace AlgoMonster.Grid
{
    static class Bfs
    {
        public static Dictionary<int, int> BfsParents(Dictionary<int, List<int>> adj, int start)
        {
            var q = new Queue<int>();
            var visited = new HashSet<int>();
            var parent = new Dictionary<int, int>(); // parent[v] = previous node on shortest path

            q.Enqueue(start);
            visited.Add(start);
            parent[start] = -1; // root has no parent

            while (q.Count > 0)
            {
                int u = q.Dequeue();
                if (!adj.ContainsKey(u)) continue;
                foreach (var v in adj[u])
                {
                    if (visited.Add(v)) // true the first time we see v
                    {
                        parent[v] = u;
                        q.Enqueue(v);
                    }
                }
            }
            return parent;
        }

        /// <summary>
        /// https://leetcode.com/problems/keys-and-rooms/
        /// </summary>
        public static bool CanVisitAllRooms(List<List<int>> rooms)
        {
            //// 
            //// hash = {}
            //var keys = new HashSet<int>() { 0 };
            //var index = 0;

            //foreach (var roomKeys in rooms)
            //{
            //    if (!keys.Contains(index))
            //        return false;

            //    foreach(var key in roomKeys)
            //    {
            //        if (!keys.Contains(key)) keys.Add(key);
            //    }
            //}

            //return true;

            int n = rooms.Count;
            var visited = new HashSet<int>();
            var q = new Queue<int>();

            visited.Add(0);
            q.Enqueue(0);

            while (q.Count > 0)
            {
                int room = q.Dequeue();
                foreach(int key in rooms[room])
                {
                    if (visited.Add(key))   // true only if it was new
                        q.Enqueue(key);
                }
            }

            return visited.Count == n;

        }

        /// <summary>
        /// https://leetcode.com/problems/number-of-provinces
        /// </summary>
        public static int FindCircleNum(int[][] isConnected)
        {

            // 1 2 3
            // 1 1 0  1
            // 1 1 0  2
            // 0 0 1  3

            // city: 1 - 1, 2 - 1

            // 1 2 3  
            // 1 0 0 1
            // 0 1 0 2
            // 0 0 1 3

            // add, every connection if reverse connection exists
            // 
            // adjacency list
            // 1 -> 2 -> 4
            // 2 -> 1 -> 5
            // 3 -> 3

            int n = isConnected.Length;
            int components = 0;
            bool[] visit = new bool[n];

            for (int i = 0; i < n; i++)
            {
                if (!visit[i])
                {
                    components++;
                    FindCircleNumbfs(i, isConnected, visit);
                }
            }

            return components;
        }

        private static void FindCircleNumbfs(int node, int[][] isConnected, bool[] visit)
        {
            var q = new Queue<int>();
            q.Enqueue(node);
            visit[node] = true;

            while (q.Count > 0)
            {
                node = q.Dequeue();
                for (int i = 0; i < isConnected.Length; i++)
                {
                    if (isConnected[node][i] == 1 && !visit[i])
                    {
                        q.Enqueue(i);
                        visit[i] = true;
                    }
                }
            }

        }

    }
}
