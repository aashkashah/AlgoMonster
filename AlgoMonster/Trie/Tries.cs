using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.Trie
{
    using System;
    using System.Collections.Generic;

    public class TrieNodeBasic
    {
        public readonly Dictionary<char, TrieNodeBasic> Children = new Dictionary<char, TrieNodeBasic>();
        public bool IsEnd;
    }

    public class Tries
    {
        private readonly TrieNodeBasic _root = new TrieNodeBasic();

        public void Insert(string word)
        {
            if (word == null) throw new ArgumentNullException(nameof(word));
            // Normalize if you want case-insensitive: word = word.ToLowerInvariant();
            var node = _root;
            foreach (var ch in word)
            {
                if (!node.Children.TryGetValue(ch, out var next))
                {
                    next = new TrieNodeBasic();
                    node.Children[ch] = next;
                }
                node = next;
            }
            node.IsEnd = true;
        }

        public bool Search(string word)
        {
            var node = FindNode(word);
            return node != null && node.IsEnd;
        }

        public bool StartsWith(string prefix) => FindNode(prefix) != null;

        private TrieNodeBasic FindNode(string s)
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

        // Optional: quick way to “see” content for debugging
        public IEnumerable<string> WordsWithPrefix(string prefix)
        {
            var start = FindNode(prefix);
            if (start == null) yield break;
            var stack = new Stack<(TrieNodeBasic node, string path)>();
            stack.Push((start, prefix));
            while (stack.Count > 0)
            {
                var (node, path) = stack.Pop();
                if (node.IsEnd) yield return path;
                foreach (var kv in node.Children)
                    stack.Push((kv.Value, path + kv.Key));
            }
        }
    }

}
