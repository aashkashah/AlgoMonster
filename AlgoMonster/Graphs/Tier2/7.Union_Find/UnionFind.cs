using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AlgoMonster.Graphs.Tier2._7.Union_Find
{
    /// <summary>
    /// When DSU (union find) is the BEST choice
    /// 
    /// Use Union-Find when:
    ///   Graph is undirected
    ///   You care about cycles
    ///   Edges are processed incrementally
    ///   Connectivity changes dynamically
    /// 
    /// Classic DSU problems:
    ///   Graph Valid Tree
    ///   Number of Connected Components
    ///   Redundant Connection
    ///   Kruskal’s MST
    /// </summary>
    public class UnionFind
    {

        /// <summary>
        /// to do 
        /// https://leetcode.com/problems/graph-valid-tree/
        /// </summary>
        public class Solution
        {
            public bool ValidTree(int n, int[][] edges)
            {
                if (edges.Length != n - 1) return false;

                var dsu = new DSU(n);
                foreach (var e in edges)
                {
                    if (!dsu.Union(e[0], e[1])) return false; // cycle
                }
                return true; // with n-1 edges and no cycle => connected
            }

            private class DSU
            {
                private readonly int[] parent;
                private readonly int[] rank;

                public DSU(int n)
                {
                    parent = new int[n];
                    rank = new int[n];
                    for (int i = 0; i < n; i++) parent[i] = i;
                }

                public int Find(int x)
                {
                    if (parent[x] != x) parent[x] = Find(parent[x]);
                    return parent[x];
                }

                public bool Union(int a, int b)
                {
                    int ra = Find(a), rb = Find(b);
                    if (ra == rb) return false;

                    if (rank[ra] < rank[rb]) parent[ra] = rb;
                    else if (rank[ra] > rank[rb]) parent[rb] = ra;
                    else { parent[rb] = ra; rank[ra]++; }
                    return true;
                }
            }
        }


    }
}
