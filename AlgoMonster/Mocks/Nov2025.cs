using AlgoMonster.Tree.Base;
using System.Text;

namespace AlgoMonster.Mocks
{
    /// <summary>
    /// Remove Duplicates in String
    /// You are given a string s and an integer k.
    /// Write a function to continuously 
    /// remove all k adjacent duplicates from s, 
    /// where the "adjacent" characters are equal, until none remain.
    /// 
    /// For instance, if k is 3 and the string is "daaabbbaa", 
    /// since we have "aaa" and "bbb" as adjacent triples, 
    /// the function should transform the string to "daa", 
    /// removing the "aaa" substring and "bbb" substring.
    /// </summary>
    public class Nov2025
    {

        // "daaabbbaa"
        //          ^ 
        // stack (d,1), (a,2)  
        // daa

        public static string RemoveDuplicates(string str, int k)
        {
            var charArr  = str.ToCharArray();
            var strBuilder = new StringBuilder();
            var stack = new Stack<(char, int)>();

            for(int i = 0; i < charArr.Length; i++)
            {
                var curr = stack.Peek();
                if(curr.Item2 == 3)
                {
                    //pop
                    stack.Pop();
                }
                if(curr.Item1 != charArr[i])
                {
                    // item doesn't exist, add
                    stack.Push(curr);
                }
                else
                {
                    // item exists, update count
                    var topItem = stack.Pop();
                    topItem.Item2++;
                    stack.Push(topItem);
                }

            }

            return "";
        }


        /// <summary>
        /// Largest Smaller BST Key
        /// Given a root of a Binary Search Tree(BST) and a number num, 
        /// implement an efficient function findLargestSmallerKey that finds the largest key in the tree 
        /// that is smaller than num.If such a number doesn't exist, return -1.
        /// Assume that all keys in the tree are nonnegative.
        // Analyze the time and space complexities of your solution.

        // For example:
        // For num = 17 and the binary search tree below:
        // Your function would return:
        // 14 since it’s the largest key in the tree that is still smaller than 17.
        /// </summary>
        /// <returns></returns>
        public int LargestSmallerBST(Tree.Base.Tree.TreeNode node, int k)
        {
            // num 17
            //              20
            //      9               25
            // 5       14       21      27


            // use BST property
            // what is BST property
            // left is smaller than root, right is larger than root
            
            var result = -1;
            var currNode = node;

            while(currNode != null) // null
            {
                if(currNode.val <  k) // 14 < 17? 
                {
                    // go right
                    result = currNode.val; // res 14
                    currNode = currNode.right; // curr null
                }
                else 
                {
                    // go left
                    currNode = node.left; // curr 9
                }
            }

            return result;
        }
    }
}
