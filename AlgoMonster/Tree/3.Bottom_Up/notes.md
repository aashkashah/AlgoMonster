
🔑 Rule to Remember Forever

	If the question is asking for height / depth → do NOT pass depth down

Pattern: Bottom-Up (Postorder)
Traversal: Postorder
	What do I return? Depth of subtree rooted at this node
	What do children give me? Their depths
	What do I do? 1 + max(left, right)

In bottom-up problems:

❌ Don’t pass depth down
✅ Let children return their depth up

📌 One Golden Sentence (memorize this)

	Bottom-up tree problems ask children for information,
	use it at the current node, and return something simpler upward.