namespace AlgoMonster.Grid
{

    /// <summary>
    /// Rotting Oranges — Multi-Source BFS
    //Goal
    //In a grid, 0=empty, 1=fresh, 2=rotten.
    //Each minute, every fresh orange adjacent(up/down/left/right) to a rotten one becomes rotten.
    //Compute minutes until all fresh rot, or report -1 if impossible.
    //Rules
    //Start BFS with all rotten cells enqueued at minute 0.
    //Process level by level; one level = one minute.
    //Track how many fresh remain.
    
    // [2, 1, 1, 0]
    // [1, 1, 0, 1]
    // [0, 1, 1, 1]
    /// </summary>
    internal class RottingOranges
    {
        // add all fresh oranges to a hashset
        // loop through the grid to visit all organges and add one by one to a queue
        // for each orange in the queue, check all 4 directions

        // if any of the 4 directions has a fresh orange, rot it and add it to the queue

        // keep track of the minutes it takes to rot all oranges

        public int OrangesRotting(int[][] grid)
        {
            if (grid == null || grid.Length == 0) return -1;
            int rows = grid.Length;
            int cols = grid[0].Length;
            Queue<(int row, int col)> queue = new Queue<(int row, int col)>();
            HashSet<(int row, int col)> freshOranges = new HashSet<(int row, int col)>();
            // Step 1: Initialize the queue with all rotten oranges and track fresh oranges
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (grid[r][c] == 2)
                    {
                        queue.Enqueue((r, c));
                    }
                    else if (grid[r][c] == 1)
                    {
                        freshOranges.Add((r, c));
                    }
                }
            }
            // If there are no fresh oranges, return 0
            if (freshOranges.Count == 0) return 0;
            int minutes = 0;
            int[][] directions = new int[][]
            {
                new int[] { -1, 0 }, // up
                new int[] { 1, 0 },  // down
                new int[] { 0, -1 }, // left
                new int[] { 0, 1 }   // right
            };
            // Step 2: Perform BFS
            while (queue.Count > 0)
            {
                int size = queue.Count;
                bool rottedThisMinute = false;
                for (int i = 0; i < size; i++)
                {
                    var (row, col) = queue.Dequeue();
                    foreach (var dir in directions)
                    {
                        int newRow = row + dir[0];
                        int newCol = col + dir[1];
                        if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && grid[newRow][newCol] == 1)
                        {
                            // Rot the fresh orange
                            grid[newRow][newCol] = 2;
                            freshOranges.Remove((newRow, newCol));
                            queue.Enqueue((newRow, newCol));
                            rottedThisMinute = true;
                        }
                    }
                }
                if (rottedThisMinute)
                {
                    minutes++;
                }

                // If all fresh oranges are rotted, return the minutes
                if(freshOranges.Count == 0)
                {
                    return minutes;
                }
            }
            return -1; // Not all fresh oranges could rot
        }

    }
}
