using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.Grid
{
    using System;
    using System.Collections.Generic;

    class Graph
    {
        // For node ids like 0..n-1 or strings, both work:
        public Dictionary<int, List<int>> Adj = new Dictionary<int, List<int>>();

        public void AddEdge(int u, int v, bool undirected = true)
        {
            if (!Adj.ContainsKey(u)) Adj[u] = new List<int>();
            Adj[u].Add(v);
            if (undirected)
            {
                if (!Adj.ContainsKey(v)) Adj[v] = new List<int>();
                Adj[v].Add(u);
            }
        }
    }

}
