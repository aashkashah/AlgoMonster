using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.Heap
{
    /// <summary>
    /// Problem: Top K Frequent Elements (Heap + Hash Map)
    /// Input
    /// First line: n k=
    /// Second line: n integers=
    /// Output
    /// The k most frequent elements(order doesn’t matter for this version).
    /// </summary>
    internal class TopK
    {
        public IList<int> TopKFrequent(int[] nums, int k)
        {
            var frequencyMap = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (frequencyMap.ContainsKey(num))
                    frequencyMap[num]++;
                else
                    frequencyMap[num] = 1;
            }

            // priority queue is built in heap structure in c#
            // default is min heap, to use max heap, add -ve as value
            var minHeapPq = new PriorityQueue<int, int>();   
            var minHeap = new MinHeap<(int num, int freq)>();
            foreach (var kvp in frequencyMap)
            {
                minHeapPq.Enqueue(kvp.Key, kvp.Value);
                minHeap.Push((kvp.Key, kvp.Value));
                if (minHeap.Count > k)
                    minHeap.Pop();
                if(minHeapPq.Count > k)
                    minHeapPq.Dequeue();
            }
            var result = new List<int>();
            while (minHeap.Count > 0)
            {
                result.Add(minHeap.Pop().num);
            }
            return result;
        }
    }
}
