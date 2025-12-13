namespace AlgoMonster.LinkedList
{
    public static class MediumLL
    {
        /// <summary>
        /// Reorder Linked List
        /// input [0, 1, 2, 3, 4, 5, 6]
        /// output [0, 6, 1, 5, 2, 4, 3]
        /// [0, n-1, 1, n-2, 2, n-3, ...]
        /// </summary>
        /// <param name="head"></param>
        public static void ReorderList(ListNode head)
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

        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head == null) return null;

            var dummy = new ListNode(0, head);
            var slow = dummy;
            var fast = dummy;

            for (int i = 0; i < n; i++)
            {
                if (fast.next == null) return dummy;
                fast = fast.next;
            }

            while (fast.next != null)
            {
                slow = slow.next;
                fast = fast.next;
            }


            return null;
        }
    }
}
