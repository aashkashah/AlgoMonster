
🧠 What “Greedy” actually means

Greedy = make the best local decision now that keeps the future as flexible as possible.

Jump Game example

🔑 Core Greedy Idea

	Track the farthest index you can reach so far.



Jump Game II

You want:

	minimum jumps

	but still maximum reach per jump

	This is like level-order BFS, but optimized greedily.

🔑 Core Greedy Idea

	When forced to jump, jump from the position that gives the farthest reach.



🚀 How to Internalize Greedy (for interviews)

When you see a greedy problem, ask:

	What am I optimizing?

	reach? steps? cost?

What state can I summarize?

	farthest reach

	current range

When am I forced to decide?

	when current range ends




Jump Game	    Strategy
Jump Game I	    Greedy (reachability range)
Jump Game II	Greedy (BFS layers collapsed)
Jump Game III	Graph BFS / DFS
