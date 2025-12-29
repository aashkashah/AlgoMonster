Detailed: https://www.notion.so/Backtracking-2d19497b780980858b29df288488e9ad

🔑 The Unifying Backtracking Skeleton

Everything above reduces to one skeleton:

void Backtrack(state)
{
    if (base_case)
    {
        record answer
        return;
    }

    for (each choice)
    {
        choose
        if (valid)
            Backtrack(new_state)
        unchoose
    }
}


If you memorize this, you can code 80% of recursion problems on the fly.


🧩 How this maps to DP & Trees (important insight)
    Domain	        Core question
    Trees	        “Where do I recurse? (left/right)”
    DP	            “Can I reuse results?”
    Recursion	    “How does the problem shrink?”
    Backtracking	“What choices exist at each step?”

Many problems start as backtracking and later become DP (e.g., subset sum).


🧠 Pattern recognition cheat-sheet

Ask yourself these 5 questions:

    Is the depth fixed? → generation

    Does order matter? → permutation

    Is it include/exclude? → subset

    Are there rules? → pruning

    Is there a grid/tree? → DFS backtracking

If you answer these, the code structure writes itself.


Include/exclude pattern

| Step                   | Meaning                 |
| ---------------------- | ----------------------- |
| `subset.Add(...)`      | choose INCLUDE          |
| recurse                | explore that choice     |
| `subset.RemoveAt(...)` | undo choice             |
| recurse again          | explore path WITHOUT it |
