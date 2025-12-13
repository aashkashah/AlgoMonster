using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AlgoMonster.Heap
{
    /// <summary>
    /// Median from Data Stream
    /// Design a data structure that supports:
    /// AddNum(int num) → add a number from the stream
    /// FindMedian() → return the current median
    /// Example stream:
    /// Add 1 → median = 1
    /// Add 2 → median = (1+2)/2 = 1.5
    /// Add 3 → median = 2
    /// </summary>
    public class Medianfinder
    {

        PriorityQueue<int, int> lower;
        PriorityQueue<int, int> upper;

        public Medianfinder()
        {
            lower = new PriorityQueue<int, int>();
            upper = new PriorityQueue<int, int>();
        }

        public void AddNum(int num)
        {
            // priorities

            // add to lower 
            lower.Enqueue(num, -num);

            // move highest from lower to upper
            int moved = lower.Dequeue();
            upper.Enqueue(moved, moved);

            // rebalance sizes, lower should have >= upper
            if(lower.Count > upper.Count)
            {
                int moveBack = upper.Dequeue();
                lower.Enqueue(moveBack, -moveBack);
            }
        }

        public double FindMedian()
        {

            if (lower.Count == upper.Count) 
            {
                var leftMax = lower.Peek();
                var rightMax = upper.Peek();
                return (leftMax + rightMax) / 2.0;
            }
            else
            {
                // lower has one more than upper
                return lower.Peek();
            }
        }
    }
}
