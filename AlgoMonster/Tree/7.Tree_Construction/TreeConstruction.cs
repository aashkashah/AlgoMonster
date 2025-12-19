using System.Globalization;
using static AlgoMonster.Tree.Base.Tree;

namespace AlgoMonster.Tree._7.Tree_Construction
{
    public static class TreeConstruction
    {
        /// <summary>
        ///  Maximum Binary Tree
        /// https://leetcode.com/problems/maximum-binary-tree/?envType=problem-list-v2&envId=stack
        /// Input: nums = [3,2,1,6,0,5]
        /// Output: [6, 3, 5, null, 2, 0, null, null, 1]
        ///           6
        ///     3            8
        /// 1       5     7      10
        ///                   11    15 
        /// Input [6 3 1 5 8 7 10 11 15]
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static TreeNode ConstructMaximumBinaryTree(int[] nums)
        {  
            var rootNode = ConstructMaximumBinaryTreeHelper(nums, 0, nums.Length - 1);
            return rootNode;
        }

        private static TreeNode ConstructMaximumBinaryTreeHelper(int[] nums, int left, int right)
        {
            // O(N2) solution 
            // find max out of array
            // every elem to left of max is left sub tree
            // every elem to right is right sub tree
            if (left > right) return null;

            // recurse
            int maxIdx = left;
            for(int i = left + 1; i <= right; i++)
            {
                if (nums[i] > nums[maxIdx])
                    maxIdx = i;
            }
            

           var root = new TreeNode(nums[maxIdx]);

            root.left = ConstructMaximumBinaryTreeHelper(nums, left, maxIdx - 1);
            root.right = ConstructMaximumBinaryTreeHelper(nums, maxIdx + 1, right);
            return root;
        }


        public static TreeNode ConstructMaximumBinaryTreeOptimal(int[] nums)
        {
            // O(N) solution
            var stack = new Stack<TreeNode>();

            foreach(var num in nums)
            {
                var curr = new TreeNode(num);

                while(stack.Count > 0 && stack.Peek().val < num)
                {
                    curr.left = stack.Pop();
                }

                if(stack.Count > 0) // right
                {
                    var parent = stack.Peek();
                    parent.right = curr;
                }

                stack.Push(curr);
            }

            TreeNode root = null;
            while(stack.Count > 0)
            {
                root = stack.Pop();
            }

            return root;
        }

        /// <summary>
        /// Convert Sorted Array to Binary Search Tree
        /// https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/description/?envType=problem-list-v2&envId=tree
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public TreeNode SortedArrayToBST(int[] nums)
        {
            // -10 -3 0 1 2 5 9
            //         1
            //     -3      5  
            // -10   0   2   9
            //                 
            return null;
        }

        public TreeNode SortedArrayToBSThelper(int[] nums, int left, int right)
        {
            // mid point 
            // left 

            // return condition
            if (left > right) return null;

            // recursion
            var mid = (left + right)/2;
            var root = new TreeNode(mid);

            root.left = SortedArrayToBSThelper(nums, left, mid - 1);
            root.right = SortedArrayToBSThelper(nums, mid + 1, right);
            return root;
        }

    }
}
