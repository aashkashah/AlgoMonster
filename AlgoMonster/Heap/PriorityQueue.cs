using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.Heap
{
    public static  class PriorityQueue
    {
        public static void PriorityQueueExample()
        {
            var pq = new PriorityQueue<string, int>();

            pq.Enqueue("Task A", 1);
            var task = pq.EnqueueDequeue("Task B", 2);
        }
    }
}
