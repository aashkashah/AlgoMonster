namespace AlgoMonster.Graphs.Tier2._7.Union_Find
{
    /*
     * 
     *  undirected / find cycles          → Union-Find
        undirected / shortest path        → BFS (unweighted), Dijkstra (weighted)
        undirected / traversal            → BFS / DFS
        directed / cycle + topo order     → Kahn's
        directed / cycle detection only   → DFS + recursion stack
    */

    public class UnionFind
    {
        /// <summary>
        /// 261. Graph Valid Tree
        /// https://leetcode.com/problems/graph-valid-tree/
        /// </summary>
        public bool ValidTree(int n, int[][] edges)
        {
            if (edges.Length != n - 1) return false;

            // union find
            var parent = new int[n];

            // each node is it's own parent
            for (int i = 0; i < n; i++)
                parent[i] = i;

            foreach (var e in edges)
            {
                int rootA = Find(parent, e[0]);
                int rootB = Find(parent, e[1]);

                if (rootA == rootB) return false; // same root = cycle

                // union: merge the two sets
                parent[rootA] = rootB;
            }

            return true;
        }
       

        /// <summary>
        /// 547. Number of Provinces
        /// https://leetcode.com/problems/number-of-provinces/
        /// </summary>
        public int FindCircleNum(int[][] isConnected)
        {
            /* union find

                The key insight:** Union-Find doesn't care whether input is edge list or adjacency matrix. 
                Your job is just to extract `(i, j)` pairs and feed them in.

            */

            var n = isConnected.Length;
            var parent = new int[n];
            var components = n;

            for (int i = 0; i < n; i++) parent[i] = i;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (isConnected[i][j] == 1)
                    {
                        var rootA = Find(parent, i);
                        var rootB = Find(parent, j);

                        if (rootA != rootB)
                        {
                            // as they get merged, we decrease components
                            parent[rootA] = rootB;
                            components--;
                        }
                    }
                }
            }

            return components;
        }

        /// <summary>
        /// 323. Number of Connected Components in an Undirected Graph
        /// https://leetcode.com/problems/number-of-connected-components-in-an-undirected-graph
        /// </summary>
        public int CountComponents(int n, int[][] edges)
        {
            // each node is it's own parent to start
            var parent = new int[n];
            for (int i = 0; i < n; i++) parent[i] = i;

            foreach (var e in edges)
            {
                var rootA = Find(parent, e[0]);
                var rootB = Find(parent, e[1]);

                // union: merge
                parent[rootA] = rootB;
            }

            var components = 0;
            for (int i = 0; i < parent.Length; i++)
            {
                if (parent[i] == i) components++;
            }

            return components;
        }

        private int Find(int[] parent, int node)
        {
            // return the top most group/parent
            while (parent[node] != node)
                node = parent[node];
            return node;
        }

    }
}
