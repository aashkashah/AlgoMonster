
--- Trees ultimate pattern cheat sheat --- [Aashka + ChatGPT]

https://www.notion.so/Trees-2c99497b78098047b254e33218e11bd7

	 ----- Follow this and you're GOLD -----

🧠 How to Solve Each Easy Question (Same Ritual)

	Before writing code, say out loud:

		What pattern is this?

		What do I return?

		Do I carry state or compute from children?

		Pre / In / Post / Level?

		This is what interviewers actually care about.

🧠 The real “secret”: Hard trees = Pattern + Return Contract

	When you’re stuck, ask:

		What should my function return to the parent? (one number? tuple? node? bool+height?)

		Is there a separate global answer I must update?

		Do I need to pass state down? (path/backpack)

		If you answer those 3, “hard” becomes routine.
	

📁 Folder 1: DFS Traversal (Visit Every Node) [Tier 2]

	Goal of this folder

		Get comfortable walking the tree and knowing when to do work.

	Questions

		Binary Tree Preorder Traversal

		Binary Tree Inorder Traversal

		Binary Tree Postorder Traversal

		Count Nodes in a Binary Tree

		Sum of All Nodes in Binary Tree

	🧠 Focus:

		If the problem says “for every node…” → start here
	
		Recursive base case

		Where the “work” goes (before / between / after recursion)
	
	Medium/Hard becomes: “traverse + bookkeeping”

	- e.g., **Vertical Order Traversal**, **Boundary of Binary Tree** (still traversal, just grouping rules)

📁 Folder 2: Root → Leaf Path Problems [Tier 1]

	Goal

		Learn to carry state downward + backtrack cleanly.

	Questions

		Path Sum

		Path Sum II (return all paths)

		Binary Tree Paths

		Sum Root to Leaf Numbers

		Path with Given Sequence (variant)

	🧠 Focus:

		Pass path / sum

		Backtracking (remove last)

		Detect leaf correctly

	**Mental hook**

		> “I carry a backpack while walking down.”

	Medium/Hard becomes: “carry more state” or “count paths not necessarily root→leaf”

		- Path Sum III (paths can start anywhere) = prefix-sum + DFS (Path + extra technique)


📁 Folder 3: Bottom-Up / Postorder (Most Important) [Tier 1]

	Goal

		Children compute → parent decides.

	Questions (🔥 must-do)

		Maximum Depth of Binary Tree

		Balanced Binary Tree

		Diameter of Binary Tree

		Binary Tree Maximum Path Sum

		Count Univalue Subtrees

	🧠 Focus:

		Return value meaning

		Global vs returned value

		Postorder traversal

		👉 If you master this folder, you’re good.

	**Mental hook**

		> “Children report up to the parent.”
	
	**This is the engine of most hard questions.**

	Medium/Hard becomes:  “return multiple things” + “update global”
		- **Max Path Sum** (return best downward path, update best overall)
		- **Largest BST Subtree** (return isBST, size, min, max)
		- **Serialize/validate properties** (return structured info)

📁 Folder 4: LCA & Tree as Graph [Tier 2]

	Goal

		Handle ancestors, distances, and “between nodes”.

	Questions

		Lowest Common Ancestor of Binary Tree

		Lowest Common Ancestor of BST

		Distance Between Two Nodes in a Binary Tree

		All Nodes Distance K in Binary Tree

		Smallest Subtree with All Deepest Nodes

	🧠 Focus:

		Return node or null

		Early stopping

		Sometimes parent pointers / BFS

	**Mental hook**

		> “Tree + parent = graph.”

	Medium/Hard becomes: “distance + parent links + BFS/DFS”
		- **Nodes at Distance K** (LCA/graph + BFS)
		- “Kth ancestor”, “burning tree”, etc.


📁 Folder 5: Level Order / BFS [Tier 1]

	Goal

		Think in layers, not recursion.

	Questions

		Binary Tree Level Order Traversal

		Binary Tree Zigzag Level Order Traversal

		Average of Levels in Binary Tree

		Right Side View of Binary Tree

		Minimum Depth of Binary Tree

	🧠 Focus:

		Queue usage

		Loop per level

		Level size trick

	**Mental hook**

		> “Process one level at a time.”
	
	Medium/Hard becomes: “multi-source BFS” or “augment levels”
		Zigzag, Right view, connect next pointers, min time to spreadstyle problems
	

📁 Folder 6: BST-Specific Logic [Tier 3]

	Goal

		Exploit ordering — don’t brute force.

	Questions

		Validate Binary Search Tree

		Search in a BST

		Lowest Common Ancestor of BST

		Kth Smallest Element in a BST

		Convert Sorted Array to BST

	🧠 Focus:

		Inorder = sorted

		Left < root < right

		Pruning logic

	Medium/Hard becomes: “inorder as sorted stream” or “range constraints”
		Recover BST, BST iterator, kth smallest, two-sum in BST

📁 Folder 7: Tree Construction / Serialization [Tier 3]

	Goal

		Understand how structure is rebuilt.

	Questions

		Construct Binary Tree from Preorder & Inorder

		Construct Binary Tree from Inorder & Postorder

		Serialize and Deserialize Binary Tree

		Convert Sorted List to Binary Search Tree

		Flatten Binary Tree to Linked List

	🧠 Focus:

		Index boundaries

		Recursive construction

		Preorder positioning	

	Medium/Hard becomes: “careful indexing/encoding”
		Serialize/Deserialize, build from traversals, flatten, etc.