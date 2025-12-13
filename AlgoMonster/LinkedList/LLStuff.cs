using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.LinkedList
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int v = 0, ListNode n = null)
        {
            val = v; next = n;
        }

        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head == null) return null;

            var dummy = new ListNode(0, head);
            var slow = dummy;
            var fast = dummy;

            for(int i = 0; i < n; i++)
            {
                if (fast.next == null) return dummy;
                fast = fast.next;
            }

            while(fast.next != null)
            {
                slow = slow.next;
                fast = fast.next;
            }


            return null;
        }
    }
}
