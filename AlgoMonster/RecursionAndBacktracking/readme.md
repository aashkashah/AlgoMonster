Detailed: https://www.notion.so/Backtracking-2d19497b780980858b29df288488e9ad

🔑 The Unifying Backtracking Skeleton
    If you memorize this, you can code 80% of recursion problems on the fly.

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


🧩 How this maps to DP & Trees (important insight)
    Domain	        Core question
    Trees	        “Where do I recurse? (left/right)”
    DP	            “Can I reuse results?”
    Recursion	    “How does the problem shrink?”
    Backtracking	“What choices exist at each step?”

Many problems start as backtracking and later become DP (e.g., subset sum).


🧠 Pattern recognition cheat-sheet

Ask yourself these 5 questions:

    Is the depth fixed (fixed length output)? → generation

    Does order matter? → permutation

    Is it include/exclude i.e yes/no per elemenet? → subset

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


🧠 General backtracking tree pattern (memorize this)
For any backtracking problem: (w example dice roll)

| Concept   | Dice rolls                     |
| --------- | ------------------------------ |
| Node      | Partial solution (`selection`) |
| Level     | Decision index (which die)     |
| Branch    | One choice (face value)        |
| Leaf      | Complete solution              |
| Backtrack | Undo last choice               |




🎯 The “Top 10” You Should Absolutely Know

If you only remember these, you’re covered:

    Generate Parentheses

    Subsets

    Permutations

    Combination Sum

    Phone Letter Combinations

    Word Search

    N-Queens

    Binary Tree DFS

    Number of Islands

    Dice / Binary String Generation
    

1️. Linear / Simple Recursion

One recursive call, problem size shrinks

    Very common

        Factorial

        Fibonacci (recursive → memoization discussion)

        Reverse a string

        Sum of digits / digital root

        Power(x, n)

2️. Binary Recursion (Tree-like)

Two recursive calls

    Extremely common

        Tree traversals (DFS)

        Maximum depth of binary tree

        Diameter of binary tree

        Path Sum

        Balanced binary tree

    Interview signal

        Tests:

        recursion on left/right

        combining results

👉 This overlaps heavily with tree patterns, which you already know.


3️. Fixed-Length Generation

Build strings / sequences of length N
    
    Shape: 
    level = position
    branching = choices per position

    Very common

        Generate binary strings

        Generate decimal strings

        Dice roll combinations

        Phone keypad combinations

    Mental trigger

        recursion depth = output length

        understanding branching factor

🧠 Once you solve one, all others are trivial.


4️. Permutations (Order Matters)

Reordering elements

    Extremely common

        Permutations of array

        Permutations of string

        Permutations with duplicates (follow-up)

    Interview signal

        Tests:

        choose / un-choose

        managing visited or remaining pool

💡 Often followed by:

“How do you handle duplicates?”


5️. Subsets / Include–Exclude

Yes / No per element

    Extremely common

        Subsets (power set)

        Subsets with duplicates

        Partition equal subset sum

        Combination vs permutation discussion

    Interview signal

        Tests:

        include / exclude thinking

        recursion tree size awareness

🧠 This pattern is the gateway to DP.


6️. Constraint-Based Backtracking (PRUNING)

Not all partial solutions are valid

🔥 Most important pattern 

    Must-know problems

        Generate Parentheses

        Combination Sum

        Combination Sum II

        N-Queens

        Sudoku Solver

        Word Search

    Interview signal

        Tests:

        pruning logic

        correctness over brute force

        “Can you stop early?”

💡 This is where interviewers see real algorithmic maturity.


7️. Grid / Graph Backtracking / Search / Path-finding

DFS + visited state

    Extremely common

        Word Search

        Number of Islands

        Flood Fill

        Maze paths

        Robot paths

    Interview signal

        Tests:

        marking/unmarking visited

        boundary checks

        recursion stack control

🧠 This is backtracking + graph traversal combined.