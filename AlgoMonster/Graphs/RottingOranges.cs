namespace AlgoMonster.Grid
{

    /// <summary>
    /// Rotting Oranges — Multi-Source BFS
    // Goal
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
        /*
            add all fresh oranges to a hashset
            loop through the grid to visit all organges. add to queue
            for each traverse 4 directions, 
            if any has a fresh orange, rot them
        */

        public int OrangesRotting(int[][] grid)
        {
            if (grid == null || grid.Length == 0) return -1;

            int rows = grid.Length;
            int cols = grid[0].Length;

            var queue = new Queue<(int row, int col)>();
            var freshOranges = new HashSet<(int row, int col)>();

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

            var dirR = new int[] { -1, 1, 0, 0 };
            var dirC = new int[] { 0, 0, -1, 1 };

            // Step 2: Perform BFS
            while (queue.Count > 0)
            {
                int size = queue.Count;
                bool rottedThisMinute = false;

                for (int i = 0; i < size; i++)
                {
                    var (r, c) = queue.Dequeue();

                    for(int k = 0; k < 4; k++)
                    {
                        var kr = dirR[k] + r;
                        var kc = dirC[k] + c;

                        if(kr < 0 || kc < 0 || kr >= rows || kc >= cols)
                            continue;
                        if(grid[kr][kc] != 1) continue;

                        grid[kr][kc] = 2;
                        freshOranges.Remove((kr, kc));
                        queue.Enqueue((kr, kc));
                        rottedThisMinute = true;
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
