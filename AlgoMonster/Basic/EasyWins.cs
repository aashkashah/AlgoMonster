using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.Basic
{
    public static class EasyWins
    {
        /// <summary>
        /// Move Zeroes (Two Pointers, In-Place)
        /// Goal: Move all 0s to the end of the array in place, preserving the order of non-zeros.
        /// </summary>
        public static void MoveZeroes(int[] nums)
        {
            // array 1, 0, 0, 0, 3, 4, 10, 0, 0
            // array 0, 1, 5, 7, 0, 0
            // array 0, 0, 1

            // general ide is to use two pointers with any array question
            // most of the times, you are using pointers, same or diff direction,
            // slow fast pointers
            // some kind of dictionary, hashset
            // that's it with these array questions
            
            // with this, a pointer to stay at seroth index which is the place to bring a non-zero

            var ptrNonZero = 0;
            var ptrZero = 0;

            for (int i = 0; i < nums.Length; i++) 
            {
                if (nums[ptrZero] != 0)
                {
                    ptrZero++;
                }
                if(nums[ptrNonZero] == 0)
                {
                    ptrNonZero++;
                }
                if (nums[ptrZero] == 0 && nums[ptrNonZero] != 0)
                {
                    nums[ptrZero] = nums[ptrNonZero];
                    nums[ptrNonZero] = 0;
                    ptrZero++;
                }
                ptrNonZero++;
            }

        }


        /// <summary>
        /// Problem: Ransom Note
        // Goal
        // Return true if you can construct ransomNote from letters in magazine;
        // each letter in magazine can be used at most once.
        // ransomNote = "a", magazine = "b" → false
        // ransomNote = "aa", magazine = "aab" → true
        /// </summary>
        public static bool CanConstruct(string ransomNote, string magazine)
        {
            // count letters in magazine, then consume for ransomNote
            var dict = new Dictionary<char, int>();
            var ransmCharArr = ransomNote.ToCharArray();
            var mgznCharArr = magazine.ToCharArray();

            foreach(char c in ransmCharArr)
            {
                if(!dict.ContainsKey(c))
                {
                    dict.Add(c, 1);
                }
                else
                {
                    dict[c] += 1;
                }
            }

            foreach(char c in mgznCharArr)
            {
                if(!dict.ContainsKey(c))
                {
                    return false;
                }
                else
                {
                    dict[c] -= 1;
                    if (dict[c] < 0)
                        return false;
                }
            }

            return true;
        }


        /// <summary>
        /// Backspace String Compare (stack / two-pointer)
        /// Return true if two strings s and t are equal after processing '#' as backspace (deletes previous char), else false.
        /// Behavior
        /// '#' deletes one previous character if any; multiple '#' cascade.
        /// Example: "ab#c" → "ac", "a##" → "".
        /// </summary>
        public static bool BackspaceCompare(string s, string t)
        {
            // Option 1: simulate with stack/stringbuilder
            // Option 2: two-pointer backward scan with skip counters (O(1) space)

            // stack approach
            // push each charcter into stack one by one, if # seen, pop
            // do this for both strings and then compare

            var charStr1 = s.ToCharArray();
            var charStr2 = t.ToCharArray();

            var stack1 = new Stack<char>();
            var stack2 = new Stack<char>();

            foreach(char c in charStr1)
            {
                if(c == '#')
                {
                    if(stack1.Count() != 0)
                    {
                        stack1.Pop();
                    }
                }
                else
                {
                    stack1.Push(c);
                }
            }

            foreach (char c in charStr2)
            {
                if (c == '#')
                {
                    if (stack2.Count() != 0)
                    {
                        stack2.Pop();
                    }
                }
                else
                {
                    stack2.Push(c);
                }
            }

            while(stack1 != null && stack2 != null)
            {
                if(stack1.Pop() != stack2.Pop()) return false;
                
            }

            if (stack1 != null && stack1.Count() != 0) return false;
            if(stack2 != null && stack2.Count() != 0) return false;

            return true;
        }


        /// <summary>
        /// Contains Duplicate II https://leetcode.com/problems/contains-duplicate-ii/
        /// Goal: return true if there exist i != j with nums[i] == nums[j] and |i - j| <= k.
        /// {1,2,3,1}, k = 3 // true
        /// {1,2,3,1,2,3}, k = 2 // false
        /// </summary>
        public static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            var map = new Dictionary<int, List<int>>();

            for(int i = 0; i < nums.Length; i++)
            {
                if (map.TryGetValue(nums[i], out var indices))
                {
                    indices.Add(i);
                    map[nums[i]] = indices;
                }
                else
                {
                    map.Add(nums[i], new List<int>() { i });
                }
            }

            foreach(var item in map)
            {
                if(item.Value.Count > 2)
                {
                    for(int i = 0; i < item.Value.Count - 1; i++)
                    {
                        if (item.Value[i + 1] - item.Value[i] <= k) return true;
                    }
                }
            }

            return false;
        }



    }
}
