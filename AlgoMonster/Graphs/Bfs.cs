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
        /// Sentence Similarity II
        /// https://leetcode.com/problems/sentence-similarity-ii/description/
        /// Input: sentence1 = ["great","acting","skills"], sentence2 = ["fine","drama","talent"], similarPairs = [["great","good"],["fine","good"],["drama","acting"],["skills","talent"]]
        /// Output: true
        /// Explanation: The two sentences have the same length and each word i of sentence1 is also similar to the corresponding word in sentence2.
        /// </summary>
        public static bool AreSentencesSimilarTwo(string[] sentence1, string[] sentence2, IList<IList<string>> similarPairs)
        {
            if(sentence1.Length != sentence2.Length) return false;

            // create graph using each pair of similarPairs
            Dictionary<string, HashSet<string>> adj = new Dictionary<string, HashSet<string>>();


            foreach (var pair in similarPairs)
            {
                if (!adj.TryGetValue(pair[0], out var set1))
                {
                    set1 = new HashSet<string>();
                    adj[pair[0]] = set1;
                }
                set1.Add(pair[1]);

                if (!adj.TryGetValue(pair[1], out var set2))
                {
                    set2 = new HashSet<string>();
                    adj[pair[1]] = set2;
                }
                set2.Add(pair[0]);
            }

            for (int i = 0; i < sentence1.Length; i++)
            {
                if (sentence1[i].Equals(sentence2[i]))
                {
                    continue;
                }
                //if (adj.ContainsKey(sentence1[i]) && adj.ContainsKey(sentence2[i]) &&
                //        BfsSimilarSentences(sentence1[i], adj, sentence2[i]))
                //{
                //    continue;
                //}
                return false;
            }

            return false;

        }

        private static void BfsSimilarSentences(string source, HashSet<string> abj, string dest)
        {

        }

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
