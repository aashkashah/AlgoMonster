using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.Blind75.LinkedList
{
    public class MediumLL
    {
        /// <summary>
        /// Reorder Linked List
        /// input [0, 1, 2, 3, 4, 5, 6]
        /// output [0, 6, 1, 5, 2, 4, 3]
        /// [0, n-1, 1, n-2, 2, n-3, ...]
        /// </summary>
        /// <param name="head"></param>
        public void ReorderList(ListNode head)
        {   
            // 0   1   2   3  n-3 n-2  n-1
            // 0   1   2   3   4   5   6
            // 0   6   1   5   2   4   3
            // 0  n-1  1  n-2  2  n-3  3

            // take 2 pointers, left and right
            // temp = left.next
            // left.next = right
            // left = temp


        }
    }
}
