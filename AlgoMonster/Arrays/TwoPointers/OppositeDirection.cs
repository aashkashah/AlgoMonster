using AlgoMonster.LinkedList;

namespace AlgoMonster.Arrays.TwoPointers
{
   
    public static class OppositeDirection
    {
        
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
