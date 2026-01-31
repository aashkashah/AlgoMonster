using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.Graphs.Tier1._4.Cycle_Detection
{
    public class CycleDetection
    {

        /// <summary>
        /// Graph Valid Tree
        /// https://leetcode.com/problems/graph-valid-tree/
        /// </summary>
        public bool ValidTree(int n, int[][] edges)
        {
            /// In the BFS solution, we are NOT explicitly checking for “more than one path”.
            /// We are proving it cannot exist by using the n − 1 edges rule.
            
            // This line is doing all the cycle detection, before BFS even starts.
            if (edges.Length != n - 1) return false;

            // Any connected undirected graph with n or more edges must contain a cycle.
            // edges > n - 1 → guaranteed cycle
            // edges < n - 1 → guaranteed disconnected
            // edges == n - 1 → maybe a tree (need connectivity check)

            // we don’t detect multiple paths —
            // we prove they cannot exist.

            // Connected + (n − 1 edges) ⇒ no cycles ⇒ exactly one path between every pair

            var graph = new List<int>[n];
            for(int i = 0; i< n; i++)
            {
                graph[i] = new List<int>();
            }

            foreach(var e in edges)
            {
                graph[e[0]].Add(e[1]);
                graph[e[1]].Add(e[0]);
            }

            var visited = new bool[n];
            var q = new Queue<int>();
            q.Enqueue(0);
            visited[0] = true;

            while(q.Count > 0)
            {
                var node = q.Dequeue();
                foreach(var nei in graph[node])
                {
                    if (!visited[nei])
                    {
                        visited[nei] = true;
                        q.Enqueue(nei);
                    }
                }
            }

            // check for disjoint edge
            for(int i = 0; i < n; i++)
            {
                if (!visited[i]) return false;
            }

            return true;
        }
    }
}
