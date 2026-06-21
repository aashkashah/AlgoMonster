using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.Grid
{
    internal class Dfs
    {
         /// <summary>
        /// Sentence Similarity II
        /// https://leetcode.com/problems/sentence-similarity-ii/description/
        /// Input: sentence1 = ["great","acting","skills"], sentence2 = ["fine","drama","talent"], similarPairs = [["great","good"],["fine","good"],["drama","acting"],["skills","talent"]]
        /// Output: true
        /// Explanation: The two sentences have the same length and each word i of sentence1 is also similar to the corresponding word in sentence2.
        /// </summary>
        public static bool AreSentencesSimilarTwo(
            string[] sentence1, 
            string[] sentence2, 
            IList<IList<string>> similarPairs)
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

            var visited = new HashSet<string>();

            for (int i = 0; i < sentence1.Length; i++)
            {
                var w1 = sentence1[i];
                var w2 = sentence2[i];

                if(w1 == w2) continue;

                if(!adj.ContainsKey(w1)) return false;

                visited.Clear();

                if (!DfsSimilarSentences(w1, w2)) return false;
            }

            return true;

            bool DfsSimilarSentences
            (
                string source, 
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
                    if (!visited.Contains(n) && DfsSimilarSentences(n, dest))
                        return true;
                }

                return false;
            }
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
