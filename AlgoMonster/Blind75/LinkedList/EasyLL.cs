using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static AlgoMonster.Mocks.Nov2725;

namespace AlgoMonster.Blind75.LinkedList
{
    public class EasyLL
    {

        /// <summary>
        /// Two pointers - separate lists
        /// You are given the heads of two sorted linked lists list1 and list2.
        /// Merge the two lists into one sorted linked list and return the head of the new sorted linked list.
        /// The new list should be made up of nodes from list1 and list2.
        /// Input: list1 = [1,2,4], list2 = [1,3,5]
        /// </summary>
        public ListNode MergeTwoSortedLists(ListNode list1, ListNode list2)
        {
            // 1 2 4             
            // ^             
            // 1 3 5
            // ^

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

            if(list1 !=null)
            {
                node.next = list1;
            }
            else
            {
                node.next = list2;
            }

            return dummy.next;
        }


        /// <summary>
        /// Two pointers -- same direction(slow/fast)
        /// Given a linked list with potentially a loop, 
        /// determine whether the linked list from the first node contains a cycle in it. 
        /// For bonus points, do this with constant space.
        /// </summary>
        /// <returns></returns>
        public bool HasCycle(ListNode node)
        {
            // 0 1 2 3 4
            //         ^
            //         ^ 

            // 0 1 2 3 4 5
            //           ^
            //           ^

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

        /// <summary>
        /// Given the beginning of a singly linked list head, 
        /// reverse the list, and return the new beginning of the list.
        /// Input: head = [0,1,2,3]
        /// Output: [3, 2, 1, 0]
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public ListNode ReverseLinkedList(ListNode node)
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
