using AlgoMonster.Grid;
using AlgoMonster.Heap;
using AlgoMonster.Trie;
using AlgoMonster.Mocks;
using AlgoMonster.DynamicProgramming;
using AlgoMonster.Arrays.SlidingWindow;
using AlgoMonster.Search;
using AlgoMonster.RecursionAndBacktracking;
using AlgoMonster.Graphs.TopologicalSort;
using AlgoMonster.Arrays.HashSet;
using AlgoMonster.Arrays.TwoPointers;
using AlgoMonster.LinkedList;


Console.WriteLine("Start the beautiful challenege..");

//var h = new MinHeap<int>();
//h.Push(4);
//h.Push(2);
//h.Push(7);
//h.Push(1);
//h.Push(3);
//Console.WriteLine(h.Peek()); // what prints?
//Console.WriteLine(h.Pop());  // and now?
//Console.WriteLine(h.Peek()); // now?


//var g = new Graph();
//g.AddEdge(0, 1); g.AddEdge(0, 2); g.AddEdge(1, 3); g.AddEdge(2, 3); g.AddEdge(3, 4);


//var parent = Bfs.BfsParents(g.Adj, 0);

////reconstruct path 0 -> 4
//var path = new List<int>();
//for (int cur = 4; cur != -1; cur = parent[cur]) path.Add(cur);
//path.Reverse();
//Console.WriteLine(string.Join(" -> ", path)); // shortest path in unweighted graph

////Trie basic example

//var t = new Tries();
//t.Insert("cat");
//t.Insert("car");
//t.Insert("care");
//t.Insert("dog");


//Console.WriteLine(t.Search("cat"));   // True
//Console.WriteLine(t.Search("ca"));    // False (prefix only)
//Console.WriteLine(t.StartsWith("ca"));// True

//foreach (var w in t.WordsWithPrefix("ca"))
//    Console.WriteLine(w);             // car, care, cat (order may vary)

//// Autocomplete example

//var trie = new Trie();
//trie.Insert("cat");
//trie.Insert("car");
//trie.Insert("care");
//trie.Insert("dog");

//var res = trie.Autocomplete("do", 2);
//Console.WriteLine(string.Join(", ", res)); // dog

//var result = Nov192125.LengthOfLongestSubstring("abcabcbb");

//var result = TwoPointers.RemoveDuplicates([0, 0, 0, 1, 1, 1, 2, 2]);
//Console.WriteLine(result);

//var result = TwoPointers.MiddleOfLinkedList(new List<int>() { 1, 2, 3, 4});
//Console.WriteLine(result);

//Nov2725.InitNodeAndStartSolution();

//var result = DeletionDistance.FindDeletionDistance("dog", "frog");

//var result = SlidingWindow.CharacterReplacement("XXYYYXX", 2);
//var result = BinarySearch.SearchInsert([1, 3, 5, 6, 7, 8], 2);

//var res = Backtracking_Subsets.GenerateSubsets([1, 2, 3, 4, 5, 6]);

//var priorityQueueQ = new PriorityQueue_Questions();
//var res = priorityQueueQ.MinMeetingRooms(new int[][] { [1,10], [2,7], [3,19], [8, 12], [10, 20], [11,30] });

//var topoSort = new TopoSort();
//var res = topoSort.FindOrder(4, [[1, 0], [2, 0], [3, 1], [3, 2]]);

//var res = Array_HastSet.ContainsNearbyDuplicate([1, 2, 3, 1], 3);

//var res = Backtracing_Pruning.GenerateParenthesis(3);

//var res = SlidingWindow.LengthOfLongestSubstringTwoDistinct("abcabcabc");

//var res = SlidingWindow.MaximumUniqueSubarray([5, 2, 1, 2, 5, 2, 1, 2, 5]);

//var res = SameDirection.LongestNiceSubarray([1, 3, 8, 48, 10]);

//var res = BinarySearchGreedily.ShipWithinDays([1, 2, 3, 4, 5, 6, 7, 8, 9, 10], 5);

//var res = Backtracking_Subsets.SubsetsWithDup([1, 2, 2]);

var res = Bfs.CanVisitAllRooms(new List<List<int>>() 
{
    new List<int>() {1 ,3 }, new List<int>() {3, 0, 1 }, new List<int>() {2 }, new List<int>() {0 }
});

Console.WriteLine("Challenge accomplished. You rock!");