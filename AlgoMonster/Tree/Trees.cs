using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.Tree
{
    public class Trees
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left, right;
            public TreeNode(int v = 0, TreeNode l = null, TreeNode r = null) { val = v; left = l; right = r; }
        }

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            // return if root null
            // result and queue
            // while until queue not empty
            // capture level
            // loop until cuur q length not reached

            var result =  new List<IList<int>>();
            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count() > 0)
            {
                var currLvlLengtt = q.Count();
                result.Add(new List<int>());

                for(int i = 0; i < currLvlLengtt; i++)
                {
                    TreeNode node = q.Dequeue();
                    result[currLvlLengtt].Add(node.val);

                    if(node.left != null)
                        q.Enqueue(node.left);

                    if(node.right != null)
                        q.Enqueue(node.right);
                }
                currLvlLengtt++;
            }

            return result;
        }

        
        /// <summary>
        /// [3,5,1,6,2,0,8,null,null,7,4]
        ///            6
        ///     1            2
        /// 5       3     0      8
        ///                   7    4 
        /// LCA of (5,3) = 1 LCA of (3,7) = 6
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
           return FindLCA(root, p, q);
        }

        private TreeNode FindLCA(TreeNode root, TreeNode p, TreeNode q)
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

        /// <summary>
        /// Valid Binary Search Tree
        /// Given the root of a binary tree, return true if it is a valid binary search tree, otherwise return false.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBST(TreeNode root)
        {
            // use bfs of dfs
            //         12
            //              
            //           13     15
            //        11    14

            // whule
            // break until queue is empty
            // return right away if left > root or right < root
            return IsValidBstHelper(root, int.MinValue, int.MaxValue);
        }

        private bool IsValidBstHelper(TreeNode root,int minValue, int maxVal)
        {
            if (root == null) return true;
            if (!(minValue < root.val && root.val < maxVal)) return false;
            return (IsValidBstHelper(root.left, minValue, root.val) && IsValidBstHelper(root.right, root.val, maxVal));
        }

        /// <summary>
        /// https://www.geeksforgeeks.org/dsa/find-k-th-smallest-element-in-bst-order-statistics-in-bst/#
        /// </summary>
        /// <returns></returns>
        public int kthSmallestElement(TreeNode node, int k)
        {
            // in order traversal
            // left root right
            int count = 0;
            return kthSmallestElementHelper(node, ref count, k);

        }

        private int kthSmallestElementHelper(TreeNode node, ref int count, int k)
        {
            if (count == 0) return -1;

            int left = kthSmallestElementHelper(node.left, ref count, k);

            if (left != -1) return left;

            count++;

            if (count == k) return node.val;

            int right = kthSmallestElementHelper(node.right, ref count.k);
            return right;

        }

        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {

            return null;
        }
    }
}
