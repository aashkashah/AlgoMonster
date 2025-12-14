using static AlgoMonster.Tree.Base.Tree;

namespace AlgoMonster.Tree._5.Level_Order_BFS
{
    // level orer traveral
    // zig zag level order traversal
    // binary tree right side view
    public static class LevelOrderTraversal
    {   

        /// <summary>
        /// Level order traversal
        ///            6
        ///     1            2
        /// 5       3     0      8
        ///                   7    4 
        ///  [[6], [1, 2], [5, 3, 0, 8], [7, 4]]
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static List<List<int>> FindLevelOrderTraversal(TreeNode root)
        {
            // queue
            // level length
            // while, queue != null
            // deque current
            //  level order 
            //  enqueue children, inner loop count remains same
            //  append each chil dequeued to list
            // when inner loop ends, add that list to top result

            var result = new List<List<int>>();
            var queue = new Queue<TreeNode>();

            while (queue.Count > 0)
            {
                var lvlLength = queue.Count;
                var nodeList = new List<int>();

                for (int i = 0; i < lvlLength; i++)
                {
                    var node = queue.Dequeue();
                    nodeList.Add(node.val);
                }
                result.Add(nodeList);
            }

            return result;
        }

        /// <summary>
        /// Level order traversal
        ///            6
        ///     1            2
        /// 5       3     0      8
        ///                   7    4 
        ///  [[6], [2, 1], [5, 3, 0, 8], [4, 7]]
        public static List<List<int>> ZigZagLevelOrderTraversal(TreeNode root)
        {
            // 
            var result = new List<List<int>>();

            return null;
        }

    }
}
