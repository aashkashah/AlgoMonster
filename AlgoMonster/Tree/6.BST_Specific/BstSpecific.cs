using static AlgoMonster.Tree.Base.Tree;

namespace AlgoMonster.Tree._6.BST_Specific
{
    public static class BstSpecific
    {
        /// <summary>
        /// Valid Binary Search Tree
        /// Given the root of a binary tree, return true if it is a valid binary search tree, otherwise return false.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
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
            if (root == null) return true;
            if (!(minValue < root.val && root.val < maxVal)) return false;
            return (IsValidBstHelper(root.left, minValue, root.val) && IsValidBstHelper(root.right, root.val, maxVal));
        }

        /// <summary>
        /// https://www.geeksforgeeks.org/dsa/find-k-th-smallest-element-in-bst-order-statistics-in-bst/#
        /// </summary>
        /// <returns></returns>
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
    }
}
