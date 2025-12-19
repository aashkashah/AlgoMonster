using static AlgoMonster.Mocks.Nov2725;

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

    public class NAryTree
    {
        public int val;
        public IList<NAryTree> children;
        public NAryTree(int _val, IList<NAryTree> _children)
        {
            val = _val;
            children = _children;
        }

    }
}
