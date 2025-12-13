using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.Grid
{
    class Bfs
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

        public void DfsIterative(Dictionary<int, List<int>> adj, int start, HashSet<int> visited)
        {
            var st = new Stack<int>();
            st.Push(start);

            while (st.Count > 0)
            {
                int u = st.Pop();
                if (!visited.Add(u)) continue; // first time we pop it and mark visited

                if (!adj.ContainsKey(u)) continue;
                foreach (var v in adj[u])
                {
                    if (!visited.Contains(v))
                        st.Push(v);
                }
            }
        }


    }
}
