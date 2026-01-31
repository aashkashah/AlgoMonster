Union Find 

Use Union-Find when:

	Graph is undirected

	You care about cycles

	Edges are processed incrementally

	Connectivity changes dynamically

Classic DSU problems:

	Graph Valid Tree

	Number of Connected Components

	Redundant Connection

	Kruskal’s MST

Mental model

Union = “merge groups”
Find = “who is your leader?”
Same leader + new edge = cycle