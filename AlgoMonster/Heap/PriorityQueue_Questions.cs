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
        /// https://leetcode.com/problems/meeting-rooms-ii/description
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
    }
}
