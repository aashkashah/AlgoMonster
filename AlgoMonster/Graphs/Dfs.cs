using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.Grid
{
    internal class Dfs
    {
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
