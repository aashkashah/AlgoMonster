namespace AlgoMonster.Mocks
{
    /// <summary>
    /// Sales Path
    /// The car manufacturer Honda holds their distribution system in the form of a
    /// tree(not necessarily binary). The root is the company itself, 
    /// and every node in the tree represents a car distributor that receives cars from the parent node 
    /// and ships them to its children nodes.The leaf nodes are car dealerships that sell cars direct to consumers.
    /// In addition, every node holds an integer that is the cost of shipping a car to it.
    /// e.g
    /// 
    ///             0
    ///     5       3         6
    /// 4        2     0   1      5
    ///       1     10
    ///         1
    /// lowest sum path would be 0+3+2+1+1 = 7 or 0+6+1
    /// </summary>
    public class Nov2725
    {
        public class Node
        {
            public int cost;
            public Node[] children;
        }

        public static int getCheapestCost(Node rootNode)
        {
            var result = CalulateMinimum(rootNode, 0);
            return result;
        }

        public static int CalulateMinimum(Node node, int currsum) // node = 4, sum 5
        {
            var sum = currsum + node.cost;
            // breaking condition
            if (node.children == null)
            {
                return sum;
            }

            var currMin = int.MaxValue;
            for (int i = 0; i < node.children.Length; i++) // 5's child 4
            {
                var result = CalulateMinimum(node.children[i], sum);
                if (result < currMin)
                {
                    currMin = result;
                }
            }

            return currMin;
        }

        public static void InitNodeAndStartSolution()
        {
            // create node values .. initialzie values node
            var rootNode = new Node()
            {
                cost = 0,
                children = new Node[]
                {
                   new Node()
                   {
                       cost = 5,
                       children = new Node[]
                       {
                           new Node()
                           {
                               cost = 4
                           }
                       }
                   },
                   new Node()
                   {
                       cost = 3,
                       children = new Node[]
                       {
                           new Node()
                           {
                               cost = 2,
                               children = new Node[]
                               {
                                   new Node()
                                   {
                                       cost = 1,
                                       children = new Node[]
                                       {
                                           new Node()
                                           {
                                               cost = 1,
                                           }
                                       }
                                   },
                                   new Node()
                                   {
                                       cost = 10
                                   }
                               }
                           },
                           new Node()
                           {
                               cost = 0
                           }
                       }
                   },
                   new Node()
                   {
                       cost  = 6,
                       children = new Node[]
                       {
                           new Node()
                           {
                               cost = 1,
                           },
                           new Node()
                           {
                               cost = 5
                           }
                       }
                   }
                }
            };

            var res = getCheapestCost(rootNode);
            Console.WriteLine(res);
        }
    }
}
