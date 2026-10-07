namespace AlgoMonster.Search
{
    public static class BinarySearch
    {
        /// <summary>
        /// https://leetcode.com/problems/search-in-rotated-sorted-array/description/
        /// </summary>
        public static int SiftedSearchArray(int[] nums, int target)
        {

            var left = 0;
            var right = nums.Length - 1;   
            
            while (left < right)
            {
                var mid = (left + right) / 2;
                if(nums[mid] == target)
                {
                    return mid;
                }
                else if(nums[left] <= nums[mid])
                {
                    // if left is sorted
                    if(nums[left] <= target && target <= nums[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else
                {
                    // right is sorted
                    if(nums[mid] < target && target <= nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// https://leetcode.com/problems/search-insert-position
        /// </summary>
        public static int SearchInsert(int[] nums, int target)
        {
            // | | |      
            // 1 3 4 5 6 7 8 , target = 2
            // 
            var left = 0;
            var right = nums.Length - 1;

            while (left < right)
            {
                var mid = (left + right) / 2;
                if (nums[mid] == target) return mid;
                if (target < nums[mid])
                {
                    // move left
                    right = mid - 1; 
                }
                else if (target > nums[mid])
                {
                    // move right
                    left = mid + 1;
                }
            }

            return left;
        }


        /// <summary>
        /// Find Peak element
        /// https://leetcode.com/problems/find-peak-element
        /// </summary>
        public static int FindPeakElement(int[] nums)
        {
            // indx = 1
            // 1,2,1,3,5,6,4
            //  ^
            //       ^  

            return 0;

        }

    }
}
