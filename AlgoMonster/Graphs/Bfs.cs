using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        /// <summary>
        /// Sentence Similarity II
        /// https://leetcode.com/problems/sentence-similarity-ii/description/
        /// Input: sentence1 = ["great","acting","skills"], sentence2 = ["fine","drama","talent"], similarPairs = [["great","good"],["fine","good"],["drama","acting"],["skills","talent"]]
        /// Output: true
        /// Explanation: The two sentences have the same length and each word i of sentence1 is also similar to the corresponding word in sentence2.
        /// </summary>
        /// <param name="sentence1"></param>
        /// <param name="sentence2"></param>
        /// <param name="similarPairs"></param>
        /// <returns></returns>
        public bool AreSentencesSimilarTwo(string[] sentence1, string[] sentence2, IList<IList<string>> similarPairs)
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

    }
}
