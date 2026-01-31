https://www.notion.so/Graphs-2d39497b780980be896ce54e8b665337

Graphs are the structure.
Traversal (BFS/DFS) is how you move.
The pattern is decided by the goal.

🟢 Tier 1 (Must be automatic)

	BFS / DFS Traversal & Reachability (covers ~65–70% of graph questions)

	Shortest Path (BFS / Dijkstra) (coverage: massive)

	State-Space BFS ⚠️ High ROI (coverage: disproportionately high)

	Cycle Detection

	Topological Sort (~20 - 25%)

🟡 Tier 2 (Recognize & apply)

	Grid-as-Graph (Islands, Flood Fill)

	Union-Find (optional, but nice ~10%)

	Bipartite / Graph Coloring

	Backtracking on Graphs

	DAG + DP

🔵 Tier 3 (Nice-to-have)

	MST

	SCC


Here’s the tightest possible plan:

Order	Pattern							Why
1		BFS / DFS						Foundation
2		Shortest Path (BFS/Dijkstra)	Very common
3		State-Space BFS					High failure rate
4		Topological Sort				Dependency questions

Everything else is optional.


----- TIER 1 -----

1️. Graph Traversal / Connected Components

When you see:

	“Can you reach…”

	“Is there a path…”

	“How many components…”

	“Traverse all nodes…”

	Grids, islands, networks

Core idea

	BFS → shortest / level by level

	DFS → explore fully / structure detection

Common examples

	Number of Islands

	Keys and Rooms

	Count Connected Components

	Clone Graph

Mental model

	“Explore everything once.”

Interview reflex 🧠

	“This is just BFS/DFS + visited”

Key skill

	Correct visited handling

	Recursive DFS vs iterative BFS


2️. Shortest Path (Unweighted → BFS) (This is huge in interviews)

Sub-patterns

	Unweighted → BFS

	Weighted (positive) → Dijkstra

	Grid + obstacles → BFS

	Multi-source BFS → start from many nodes

When you see:

	“Minimum steps”

	“Shortest time”

	“Fewest moves”

	“Minimum cost”

Common examples

	Word Ladder

	Shortest Path in Grid

	Rotting Oranges

	Knight Moves

Mental model

	“Layer by layer → first time you see target is optimal.”

Interview reflex 🧠

	“Edges weighted? If no → BFS. If yes → Dijkstra.”

⚠️ 80% of the time: plain BFS, not Dijkstra.


3. State-Space BFS (Graph disguised as something else) (Top interview favorite)

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

4. Cycle Detection

Is something invalid or looping forever?

Two flavors

	Directed graph → DFS + recursion stack

	Undirected graph → DFS + parent tracking

When you see:

	“Deadlock”

	“Circular dependency”

	“Valid schedule?”

	“Infinite loop?”

Typical problems

	Course Schedule

	Detect Cycle in Graph

Interview reflex 🧠

	“Cycle? → DFS + extra state”


5. Topological Sort (Ordering with Dependencies) VERY high interview frequency

VERY high interview frequency

When you see:

	“Must happen before”

	“Dependencies”

	“Order of execution”

	“Build system / tasks”

Two ways

	Kahn’s algorithm (BFS + indegree)

	DFS postorder

Typical problems

	Course Schedule II

	Alien Dictionary

	Build Order

Interview reflex 🧠

	“Directed + dependency language → topo sort”


-----  TIER 2 -----


6. Graph as Grid (Islands, Flood Fill)

Feels like graphs, looks like matrices

When you see:

	2D grid

	Adjacent cells

	Up/down/left/right

Typical problems

	Number of Islands

	Flood Fill

	Rotting Oranges

Interview reflex 🧠

	“Grid = graph with implicit edges”


7. Union Find (Disjoint Set)

Connectivity without traversal

When you see:

	“Merge groups”

	“Are these connected?”

	Dynamic connectivity

	Redundant connections

Typical problems

	Redundant Connection

	Number of Provinces

	Accounts Merge

Interview reflex 🧠

	“Repeated connect + query → Union Find”


8. Bipartite Graph / Coloring

2-group separation

When you see:

	“Two teams”

	“No adjacent same type”

	“Conflict graph”

Typical problems

	Is Graph Bipartite

	Possible Bipartition

Interview reflex 🧠

	“Two colors, BFS/DFS, conflict check”


9. Graph + DP (DAG Optimization / Counting) (common at Google)

When it shows up

	“How many ways…”

	“Max / min / longest path”

	Graph is acyclic or sortable

Mental model

	“Graph traversal + memoization”
	“Topological order OR DFS + cache”

Hard stop rule 🚨

	If cycles exist and no bound → DP invalid

This rule alone saves people from disaster.


----- TIER 3 -----

10. Minimum Spanning Tree (MST)

Connect everything cheaply

Algorithms

	Kruskal (Union Find)

	Prim (PQ)

When you see:

	“Connect all nodes”

	“Min cost to connect”

	“Network wiring”

11. Strongly Connected Components (SCC)

Advanced directed graph


How these patterns relate to other algos

| Pattern          | Uses BFS | Uses DFS | Uses DP | Uses Backtracking |
| ---------------- | -------- | -------- | ------- | ----------------- |
| Traversal        | ✅        | ✅        | ❌       | ❌                 |
| Shortest Path    | ✅        | ❌        | ❌       | ❌                 |
| State BFS        | ✅        | ❌        | ❌       | ❌                 |
| Backtracking     | ❌        | ✅        | ❌       | ✅                 |
| DAG + DP         | ❌        | ✅        | ✅       | ❌                 |
| Topological Sort | ✅ / ❌   | ✅        | ❌       | ❌                 |
| Union-Find       | ❌        | ❌        | ❌       | ❌                 |





--- In reference to DP / backtracking ---


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