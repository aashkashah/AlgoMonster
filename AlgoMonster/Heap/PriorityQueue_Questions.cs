namespace AlgoMonster.Heap
{
    public class PriorityQueue_Questions
    {
        public void PriorityQueueExample()
        {
            var pq = new PriorityQueue<string, int>();

            pq.Enqueue("Task A", 1);
            var task = pq.EnqueueDequeue("Task B", 2);
        }

        /// <summary>
        /// Meeting Rooms II
        /// https://leetcode.com/problems/meeting-rooms-ii
        /// </summary>
        public int MinMeetingRooms(int[][] intervals)
        {
            
            if(intervals == null || intervals.Length == 0) return 0;

            // Array.Sort:
            // chooses which two elements to compare
            // chooses the order
            // may compare the same elements multiple times
            // may compare them in either direction
            
            // Because internally:
            // Array.Sort picks two elements
            // labels one as a and the other as b
            // calls the comparison function

            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));


            var allocator = new PriorityQueue<int, int>();

            allocator.Enqueue(intervals[0][1], intervals[0][1]);

            for(int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] >= allocator.Peek())
                {
                    allocator.Dequeue();
                }

                allocator.Enqueue(intervals[i][1], intervals[i][1]);
            }

            return allocator.Count;
        }

        public static int FindKthLargest(int[] nums, int k)
        {
            var heap = new PriorityQueue<int, int>();
            var hash = new HashSet<int>();


            foreach (var elem in nums)
            {
                heap.Enqueue(elem, -elem);
            }

            for (int i = 1; i < k; i++)
            {
                heap.Dequeue();
            }

            return heap.Dequeue();
        }


        /// <summary>
        /// Top K Frequent Elements
        /// https://leetcode.com/problems/top-k-frequent-elements
        /// </summary>
        public IList<int> TopKFrequent(int[] nums, int k)
        {
            var freq = new Dictionary<int, int>();
            var heap = new PriorityQueue<int, int>();
            var res = new List<int>();

            // build freq map
            foreach (var num in nums)
            {
                if (!freq.ContainsKey(num))
                {
                    freq.Add(num, 1);
                }
                else
                {
                    freq[num]++;
                }
            }

            // build max heap
            foreach (var elem in freq)
            {
                heap.Enqueue(elem.Key, -elem.Value);
            }

            for (int i = 0; i < k; i++)
            {
                res.Add(heap.Dequeue());
            }

            return res.ToArray();
        }

        /// <summary>
        /// top k max elements
        /// find_largest([1,5,4,2,3], 3)  # => [3, 4, 5]
        /// solved in 5 mins
        /// </summary>
        public static int[] FindLargest(int[] input, int m)
        {
            // constraints
            // very large data size
            // M largest number
            // array or file

            // 1 5 4 2 3
            // 1 2 m = 3

            if (input.Length < m) return input;

            // duplicates?
            // min heap or max heap?
            // first pass -> create, max heap
            // second pass -> for  0 to m-1
            // min heap is better

            var pq = new PriorityQueue<int, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (pq.Count == m)
                {
                    // peek
                    if (pq.Peek() < input[i])
                    {
                        pq.Dequeue();
                    }
                }
                pq.Enqueue(input[i], input[i]);
            }

            var res = new int[m];
            for (int i = 0; i < m; i++)
            {
                res[i] = pq.Dequeue();
            }
            return res;
        }
    }
}
