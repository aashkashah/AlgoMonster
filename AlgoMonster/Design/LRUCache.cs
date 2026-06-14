namespace AlgoMonster.Design
{
    /// <summary>
    /// Least Recently used cache
    /// https://leetcode.com/problems/lru-cache
    /// </summary>
    public class LRUCache
    {   
        private int _capacity = 0;

        private Dictionary<int, LinkedListNode<(int key, int value)>> map;
        private LinkedList<(int key, int value)> list;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            list = new();
            map = new();
        }

        public int Get(int key)
        {
            if (!map.ContainsKey(key)) return -1;

            var node = map[key];
            list.Remove(node);
            list.AddFirst(node);
            return node.Value.value;
        }

        public void Put(int key, int value)
        {
            if (map.ContainsKey(key))
            {
                list.Remove(map[key]);
                map.Remove(key);
            }

            if(list.Count == _capacity)
            {
                var lru = list.Last;
                map.Remove(lru.Value.key);
                list.RemoveLast();
            }

            var newNode = list.AddFirst((key, value));
            map[key] = newNode;
        }
    }
}
