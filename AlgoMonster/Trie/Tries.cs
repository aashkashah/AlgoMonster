using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.Trie
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Microsoft.VisualBasic;

    public class TrieNodeBase
    {
        public Dictionary<char, TrieNodeBase> children = new Dictionary<char, TrieNodeBase>();
        public bool isEndWord = false;
    }

    public class Tries
    {
        TrieNodeBase root;
        public void createTrie(string[] words)
        {
            root = new TrieNodeBase();
            foreach(var word in words)
            {
                insert(word);
            }
        }

        public void insert(string word)
        {
            var node = root;
            foreach(var ch in word)
            {
                if(!node.children.ContainsKey(ch))
                {
                    node.children[ch] = new TrieNodeBase();
                }
                node = node.children[ch];
            }
            node.isEndWord = true;
        }

       public bool search(string word)
        {
            var node = root;

            foreach(var ch in word)
            {
                if(!node.children.ContainsKey(ch))
                {
                    return false;
                }
                node = node.children[ch];
            }
            return node.isEndWord;
        }

        public void delete(string word)
        {
            deletehelper(root, word, 0);
        }

        private bool deletehelper(TrieNodeBase node, string word, int index)
        {
            if(index == word.Length)
            {
                // un-mark as end of word to be deleted 
                node.isEndWord = false;

                // return true if no children 
                return node.children.Count == 0;
            }

            char c = word[index];

            if(!node.children.ContainsKey(c))
                return false; // word not found

            var child = node.children[c];
            bool shouldDeleteChild = deletehelper(child, word, index + 1);

            if(shouldDeleteChild)
                node.children.Remove(c);
            
            return !node.isEndWord && node.children.Count == 0;
        }

        private void deleteHelperItterative(string word)
        {
            var node = root;
            var path = new List<TrieNodeBase> {root};

            // un-mark word as end
            for(int i = 0; i < word.Length; i++)
            {
                if(node.children.TryGetValue(word[i], out var child))
                {
                    // node doesn't exist
                    return;
                }

                node = child;
                path.Add(node);
            }

            if(!node.isEndWord)
                return;

            node.isEndWord = true;


            for(int i = word.Length; i > 0; i--)
            {
                var current = path[i];
                if(current.children.Count == 0 && !current.isEndWord)
                {
                    var parent = path[i - 1];
                    parent.children.Remove(word[i - 1]);
                }
                else
                {
                    break;
                }
            }
        }
    }

}
