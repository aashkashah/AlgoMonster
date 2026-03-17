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
            var adj = new Dictionary<string, HashSet<string>>();

            
            foreach (var pair in similarPairs)
            {
                var a = pair[0];
                var b = pair[1];

                if(!adj.TryGetValue(a, out var setA))
                {
                    setA = new HashSet<string>();
                    adj[a] = setA;
                }

                if(!adj.TryGetValue(b, out var setB))
                {
                    setB = new HashSet<string>();
                    adj[b] = setB;
                }

                setA.Add(b);
                setB.Add(a);
            }

            for (int i = 0; i < sentence1.Length; i++)
            {
                var w1 = sentence1[i];
                var w2 = sentence2[i];

                if(w1 == w2) continue;

                if(!adj.ContainsKey(w1)) return false;

                var visited = new HashSet<string>();

                if (!DfsSimilarSentences(w1, adj, visited, w2)) return false;
            }

            return true;

        }

        private static bool DfsSimilarSentences
        (
            string source, 
            Dictionary<string, HashSet<string>> adj,
            HashSet<string> visited,
            string dest
        )
        {
            if (source == dest) return true;

            // already visited, we exhausted search
            if (!visited.Add(source)) return false;

            // no mapping exist
            if(!adj.TryGetValue(source, out var neighbors)) return false;

            foreach(var n in neighbors)
            {
                if (!visited.Contains(n) && DfsSimilarSentences(n, adj, visited, dest))
                    return true;
            }

            return false;

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
