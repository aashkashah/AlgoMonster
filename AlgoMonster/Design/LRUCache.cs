using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.Design
{
    /// <summary>
    /// Least Recently used cache
    /// https://leetcode.com/problems/lru-cache
    /// 
    /// Input
    /// ["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"]
    /// [[2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]]
    /// Output
    /// [null, null, null, 1, null, -1, null, -1, 3, 4]
    /// </summary>
    public class LRUCache
    {
        private class Node
        {
            public int key;
            public int val;
            public Node prev;
            public Node next;

            public Node(int Key, int Val)
            {
                key = Key;
                val = Val;
            }
        }
        
        private int _capacity = 0;
        private Dictionary<int, Node> _map;
        
        private Node _head;
        private Node _tail;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _map = new Dictionary<int, Node>(capacity);

            _head = new Node(0, 0);
            _tail = new Node(0, 0);
            _head.next = _tail;
            _tail.prev = _head;
        }

        public int Get(int key)
        {
            if (!_map.TryGetValue(key, out var node)) return -1;

            // mark recently used
            Remove(node);
            AddToFront(node);

            return node.val;
        }

        public void Put(int key, int value)
        {
            if (_capacity == 0) return;
           
            if(_map.TryGetValue(key,out var node))
            {
                // update existing + mark as most recent
                node.val = value;
                Remove(node);
                AddToFront(node);
                return;
            }

            // insert new
            var newNode = new Node(key, value);
            _map[key] = newNode;
            AddToFront(newNode);

            // if over capacity, evict LRU
            if(_map.Count > -_capacity)
            {
                var lru = _tail.prev;
                Remove(lru);
                _map.Remove(lru.key);
            }
        }

        private void Remove(Node node)
        {
            // to understand

            // Before:
            // A <-> B <-> C
            // After:
            // A <-> C

            // it's simply
            // node.Prev = A
            // node.Next = C
            // A.next = C
            // C.Prev = A

            node.prev.next = node.next;
            node.next.prev = node.prev;
        }

        private void AddToFront(Node node)
        {
            node.next = _head.next;
            node.prev = _head;

            _head.next.prev = node;
            _head.next = node;
        }
    }
}
