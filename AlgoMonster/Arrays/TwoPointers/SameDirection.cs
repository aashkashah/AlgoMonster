using AlgoMonster.LinkedList;
using System.Collections.Generic;
using System.Xml.Linq;

namespace AlgoMonster.Arrays.TwoPointers
{
    public static class SameDirection
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

            for (int right = 0; right < charArr.Length; right++)
            {
                char currChar = charArr[right];

                if (dictLastSeen.TryGetValue(currChar, out int lastSeen) && lastSeen >= left)
                {
                    // move left to next of last seen index
                    left = lastSeen + 1;
                }

                dictLastSeen[currChar] = right;

                int currLen = right - left + 1;
                if (currLen > maxLen)
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

            while (fast != null && fast.next != null)
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
            for (int rightPtr = 1; rightPtr < nums.Length; rightPtr++)
            {
                if (leftPtr < rightPtr)
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
        /// https://leetcode.com/problems/remove-element/description/?envType=problem-list-v2&envId=array
        /// Input: nums = [3,2,2,3], val = 3
        /// Output: 2, nums = [2, 2, _, _]
        /// Explanation: Your function should return k = 2, with the first two elements of nums being 2.
        /// It does not matter what you leave beyond the returned k(hence they are underscores).
        /// Note that the five elements can be returned in any order.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int RemoveElements(int[] nums, int k)
        {
            // 3 2 2 3 5 4 3 , Val =3
            // ^  
            // ^
            var reader = 0;
            var writer = 0;

            while(reader < nums.Length)
            {
                if (nums[reader] == k) reader++;
                else
                {
                    nums[writer] = nums[reader];
                    reader++;
                    writer++;
                }

            }

            return writer;
        }

        /// <summary>
        ///  Longest Harmonious Subsequence
        ///  This is a “frequency map + neighbor” pattern.
        ///  https://leetcode.com/problems/longest-harmonious-subsequence/description/?envType=problem-list-v2&envId=sliding-window
        ///  
        /// A harmonious subsequence only cares about values and counts (order doesn’t matter for subsequence length). 
        /// If max − min = 1, that means the subsequence uses exactly two numbers: x and x+1 (both must appear at least once).
        /// So: count all numbers, 
        /// then for each x, if x+1 exists, candidate length = count[x] + count[x + 1].Take max.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindLHS(int[] nums)
        {
            Array.Sort(nums);

            int best = 0;
            int l = 0;

            for(int r = 0; r < nums.Length; r++)
            {
                while (nums[r] - nums[l] > 1)
                    l++;
                if (nums[r] - nums[l] == 1)
                    best = Math.Max(best, r - l + 1);
            }

            return best;
        }

        /// <summary>
        /// https://leetcode.com/problems/string-compression
        /// </summary>
        public static int Compress(char[] chars)
        {

            char curChar;
            var res = string.Empty;
            var l = 0;
            var r = 0;

            while (r < chars.Count())
            {
                curChar = chars[r];
                var currCount = 0;
                while (r < chars.Count() && chars[l] == chars[r])
                {
                    currCount++;
                    r++;
                }
                l = r;
                if (currCount == 1)
                {
                    res += curChar;
                }
                else
                {
                    res += curChar + Convert.ToString(currCount);
                }
            }

            return res.Length;
        }


    }
}
