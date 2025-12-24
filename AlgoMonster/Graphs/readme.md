https://www.notion.so/Graphs-2d39497b780980be896ce54e8b665337

DFS/BFS are the workhorses (how you move).

DP/backtracking are the intent (optimize/count vs enumerate).


Many problems are “graph + one extra layer”:

	Graph + shortest path ⇒ BFS/Dijkstra

	Graph + enumeration ⇒ backtracking DFS

	Graph + counting/optimization on DAG ⇒ DP

	Graph + connectivity merges ⇒ DSU

So don’t club graphs into DP or backtracking; instead:

	Graphs = the world

	Traversal/DP/backtracking/greedy/DSU = the strategy


A practical “interview decision tree”

When you see a graph-ish prompt, ask:

	Need minimum steps?
		→ Unweighted: BFS. Weighted: Dijkstra.

	Need an ordering / prerequisites?
		→ Topological sort (+ cycle detection).

	Need “all solutions” / “find any valid arrangement”?
		→ Backtracking DFS (path-level visited).

	Need “how many ways / best score” and looks acyclic or can be made DAG?
		→ DP on graph (topo or memo DFS).

	Need grouping / merging over time?
		→ Union-Find.

	Need 2 groups / constraints?
		→ Bipartite coloring.


1️. Graph Traversal / Connected Components

Goal: “Can I reach?”, “How many connected groups?”, “Is there a path?”

	(DFS / BFS + visited)

When it shows up

	“How many groups/components?”

	“Can we reach?”

	“Mark all connected things”

Common examples

	Number of Islands

	Flood Fill

	Count Connected Components

	Clone Graph

Mental model

	“Explore everything once.”

Key skill

	Correct visited handling

	Recursive DFS vs iterative BFS


2️. Shortest Path (Unweighted → BFS) (This is huge in interviews)

When it shows up

	“Minimum steps”

	“Shortest path”

	“Fewest moves / transformations”

	Common examples

	Word Ladder

	Shortest Path in Grid

	Rotting Oranges

	Knight Moves

Mental model

	“Layer by layer → first time you see target is optimal.”

⚠️ 80% of the time: plain BFS, not Dijkstra.


3️. State-Space BFS (Graph disguised as something else) (Top interview favorite)

This is the #1 “graph disguised as something else” pattern.
	
Goal: shortest steps where each state includes extra info.

When it shows up

	“Shortest path BUT you can do X once”

	“You have keys / powers / remaining moves”

	“Same node but different conditions matter”

	Common examples

	Shortest Path with Obstacles Elimination

	Keys and Rooms

	Grid with wall break

	Open the Lock

Mental model

	Node ≠ state
	visited = (node, extra_state)

This is where many people fail even though they “know BFS”.


4️. Backtracking on Graphs (Path Enumeration)
	
	(DFS + choose / explore / unchoose)

Goal: list all paths, find path with constraints, Hamiltonian-ish, “any path that satisfies…”

When it shows up

	“List all paths”

	“Find any valid arrangement”

	“Generate possibilities”

	Common examples

	All Paths From Source to Target (DAG)

	Reconstruct Itinerary

	Word Search (grid = graph)

Mental model

	“Try → recurse → undo”

This is not shortest path — it’s about possibilities.


5️. DAG + DP (Count / Optimize)

	(Graphs + DP combined)

When it shows up

	“How many ways?”

	“Longest / max / min path”

	No cycles (or can be topologically sorted)

	Common examples

	Count paths in DAG

	Longest Path in DAG

	Course Schedule II + DP variants

Mental model

	“Same subproblem repeats → cache result.”

If cycles exist → 🚨 stop and rethink.


6️. Topological Sort (Dependencies)

Goal: prerequisites, ordering, “can you finish all courses?”

	(Very common, very recognizable)

When it shows up

	“Prerequisites”

	“Ordering constraints”

	“Can you finish?”

	Common examples

	Course Schedule I / II

	Build order

	Task scheduling

Mental model

	“Things that depend on other things.”

Mental trigger: 

	“Dependencies / prerequisites / scheduling.”

Know both:

	BFS (indegree / Kahn)

	DFS (postorder)


7️. Union-Find (Connectivity without traversal)

	(Often easier than DFS/BFS)

When it shows up

	“Merge groups”

	“Are these connected?”

	“Redundant edge”

	Common examples

	Number of Provinces

	Accounts Merge

	Redundant Connection

Mental model

	“Connectivity without walking the graph.”