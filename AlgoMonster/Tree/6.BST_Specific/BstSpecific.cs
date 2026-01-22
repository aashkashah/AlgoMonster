using static AlgoMonster.Tree.Base.Tree;

namespace AlgoMonster.Tree._6.BST_Specific
{
    public static class BstSpecific
    {
        /// <summary>
        /// Valid Binary Search Tree
        /// Given the root of a binary tree, return true if it is a valid binary search tree, otherwise return false.
        /// </summary>
        public static bool IsValidBST(TreeNode root)
        {
            // use bfs of dfs
            //         12
            //              
            //           13     15
            //        11    14

            // whule
            // break until queue is empty
            // return right away if left > root or right < root
            return IsValidBstHelper(root, int.MinValue, int.MaxValue);
        }

        private static bool IsValidBstHelper(TreeNode root, int minValue, int maxVal)
        {
            if (root == null) 
                return true;

            if (!(minValue < root.val && root.val < maxVal)) 
                return false;
            
            return (
                IsValidBstHelper(root.left, minValue, root.val) 
                && IsValidBstHelper(root.right, root.val, maxVal)
                );
        }

        /// <summary>
        /// https://www.geeksforgeeks.org/dsa/find-k-th-smallest-element-in-bst-order-statistics-in-bst/
        /// </summary>
        public static int kthSmallestElement(TreeNode node, int k)
        {
            // in order traversal
            // left root right
            int count = 0;
            return kthSmallestElementHelper(node, ref count, k);

        }

        private static int kthSmallestElementHelper(TreeNode node, ref int count, int k)
        {
            if (count == 0) return -1;

            int left = kthSmallestElementHelper(node.left, ref count, k);

            if (left != -1) return left;

            count++;

            if (count == k) return node.val;

            int right = kthSmallestElementHelper(node.right, ref count, k);
            return right;

        }

        /// <summary>
        /// https://leetcode.com/problems/verify-preorder-sequence-in-binary-search-tree
        /// Given an array of unique integers preorder, 
        /// return true if it is the correct preorder traversal sequence of a binary search tree.
        /// Input: preorder = [5,2,1,3,6]
        /// Output: true
        ///            6
        ///     3            8
        /// 1       5     7      10
        ///                   11    15 
        ///  [6 3 1 5 8 7 10 11 15]
        ///  [6 3 1 8 5 7 ...] 
        ///  
        /// </summary>
        public static bool VerifyPreorder(int[] preorder)
        {
            var lowerBound = int.MinValue;
            var stack = new Stack<int>();

            for(int i = 0; i < preorder.Length; i++)
            {
                if (preorder[i] < lowerBound) return false;

                while(stack.Count > 0 && preorder[i] > stack.Peek())
                {
                    lowerBound = stack.Pop();
                }
                stack.Push(preorder[i]);
            }

           return true;
        }
    }
}
