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

            if (root.val == p.val || root.val == q.val)
                return root;

            var leftLca = LowestCommonAncestor(root.left, p, q);
            var rightLca = LowestCommonAncestor(root.right, p, q);

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
    }
}
