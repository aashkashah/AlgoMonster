using System.IO;
using static AlgoMonster.Tree.Base.Tree;

namespace AlgoMonster.Tree._4.LCA_Or_Tree_As_Graph
{
    public static class LcaTreeAsGraph
    {
        /// <summary>
        /// [3,5,1,6,2,0,8,null,null,7,4]
        ///            6
        ///     1            2
        /// 5       3     0      8
        ///                   7    4 
        /// LCA of (5,3) = 1 LCA of (3,7) = 6
        /// 
        /// Given a binary tree, find the lowest common ancestor (LCA) of two given nodes p and q.
        /// The LCA is the lowest node that has both p and q as descendants
        /// (a node can be a descendant of itself).
        /// </summary>
        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            return FindLCA(root, p, q);
        }

        private static TreeNode FindLCA(TreeNode root, TreeNode p, TreeNode q)
        {
            // when child value found, return from that stack
            // when left and right are found and their parent nodes match for the first time, that's the LCA

            if (root == null)
                return null;

            if (root == p || root == q)
                return root;

            var leftLca = FindLCA(root.left, p, q);
            var rightLca = FindLCA(root.right, p, q);

            // if leftLca and rightLca both match the values, 
            // it means we have found lca
            if (leftLca != null && rightLca != null)
                return root;

            // left or right subtree is lca
            if (leftLca != null)
                return leftLca;
            else
                return rightLca;
        }

        /// <summary>
        ///        3
        ///       / \
        ///      5   1
        ///     / \   \
        ///    6   2   8
        ///       / \
        ///      7   4
        /// Distance between 5 and 4 = 2
        /// (5 → 2 → 4)
        /// 
        /// Given the root of a binary tree and two nodes p and q,
        /// return the number of edges in the shortest path between p and q.
        /// </summary>
        /// <returns></returns>
        public static int DistanceBetweenNodes(TreeNode root, TreeNode p, TreeNode q)
        {
            var lca = FindLCA(root, p, q);
            var d1 = DistanceBetweenNodesHelper(lca, p.val);
            var d2 = DistanceBetweenNodesHelper(lca, q.val);
            
            return 0;
        }

        private static int DistanceBetweenNodesHelper(TreeNode node, int target)
        {
            if (node == null) return -1;

            int left = DistanceBetweenNodesHelper(node.left, target);
            if (left!= -1) return left + 1;

            int right = DistanceBetweenNodesHelper(node.right, target);
            if(right != -1) return right + 1;

            return -1;

        }

        /// <summary>
        /// Lowest common ancestor of a binary tree 4
        /// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree-iv
        /// solved in 15 mins
        /// </summary>
        public static TreeNode LowestCommonAncestor4(TreeNode root, TreeNode[] nodes)
        {
            if (nodes == null) return null;
            if (nodes.Length == 1) return nodes[0];

            var arr = nodes.Select(x => x.val).ToArray();
            return Lca4Helper(root, arr);
        }

        private static TreeNode Lca4Helper(TreeNode root, int[] nodes)
        {
            // return condition
            if (root == null) return null;
            if (nodes.Contains(root.val)) return root;

            // recursion
            var leftlca = Lca4Helper(root.left, nodes); // 6
            var rightlca = Lca4Helper(root.right, nodes); // 2

            if (leftlca != null && rightlca != null) return root;

            if (leftlca == null) return rightlca;
            else return leftlca;

        }
    }
}
