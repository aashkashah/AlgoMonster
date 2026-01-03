using Microsoft.VisualBasic;
using System.Collections.Specialized;
using static AlgoMonster.Tree.Base.Tree;

namespace AlgoMonster.Tree._1.DFS_Traversal
{
    public static class DfsTraversal
    {
        static List<int> nodeValues = new List<int>();
        static int minDiff = int.MaxValue;
        static int? prev = null;
        /// <summary>
        /// Sum of Left Leaves
        /// https://leetcode.com/problems/sum-of-left-leaves/description/?envType=problem-list-v2&envId=tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int SumOfLeftLeaves(TreeNode root)
        {
            if (root == null) return 0;
            int sum = 0;

            if (root.left != null &&
                root.left.left == null && 
                root.left.right == null)
            {
                sum += root.left.val;
            }

            sum += SumOfLeftLeaves(root.left);
            sum += SumOfLeftLeaves(root.right);

            return sum;
        }

        /// <summary>
        /// Same as SumOfLeftLeaves above, but via a flag
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int SumOfLeftLeaves2(TreeNode root)
        {
            return SumOfLeftLeaves2Helper(root, false);
        }

        private static int SumOfLeftLeaves2Helper(TreeNode node, bool isLeft)
        {
            if (node == null) return 0;

            // if this is a left leaf
            if (node.left == null && node.right == null && isLeft)
                return node.val;

            return SumOfLeftLeaves2Helper(node.left, true) + SumOfLeftLeaves2Helper(node.right, false);
        }

        /// <summary>
        /// Minimum Absolute Difference in BST
        /// https://leetcode.com/problems/minimum-absolute-difference-in-bst/description/?envType=problem-list-v2&envId=tree
        /// Input: root = [4,2,6,1,3]
        /// Output: 1
        /// </summary>
        public static int GetMinimumDifference(TreeNode root)
        {
            // --- this is sub-optimal ---
            // it does not use BST property !!!
            GetMinimumDifferenceDfs(root);

            nodeValues.Sort();
            int minDifference = int.MaxValue;

            if (nodeValues.Count == 1) return -1;
            for (int i = 1; i < nodeValues.Count; i++) 
            {
                minDifference = Math.Max(minDifference, (nodeValues[i] - nodeValues[i - 1]));
            }
            return minDifference;
        }

        private static void GetMinimumDifferenceDfs(TreeNode node)
        {
            if (node == null) return;

            nodeValues.Add(node.val);
            GetMinimumDifferenceDfs(node.left);
            GetMinimumDifferenceDfs(node.right);
        }

        /// <summary>
        /// Minimum Absolute Difference in BST
        /// https://leetcode.com/problems/minimum-absolute-difference-in-bst/description/?envType=problem-list-v2&envId=tree
        /// Input: root = [4,2,6,1,3]
        /// Output: 1
        /// </summary>
        public static int GetMinimumDifferenceOptimal(TreeNode root)
        {
            GetMinimumDifferenceInorder(root);
            return minDiff;
        }

        private static void GetMinimumDifferenceInorder(TreeNode node)
        {
            if (node == null) return;

            GetMinimumDifferenceInorder(node.left);

            if(prev.HasValue)
            {
                minDiff = Math.Min(minDiff, (node.val - prev.Value));
            }
            prev = node.val;

            GetMinimumDifferenceInorder(node.right);
        }

    }
}
