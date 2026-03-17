

| C#                          | Python              |
| --------------------------- | ------------------- |
| `List<int>`                 | `[]`                |
| `List<List<int>>`           | `[]` (append lists) |
| `Dictionary<int,int>`       | `{}`                |
| `Dictionary<int,List<int>>` | `defaultdict(list)` |
| `Queue<int>`                | `deque()`           |
| `int[] arr = new int[n]`    | `[0] * n`           |



4 LeetCode-style examples that give you the biggest Python return for effort.

	Two Sum → dict
	https://leetcode.com/problems/two-sum/

	Valid Anagram / Top K Frequent style counting → defaultdict(int) or Counter

	Course Schedule / Clone Graph → defaultdict(list) adjacency list

	Number of Islands / Flood Fill → 2D list creation and grid traversal
