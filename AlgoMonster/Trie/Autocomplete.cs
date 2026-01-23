namespace AlgoMonster.Trie
{
    using System;
    using System.Collections.Generic;

    public class TrieNode
    {
        public readonly Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
        public bool IsEnd;
        public int PassCount; // how many words pass through this node
        public int EndCount;  // how many words end at this node (handles duplicates)
    }

    public class Trie
    {
        private readonly TrieNode _root = new TrieNode();

        public void Insert(string word)
        {
            if (word == null) throw new ArgumentNullException(nameof(word));
            var node = _root;
            node.PassCount++;
            foreach (var ch in word)
            {
                if (!node.Children.TryGetValue(ch, out var next))
                {
                    next = new TrieNode();
                    node.Children[ch] = next;
                }
                node = next;
                node.PassCount++;
            }
            node.IsEnd = true;
            node.EndCount++;
        }

        public bool Search(string word)
        {
            var node = FindNode(word);
            return node != null && node.IsEnd;
        }

        public bool StartsWith(string prefix) => FindNode(prefix) != null;

        public int CountPrefix(string prefix)
        {
            var node = FindNode(prefix);
            return node?.PassCount ?? 0;
        }

        public List<string> Autocomplete(string prefix, int k = 5)
        {
            var res = new List<string>();
            var start = FindNode(prefix);
            if (start == null) return res;

            var stack = new Stack<(TrieNode node, string path)>();
            stack.Push((start, prefix));

            while (stack.Count > 0 && res.Count < k)
            {
                var (node, path) = stack.Pop();
                if (node.IsEnd)
                {
                    for (int i = 0; i < node.EndCount && res.Count < k; i++)
                        res.Add(path); // include duplicates if they exist
                }
                // DFS order doesn’t matter in interviews
                foreach (var kv in node.Children)
                    stack.Push((kv.Value, path + kv.Key));
            }
            return res;
        }

        private TrieNode FindNode(string s)
        {
            if (s == null) return null;
            var node = _root;
            foreach (var ch in s)
            {
                if (!node.Children.TryGetValue(ch, out node))
                    return null;
            }
            return node;
        }
    }

}
