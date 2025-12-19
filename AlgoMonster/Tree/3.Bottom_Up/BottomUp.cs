using AlgoMonster.Tree.Base;
using static AlgoMonster.Tree.Base.Tree;

namespace AlgoMonster.Tree._3.Bottom_Up
{
    public static class BottomUp
    {
        /// <summary>
        ///           6
        ///     1            2
        /// 5       3     0      8
        ///                   7    4 
        /// Given the root of a binary tree, return its depth.
        /// The depth of a binary tree is defined as the number of nodes along the longest path from the 
        /// root node down to the farthest leaf node.
        /// </summary>
        /// <param name="node"></param>
        public static int MaximumDepthOfBinaryTree(TreeNode node)
        {
            var result = MaxDepthHelper(node);
            return result;
        }

        private static int MaxDepthHelper(TreeNode node) //1 , depth = 2
        {
            // base condition
            if (node == null) return 0;

            // recursion
            var left = MaxDepthHelper(node.left);
            var right = MaxDepthHelper(node.right);

           return 1 + Math.Max(left, right);
        }


        /// <summary>
        /// It is a type of binary tree in which the difference between 
        /// the height of the left and the right subtree for each node is either 0 or 1. 
        /// https://leetcode.com/problems/balanced-binary-tree/description/
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static bool IsBalancedBinaryTree(TreeNode node)
        {
            var result = BalancedTreeHelper(node);
            if (result != -1)
                return true;
            return false;
        }

        private static int BalancedTreeHelper(TreeNode node)
        {
            // base case
            if (node == null) return 0;

            // recurse
            var left = BalancedTreeHelper(node.left);
            if (left == -1) return -1;
            
            var right = BalancedTreeHelper(node.right);
            if(right == -1) return -1;

            if (Math.Abs(left - right) > 2) return -1;

            return 1 + Math.Max(left, right);
        }

        /// <summary>
        /// Given the root of a binary tree, return the length of the diameter of the tree.


        /// </summary>
        /// Given the root of a binary tree, return the length of the diameter of the tree.
        /// The diameter of a binary tree is the length of the longest path between any two nodes in a tree.
        /// This path may or may not pass through the root.
        /// The length of a path between two nodes is represented by the number of edges between them.
        /// https://leetcode.com/problems/diameter-of-binary-tree/
        /// <param name="node"></param>
        /// <returns></returns>
        public static int DiameterOfBinaryTree(TreeNode node)
        {
            int best = 0;
            DiameterHelper(node, ref best);
            return best;
        }

        private static int DiameterHelper(TreeNode node, ref int best)
        {
            // base case
            if (node == null) return 0;

            // recursion
            var left = DiameterHelper(node.left, ref best);

            var right = DiameterHelper(node.right, ref best);

            best = Math.Max(best, left + right);

            // what am i returning to parent?
            return 1 + Math.Max(left, right);
        }

        /// <summary>
        ///  Maximum Depth of N-ary Tree
        ///  https://leetcode.com/problems/maximum-depth-of-n-ary-tree/description/?envType=problem-list-v2&envId=tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int MaxDepthNAryTree(NAryTree root)
        {
            return MaxDepthNAryTreeHelper(root);
        }

        public static int MaxDepthNAryTreeHelper(NAryTree node)
        {
            // return condition
            if (node == null) return 0;

            // recursion
            var maxChildDepthForThisLevel = 0;
            for (int i = 0; i < node.children.Count; i++)
            {
                var depth = MaxDepthNAryTreeHelper(node.children[i]);
                if (depth > maxChildDepthForThisLevel)
                {
                    maxChildDepthForThisLevel = depth;
                }

                // refined way to write
                // foreach(var child in nodechildren) 
                // maxDepth = Math.Max(maxdepth, MaxDepthNAryTreeHelper(child))

            }
            return maxChildDepthForThisLevel+1;
        }
    }
}
