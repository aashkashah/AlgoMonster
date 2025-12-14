namespace AlgoMonster.Tree.Base
{
    public class Tree
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left, right;
            public TreeNode(int v = 0, TreeNode l = null, TreeNode r = null) 
            { 
                val = v; 
                left = l; 
                right = r; 
            }
        }
    }
}
