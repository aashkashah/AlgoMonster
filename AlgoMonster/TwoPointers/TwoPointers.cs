using AlgoMonster.LinkedList;
using AlgoMonster.Trie;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AlgoMonster.TwoPointers
{
   
    public static class TwoPointers
    {
        /// <summary>
        /// Two pointers - variable length, same direction
        /// Find the length of longest substring without repeating characters
        /// input = abcabcbb
        /// output = 3
        /// </summary>
        public static int LongestSubstring(string s)
        {
            // abcabcbb
            // ^
            //   ^
            // dictionary = (a,0), (b,1), (c,2), (a,3)

            var charArr = s.ToCharArray();
            var left = 0;
            int maxLen = 0;
            var dictLastSeen = new Dictionary<char, int>();

            for(int right = 0; right < charArr.Length; right++)
            {
                char currChar = charArr[right];

                if (dictLastSeen.TryGetValue(currChar, out int lastSeen) && lastSeen >= left)
                {
                    // move left to next of last seen index
                    left = lastSeen + 1;
                }

                dictLastSeen[currChar] = right;

                int currLen = right - left + 1;
                if(currLen > maxLen)
                {
                    maxLen = currLen;
                }
            }

            return maxLen;
        }

        /// <summary>
        /// Two pointers - same direction
        /// Given a sorted list of numbers, remove duplicates and return the new length. 
        /// You must do this in-place and without using extra memory.
        /// Input: [0, 0, 0, 1, 1, 1, 2, 2].
        /// Output: 3.
        /// Your function should modify the list in place so that the first three elements become 0, 1, 2.
        /// Return 3 because the new length is 3.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int RemoveDuplicates(int[] nums)
        {
            // 0, 0, 1, 1, 1, 2, 2
            // 0 , 1 , 2
            // 3
            // left and right pointer
            // left stays at index that needs to be updated
            // right ptr keeps going until different char is found
            // if diff found, move left and update left tp this new char
            // right reaches end of nums
            // nullify remaining, return length

            var left = 0;
            var currNum = nums[0];

            for (int right = 1; right < nums.Length; right++)
            {
                if (nums[left] != nums[right])
                {
                    // update and increment left
                    left++;
                    nums[left] = nums[right];
                }
            }

            return left + 1;
        }

        /// <summary>
        /// Two pointers - slow and fast
        /// Find the middle node of a linked list.
        /// Input: 0 1 2 3 4
        /// Output: 2
        /// If the number of nodes is even, then return the second middle node.
        /// Input: 0 1 2 3 4 5
        /// Output: 3
        /// </summary>
        /// <returns></returns>

        public static int MiddleOfLinkedList(ListNode nums)
        {
            // 0 1 2 3 4 5
            // ^
            // ^

            // first pass, slow = 0, fast = 0
            // snd pass,  slow = 1, fast = 3
            // third pass, slow = 2, fast = 5
            // frth pass, slow = 3, fast = null

            // until fast reaches null -- while loop break

            // 0 1 2 3 4
            // slow = 0, fast = 0
            // slow = 1, fast = 3
            // slow = 2, fast = null 

            ListNode slow = nums;
            ListNode fast = nums;
            
            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow.value;
        }

        /// <summary>
        /// Two pointers - same direction, one variable speed, one fixed speed
        /// Move Zeros
        /// Given an array of integers, move all the 0s to the back of the array while 
        /// maintaining the relative order of the non-zero elements.Do this in-place using constant auxiliary space.
        /// Input:
        /// [1, 0, 2, 0, 0, 7]
        /// Output:
        /// [1, 2, 7, 0, 0, 0]
        /// </summary>
        public static int[] MoveZeros(int[] nums)
        {
            // 1 0 2 0 0 7
            //     ^
            //           ^

            var leftPtr = 0;
            for(int rightPtr = 1; rightPtr < nums.Length; rightPtr++)
            {
                if(leftPtr < rightPtr)
                {
                    while (nums[leftPtr] != 0)
                    {
                        leftPtr++;
                    }
                }
                if (nums[leftPtr] == 0 && nums[rightPtr] != 0)
                {
                    // swap
                    nums[leftPtr] = nums[rightPtr];
                    nums[rightPtr] = 0;
                }
               
            }
            return nums;
        }

        /// <summary>
        /// Two pointers, opposite direction
        /// Two Sum Sorted
        /// Given an array of integers sorted in ascending order, 
        /// find two numbers that add up to a given target. 
        /// Return the indices of the two numbers in ascending order. You can assume elements 
        /// in the array are unique and there is only one solution. 
        /// Do this in O(n) time and with constant auxiliary space.
        /// Input:
        /// arr: a sorted integer array
        /// target: the target sum we want to reach
        /// Sample Input: [2, 3, 4, 5, 8, 11, 18], 9
        /// Sample Output: 1 3
        /// </summary>
        public static (int, int) TwoSumSorted(int[] nums, int sum)
        {
            // 2 3 5 6 8 11 18
            //   ^
            //       ^   

            var left = 0;
            var right = nums.Length;

            // loop until left < right
            while (left < right)
            {
                // left + right > sum, then right --;
                // left + right < sum, then left ++;

                var currSum = nums[left] + nums[right];

                if (currSum > sum)
                {
                    right--;
                }
                else if (currSum < sum)
                {
                    left++;
                }
                else if (currSum == sum)
                {
                    return (left, right);
                }
            }

            return (-1, -1);
        }


        /// <summary>
        /// Two pointers, opposite direction
        /// Valid Palindrome
        /// Determine whether a string is a palindrome, 
        /// ignoring non-alphanumeric characters and case. 
        /// Examples:
        /// Input: Do geese see God? Output: True
        /// Input: Was it a car or a cat I saw? Output: True
        /// Input: A brown fox jumping over Output: False
        /// </summary>
        /// <returns></returns>
        public static bool IsValidPalindrome(string str)
        {
            // Do geese see God?
            //    ^
            //              ^

            // ignore alphanumeric, case agnostic 
            // until left < right..

            var left = 0;
            var right = str.Length;
            var strArray = str.ToCharArray();

            while(left < right)
            {

                while (!char.IsLetterOrDigit(strArray[left]) && left < right)
                {
                    left++;
                }

                while (!char.IsLetterOrDigit(strArray[right]) && left < right)
                {
                    right--;
                }

                if (strArray[left] != strArray[right])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
