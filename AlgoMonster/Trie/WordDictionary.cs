using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.Trie
{
    public class WordDictionary
    {
        private readonly TrieNode _root = new TrieNode();

        public void AddWord(string word)
        {
            var node = _root; node.PassCount++;
            foreach (var ch in word)
            {
                if (!node.Children.TryGetValue(ch, out var next))
                {
                    next = new TrieNode();
                    node.Children[ch] = next;
                }
                node = next; node.PassCount++;
            }
            node.IsEnd = true; node.EndCount++;
        }

        public bool Search(string pattern) => Dfs(_root, pattern, 0);

        private bool Dfs(TrieNode node, string p, int i)
        {
            if (i == p.Length) return node.IsEnd;
            char ch = p[i];
            if (ch == '.')
            {
                foreach (var kv in node.Children)
                    if (Dfs(kv.Value, p, i + 1)) return true;
                return false;
            }
            else
            {
                return node.Children.TryGetValue(ch, out var next) && Dfs(next, p, i + 1);
            }
        }
    }

}
