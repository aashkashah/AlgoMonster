namespace AlgoMonster.Design
{
    /// <summary>
    /// Least Recently used cache
    /// https://leetcode.com/problems/lru-cache
    /// </summary>
    public class LRUCache
    {
        private class Node
        {
            public int key;
            public int val;

            public Node(int Key, int Val)
            {
                key = Key;
                val = Val;
            }
        }
        
        private int _capacity = 0;

        private Dictionary<int, LinkedListNode<Node>> _map;
        private LinkedList<Node> _lru;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _map = new Dictionary<int, LinkedListNode<Node>>(capacity);
        }

        public int Get(int key)
        {
            LinkedListNode<Node> node;

            if (_map.TryGetValue(key, out node))
            {
                var val = node.Value.val;
                _lru.Remove(node);
                _map[key] = new LinkedListNode<Node>(new Node(key, val));
                _lru.AddFirst(_map[key]);
                return val;
            }
            else
            {
                return -1;
            }
        }

        public void Put(int key, int value)
        {
            if(_map.ContainsKey(key))
            {
                // remove
                _lru.Remove(_map[key]);
                _map.Remove(key);
            }

            _map[key] = new LinkedListNode<Node>(new Node(key, value));
            _lru.AddFirst(_map[key]);

            if(_map.Count > _capacity)
            {
                var lastkey = _lru.Last.Value.key;
                _lru.RemoveLast();
                _map.Remove(lastkey);
            }
        }
       
    }
}
