namespace AlgoMonster.LinkedList
{
    public static class EasyLL
    {

        /// <summary>
        /// Two pointers - separate lists
        /// You are given the heads of two sorted linked lists list1 and list2.
        /// Merge the two lists into one sorted linked list and return the head of the new sorted linked list.
        /// The new list should be made up of nodes from list1 and list2.
        /// Input: list1 = [1,2,4], list2 = [1,3,5]
        /// </summary>
        public static ListNode MergeTwoSortedLists(ListNode list1, ListNode list2)
        {
            ListNode dummy = new ListNode(0);
            ListNode node = dummy;

            while (list1 != null && list2 != null)
            {
                if (list1.value < list2.value)
                {
                    node.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    node.next = list2;
                    list2 = list2.next;
                }
                node = node.next;
            }

            if(list1 != null)
            {
                node.next = list1;
            }
            else if(list2 != null)
            {
                node.next = list2;
            }

            return dummy.next;
        }


        /// <summary>
        /// Two pointers -- same direction(slow/fast)
        /// </summary>
        /// <returns></returns>
        public static bool HasCycle(ListNode node)
        {
            // breaking condition fast pointer points to null
            var fast = node;
            var slow = node;

            while (fast.next != null && fast != null) 
            {
                fast = fast.next.next;
                slow = slow.next;
                
                if (slow.value == fast.value) return true;
            }


            return false;
        }
        public static ListNode ReverseLinkedList(ListNode node)
        {
            ListNode prev = null;
            ListNode curr = node;

           while(curr != null)
           {
                ListNode temp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = temp;
           }

            return prev;
        }
    }
}
