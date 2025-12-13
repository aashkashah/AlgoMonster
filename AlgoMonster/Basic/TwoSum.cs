using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AlgoMonster.Basic
{

    public static class EasyProblems
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int v = 0, ListNode n = null) { val = v; next = n; }
        }

        /// <summary>
        /// Goal: return any pair of indices i,j (i != j) such that nums[i] + nums[j] == target.
        /// If multiple pairs exist, return any.If none exist, return [-1, -1].
        /// </summary>
        public static int[] FindTwoSum(int[] nums, int target)
        {
            // target is given
            // this can be solved by dictionary as we need to return indices
            // add an element if not exists into dictionary. 
            // check if target - current is present in dictionary.. if so return that index and current index.

            var dict = new Dictionary<int, int>();
            var result = new int[] { -1, -1 };

            foreach (int i in nums)
            {
                if (dict.ContainsKey(target - i))
                {
                    result[0] = dict[target - i];
                    result[1] = i;
                    return result;
                }
            }
            return result;
        }


        /// <summary>
        /// Goal: return true if str2 is an anagram of str1 (same counts of letters), else false.
       ////  Assume lowercase a..z.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsValidAnagram(string str1, string str2)
        {
            // use a dictionary to count the characters present in str1. 
            // do same for string 2
            // compare both..
            // then run a loop for str2 dictionary to check with dictionary1
            // is there another way?


            var dict1 = new Dictionary<char, int>();
            var dict2 = new Dictionary<char, int>();

            foreach (char c in str1)
            {
                if (dict1.ContainsKey(c))
                {
                    dict1[c] = dict1[c] + 1;
                }
                else
                {
                    dict1.Add(c, 1);
                }
            }

            foreach (char c in str2)
            {
                if (dict2.ContainsKey(c))
                {
                    dict2[c] = dict2[c] + 1;
                }
                else
                {
                    dict2.Add(c, 1);
                }
            }

            foreach(char c in dict2.Keys)
            {
                if (!dict1.ContainsKey(c))
                {
                    return false;
                }
                if (dict1[c] != dict2[c])
                {
                    return false;
                }
                dict1.Remove(c);
            }
            if (dict1 != null) { return false; }

            return false;
        }

        /// <summary>
        /// Goal: given heads l1, l2 of two sorted singly linked lists, merge into one sorted list (reusing nodes).
        /// Time: O(m+n), Space: O(1) extra(just pointers).
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static ListNode MergeTwoSortedLists(ListNode list1,  ListNode list2)
        {


            return null;
        }
    }
}
