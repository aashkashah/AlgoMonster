Dynamic programming

https://www.notion.so/Dynamic-Programming-2c99497b7809801480bbce6b2ec7dea2

🎯 High-confidence interview picks (do these)

If you want max ROI, practice:

	Climbing Stairs

	Decode Ways

	Unique Paths

	Binary strings w/ constraints

	Word Break

These cover 80% of DP generation patterns.

1. Sequence DP (1D DP)
### When to use

	If the problem is over a **linear sequence** (array/string) and each state depends on **previous indexes**.

**Examples:**

	- Fibonacci / Climbing Stairs
	- House Robber
	- Coin Change (min coins / total ways)
	- Longest Increasing Subsequence (LIS)
	- Partitions / Integer Break

✔ Recurrence looks like:

`dp[i] = combine(dp of earlier indexes)`

2. String DP (2D DP comparing two strings)

### When to use

	Comparing two strings → transformations, subsequences, edits.

These are table DP problems involving two words.

**Examples:**

	- Edit Distance
	- Longest Common Subsequence (LCS)
	- Deletion Distance
	- Longest Common Substring
	- Wildcard Matching / Regex Matching

✔ State: `dp[i][j]` comparing prefixes.

3. Subset / Knapsack DP

### When to use

	Problems involving **choices**: take or skip. Limited capacity. Subset sum style.

	Choose or not choose items.

	Optimize sum/weight/value.

**Examples:**

	- 0/1 Knapsack
	- Subset Sum
	- Partition Equal Subset Sum
	- Target Sum
	- Scheduling with weights

✔ Recurrence revolves around *choice*: take or skip.

4. Grid / Matrix DP (Path Problems)

### When to use

	You move on a 2D grid: up, down, right, left, diagonal.

	Moving through a grid with constraints.

**Examples:**

	- Min Path Sum
	- Unique Paths
	- Cherry Pickup
	- Dungeon Game
	- Maximal Square

✔ Usually:

`dp[i][j]` = something from top/left or neighbors.

5. Interval DP (subarrays, palindromes)

### When to use

	If the problem asks about **subarrays/substrings** and optimal decisions depend on 
	breaking the interval into smaller intervals.

**Examples:**

	- Longest Palindromic Subsequence
	- Minimum Palindrome Partition Cuts
	- Burst Balloons
	- Optimal BST
	- Matrix Chain Multiplication

✔ State: `dp[i][j]` depends on smaller intervals.

6. Tree DP

### When to use

	If the problem is on a **tree** and you're combining answers from child subtrees.

	DP on structured graphs, usually bottom-up.

**Examples:**

	- Tree Diameter
	- Max Path Sum in a Binary Tree
	- House Robber III
	- Counting number of tree paths
	- DP on binary search trees

✔ Often: return a struct with "include/exclude" info upward.

7. Bitmask DP (for small N, subsets)

### When to use

	When N is **small (< 20)** and you need to consider *all subsets*.

	Used when N ≤ 20 and you need to consider all subsets.

**Examples:**

	- Traveling Salesman Problem (TSP)
	- Minimum Cost to Visit All Points
	- Assignments / Matching problems
	- Counting subsets with constraints

✔ State: `dp[mask][i]`


| Day   | Family                   | Difficulty Curve    | Good Starter Problem |
| **1** | **Sequence DP**          | Easy → Medium       | Climbing Stairs, House Robber |
| **2** | **String DP**            | Medium → Hard       | LCS, Edit Distance |
| **3** | **Knapsack / Subset DP** | Medium              | Partition Equal Subset Sum |
| **4** | **Grid DP**              | Easy → Medium       | Min Path Sum |
| **5** | **Interval DP**          | Hard                | Palindromic Subsequence |
| **6** | **Tree DP**              | Medium              | House Robber III |
| **7** | **Bitmask DP**           | Hard but mechanical | TSP small version |


5 Beginner Patterns

Fibonacci Numbers
	Climbing Stairs
	House Robber
	Fibonacci NumbersMaximum Alternating Subsequence Sum

Zero / One Knapsack
	Partition Equal Subset Sum
	Target Sum

Unbounded Knapsack
	Coin Change
	Coin Change II
	Minimum Cost for Tickets
	
Longest Common Subsequence
	Longest Common Subsequence
	Longest Increasing Subsequence
	Edit Distance
	Distinct Subsequences
	
Palindromes
	Longest Palindromic Substring
	Palindromic Substrings
	Longest Palindromic Subsequence