

using static AlgoMonster.Tree.Base.Tree;

namespace AlgoMonster.ReferAgain
{
    public class NodeR
    {
        public int val;
        public NodeR left;
        public NodeR right;
        public NodeR parent;
    }

    /// <summary>
    /// 1650. Lowest Common Ancestor of a Binary Tree III https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree-iii
    /// 428. Leftmost Column with at Least a One https://leetcode.com/problems/leftmost-column-with-at-least-a-one
    /// 987. Vertical Order Traversal of a Binary Tree https://leetcode.com/problems/vertical-order-traversal-of-a-binary-tree
    /// </summary>
    public static class ReviseTreeGraph
    {
        /// <summary>
        /// 1650. Lowest Common Ancestor of a Binary Tree III 
        /// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree-iii
        /// </summary>
        public static NodeR LowestCommonAncestor(NodeR p, NodeR q)
        {
            var list1 = new List<NodeR>();
            var hash = new HashSet<NodeR>();

            while (p != null)
            {
                list1.Add(p);
                p = p.parent;
            }

            while(q != null)
            {
                hash.Add(q);
                q = q.parent;
            }

            foreach(var item in list1)
            {
                if(hash.Contains(item)) return item;
            }

            return null;
        }

        public class BinaryMatrix
        {
              public int Get(int row, int col) { return -1; }
              public IList<int> Dimensions() { return null; }
        }

        /// <summary>
        /// 1428. Leftmost Column with at Least a One
        /// https://leetcode.com/problems/leftmost-column-with-at-least-a-one
        /// </summary>
        public static int LeftMostColumnWithOne(BinaryMatrix binaryMatrix)
        {
            /*
             
            binary search 
            start top right
            find first 1
                if found -> go left     
                if not -> go down
             */

            var dims = binaryMatrix.Dimensions();
            int rows = dims[0], cols = dims[1];

            int row = 0;
            int col = cols - 1;
            int res = -1;

            for (int i = 0; i < row; i++)
            {
                for(int j = col; j <= 0; j--)
                {
                    if (binaryMatrix.Get(i, j) == 1)
                    {
                        res = j;
                        col--;
                    }
                    else
                    {
                        row++;
                    }

                }
            }

            return res;
        }

        /// <summary>
        /// 987. Vertical Order Traversal of a Binary Tree
        /// https://leetcode.com/problems/vertical-order-traversal-of-a-binary-tree
        /// </summary>
        public static IList<IList<int>> VerticalTraversal(TreeNode root)
        {

            // col -> row -> values
            var map = new SortedDictionary<int, SortedDictionary<int, List<int>>>();
            var q = new Queue<(TreeNode, int, int)>();
            q.Enqueue((root, 0, 0));

            while (q.Count > 0)
            {
                var (node, col, row) = q.Dequeue();

                if (!map.TryGetValue(col, out var rowMap))
                {
                    rowMap = new SortedDictionary<int, List<int>>();
                    map[col] = rowMap;
                }
                if (!rowMap.TryGetValue(row, out var vals))
                {
                    vals = new List<int>();
                    rowMap[row] = vals;
                }
                vals.Add(node.val);

                if (node.left != null)
                    q.Enqueue((node.left, col - 1, row + 1));
                if (node.right != null)
                    q.Enqueue((node.right, col + 1, row + 1));
            }

            var res = new List<IList<int>>();
            foreach (var (col, rowMap) in map)           // columns in order
            {
                var colList = new List<int>();
                foreach (var (row, vals) in rowMap)       // rows in order
                {
                    vals.Sort();                         // tie-break same position
                    colList.AddRange(vals);
                }
                res.Add(colList);
            }
            return res;
        }

    }
}
