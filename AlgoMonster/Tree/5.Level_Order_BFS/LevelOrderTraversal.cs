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

            if (root == null)
                return new List<List<int>>();

            var result = new List<List<int>>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var lvlLength = queue.Count;
                var nodeList = new List<int>();

                for (int i = 0; i < lvlLength; i++)
                {
                    var node = queue.Dequeue();
                    nodeList.Add(node.val);

                    if (node.left  != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null) 
                    {
                        queue.Enqueue(node.right);  
                    }
                }
                result.Add(nodeList);
            }

            return result;
        }

        /// <summary>
        /// Binary Tree Zigzag Level Order Traversal
        /// https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/description/
        ///            6
        ///     1             2
        /// 5       3     0      8
        ///                   7     4 
        ///  [[6], [2, 1], [5, 3, 0, 8], [4, 7]]
        public static IList<IList<int>> ZigZagLevelOrderTraversal(TreeNode root)
        {
            if (root == null) return [];
            IList<IList<int>> result = new List<IList<int>>();

            var isLeftToRight = true;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                var lvlLength = queue.Count;
                var levelList = new List<int>();

                for(int i = 0; i < lvlLength; i++)
                {
                    var curr = queue.Dequeue();
                    levelList.Add(curr.val);

                    if (curr.left != null) queue.Enqueue(curr.left);
                    if (curr.right != null) queue.Enqueue(curr.right);
                }

                if (!isLeftToRight)
                {
                    levelList.Reverse();
                }
                result.Add(levelList);
                isLeftToRight = !isLeftToRight;
            }
            
            return result;
        }

        /// <summary>
        /// Binary Tree Right Side View
        /// https://leetcode.com/problems/binary-tree-right-side-view/
        /// </summary>
        public static IList<int> RightSideView(TreeNode root)
        {
            if (root == null) return [];

            var res = new List<int>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            
            while(queue.Count > 0)
            {
                var levelCount = queue.Count;

                for(int i = 0; i < levelCount; i++)
                {
                    if(i == levelCount - 1)
                    {
                        res.Add(queue.Peek().val);  
                    }

                    var curr = queue.Dequeue();

                    if(curr.left != null) queue.Enqueue(curr.left);
                    if(curr.right != null) queue.Enqueue(curr.right);
                }
            }

            return res;
        }

        /// <summary>
        /// Average of Levels in a Binary Tree
        /// https://leetcode.com/problems/average-of-levels-in-binary-tree/
        /// </summary>
        public static IList<double> AverageOfLevels(TreeNode root)
        {
            if (root == null) return [];
            var res = new List<double>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                var levelCount = queue.Count;
                double sum = 0;
                for(int i = 0; i < levelCount; i++)
                {
                    var curr = queue.Dequeue();
                    sum += curr.val;

                    if (curr.left != null) queue.Enqueue(curr.left);
                    if (curr.right != null) queue.Enqueue (curr.right);
                }

                res.Add(sum/levelCount);
            }

            return res;
        }

    }
}
