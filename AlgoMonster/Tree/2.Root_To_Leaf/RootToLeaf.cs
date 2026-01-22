using static AlgoMonster.Tree.Base.Tree;

namespace AlgoMonster.Tree._2.Root_To_Leaf
{
    public static class RootToLeaf
    {
        static int _SumRootToLeaf = 0;
        static int _goodNodes = 0;
        static int _maxlen = 0;

        /// <summary>
        ///            6
        ///     1            2
        /// 5       3     0      8
        ///                   7    4 
        /// Given a binary tree and a target sum,
        /// return true if there exists a root-to-leaf path where the sum of node values equals target.
        /// </summary>
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
        /// https://leetcode.com/problems/sum-of-root-to-leaf-binary-numbers/description
        /// </summary>
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

        /// <summary>
        /// Count Good Nodes in Binary Tree
        /// https://leetcode.com/problems/count-good-nodes-in-binary-tree/description/
        /// </summary>
        public static int GoodNodes(TreeNode root)
        {
            if (root == null) return _goodNodes;
            GoodNodesHelper(root, int.MinValue);
            return _goodNodes;
        }

        private static void GoodNodesHelper(TreeNode node, int maxSofar) // 5
        {
            // return condition
            if (node == null) return;

            // check
            if (node.val >= maxSofar)
            {
                _goodNodes++; // 4
                maxSofar = node.val; // 5
            }
            GoodNodesHelper(node.left, maxSofar);
            GoodNodesHelper(node.right, maxSofar);
        }

        /// <summary>
        /// https://leetcode.com/problems/binary-tree-longest-consecutive-sequence
        /// </summary>
        public static int LongestConsecutive(TreeNode root)
        {
            LongestConsecutiveHelper(root, null, 0);
            return _maxlen;
        }

        private static void LongestConsecutiveHelper(TreeNode p, TreeNode parent, int length)
        {
            if (p == null) return;
            length = (parent != null && p.val == parent.val + 1) ? length + 1 : 1;
            _maxlen = Math.Max(_maxlen, length);

            LongestConsecutiveHelper(p.left, p, length);
            LongestConsecutiveHelper(p.right, p, length);
        }

        /// <summary>
        /// https://leetcode.com/problems/binary-tree-longest-consecutive-sequence-ii
        /// </summary>
        public int LongestConsecutive2(TreeNode root)
        {

        }

        private static void LongestConsecutive2Helper(TreeNode p, TreeNode parent, int length)
        {
            if (p == null) return;

            length 

            LongestConsecutive2Helper(p.left, p, length);
        }
    }
}
