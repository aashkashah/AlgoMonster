using static AlgoMonster.Tree.Base.Tree;

namespace AlgoMonster.Graphs.Tier1._1.Graph_Traversal
{
    public class Traversals
    {
        /// <summary>
        /// The Maze
        /// https://leetcode.com/problems/the-maze
        /// </summary>
        public static bool HasPath(int[][] maze, int[] start, int[] destination)
        {



            return false;
        }


        /// <summary>
        /// 863. All Nodes Distance K in Binary Tree
        /// https://leetcode.com/problems/all-nodes-distance-k-in-binary-tree/
        /// </summary>
        public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {

            // Think of BFS like ripples in water.

            // 1) Build parent pointers
            var parent = new Dictionary<TreeNode, TreeNode>();
            BuildParent(root, null, parent);

            // 2) BFS from target
            var q = new Queue<TreeNode>();
            var visited = new HashSet<TreeNode>();

            q.Enqueue(target);
            visited.Add(target);

            int dist = 0;

            while (q.Count > 0)
            {
                int size = q.Count;

                // If we reached distance k, everything currently in the queue is the answer
                if (dist == k)
                {
                    var ans = new List<int>();
                    while (q.Count > 0) ans.Add(q.Dequeue().val);
                    return ans;
                }

                // Expand one BFS "layer"
                for (int i = 0; i < size; i++)
                {
                    var cur = q.Dequeue();

                    // neighbor 1: left
                    if (cur.left != null && visited.Add(cur.left))
                        q.Enqueue(cur.left);

                    // neighbor 2: right
                    if (cur.right != null && visited.Add(cur.right))
                        q.Enqueue(cur.right);

                    // neighbor 3: parent
                    if (parent.TryGetValue(cur, out var p) && p != null && visited.Add(p))
                        q.Enqueue(p);
                }

                dist++;
            }

            return new List<int>();
        }

        private void BuildParent(TreeNode node, TreeNode par, Dictionary<TreeNode, TreeNode> parent)
        {
            if (node == null) return;

            parent[node] = par;
            BuildParent(node.left, node, parent);
            BuildParent(node.right, node, parent);
        }
    }
}
