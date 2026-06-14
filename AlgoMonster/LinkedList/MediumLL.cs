namespace AlgoMonster.LinkedList
{   public static class MediumLL
    {

        /// <summary>
        /// https://www.hellointerview.com/learn/code/linked-list/palindrome-linked-list
        /// </summary>
        public static bool IsPalindrome(ListNode head)
        {
            if(head == null || head.next == null)
                return true;

            var slow = head;
            var fast = head;

            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            // use a stack and traverse first ll elem and top of stack 
            // if not equal -> false

            var stack = new Stack<int>();
            var cur = slow;
            while(cur != null)
            {
                stack.Push(cur.value);
                cur = cur.next;
            }

            var node =  head;
            while(stack.Count > 0)
            {
                if(node.value != stack.Pop())
                {
                    return false;
                }
                node = node.next;
            }

            return true;
        }

        /// <summary>
        /// Reorder Linked List
        /// input [0, 1, 2, 3, 4, 5, 6]
        /// output [0, 6, 1, 5, 2, 4, 3]
        /// https://leetcode.com/problems/reorder-list
        /// </summary>
        public static void ReorderList(ListNode head)
        {
            // 0   1   2   3  n-3 n-2  n-1
            // 0   1   2   3   4   5   6
            // 0   6   1   5   2   4   3
            // 0  n-1  1  n-2  2  n-3  3

            // find midpoint on list using slow fast ptr
            var slow = head;
            var fast = head;
            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            // reverse right half of the list
            ListNode prev = null, curr = slow, tmp;
            while(curr != null)
            {
                tmp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = tmp;
            }

            // merge two lists
            ListNode first = head, second = prev;
            while(second.next != null)
            {
                tmp = first.next;
                first.next = second;
                first = tmp;
                second.next = first;
                second = tmp;
            }
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

        public static ListNode OddEvenList(ListNode head)
        {
            // 2 1 3 5 6 4 7
            // 2 3 6 7 1 5 4

            // 2 -> 3 -> 6 -> 7
            // evenPtr = 1 -> 5 -> 4 

            var even = head.next;
            var odd = head;
            var evenHead = even;

            while (odd.next != null)
            {
                var temp = odd.next;
                odd.next = odd.next.next;

                even = temp;
                even.next = odd.next;

            }
            odd.next = evenHead;
            return head;
        }

        /// <summary>
        /// https://www.hellointerview.com/learn/code/linked-list/swap-nodes-in-pairs
        /// </summary>
        public static ListNode SwapPairs(ListNode head)
        {
            if(head == null || head.next == null)
                return head;

            var first = head;
            var second  = head.next;

            ListNode prev = null;
            ListNode newhead = second;

            while(first != null && second != null)
            {
                // swap 
                var temp = second.next;

                second.next = first;
                first.next = temp;

                // prev point to first 
                if(prev != null)
                {
                    prev.next = second;
                }

                // advance pointers
                prev = first;
                first = temp;
                second = temp?.next;
            }

            return newhead;
        }
    }
}
