using static AlgoMonster.Tree.Base.Tree;

namespace AlgoMonster.Tree._2.Root_To_Leaf
{
    public static class RootToLeaf
    {
        static int _SumRootToLeaf = 0;
        /// <summary>
        ///            6
        ///     1            2
        /// 5       3     0      8
        ///                   7    4 
        /// Given a binary tree and a target sum,
        /// return true if there exists a root-to-leaf path where the sum of node values equals target.
        /// </summary>
        /// <returns></returns>
        public static bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null) return false;
            return PathSumHelper(root, targetSum);
        }

        private static bool PathSumHelper(TreeNode node, int remainingSum)
        {
            // exit condition
            if(node == null) return false;

            remainingSum = remainingSum - node.val;

            if (node.left == null && node.right == null && remainingSum == 0)
                return true;

            return PathSumHelper(node.left, remainingSum) || PathSumHelper(node.right, remainingSum);
        }

        /// <summary>
        /// Sum of Root To Leaf Binary Numbers
        /// https://leetcode.com/problems/sum-of-root-to-leaf-binary-numbers/description/?envType=problem-list-v2&envId=tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int SumRootToLeaf(TreeNode root)
        {
            _SumRootToLeaf = 0;
            SumRootToLeafHelper(root, string.Empty);
            return _SumRootToLeaf;
        }

        public static void SumRootToLeafHelper(TreeNode node, string sum)
        { 
            // exit condition
            if(node == null) return; 

            // recurse 
            var pathSum = sum + node.val;

            // leaf node reached
            if (node.left == null && node.right == null)
            {
                _SumRootToLeaf += Convert.ToInt32(pathSum, 2);
                return;
            }

            SumRootToLeafHelper(node.left, pathSum);
            SumRootToLeafHelper(node.right, pathSum);
        }
    }
}
