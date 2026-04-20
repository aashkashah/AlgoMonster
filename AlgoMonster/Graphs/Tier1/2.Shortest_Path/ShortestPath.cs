namespace AlgoMonster.Graphs.Tier1._2.Shortest_Path
{
    public class ShortestPath
    {
        /// <summary>
        /// Nearest Exit from Entrance in Maze
        /// https://leetcode.com/problems/nearest-exit-from-entrance-in-maze/
        /// </summary>

        public int NearestExit(char[][] maze, int[] entrance)
        {

            int m = maze.Length, n = maze[0].Length;
            int sr = entrance[0], sc = entrance[1];

            var q = new Queue<(int r, int c)>();
            var visited = new bool[m, n];

            q.Enqueue((sr, sc));
            visited[sr, sc] = true;

            int steps = 0;
            int[] dr = { -1, 1, 0, 0 };
            int[] dc = { 0, 0, -1, 1 };

            while(q.Count > 0)
            {
                int size = q.Count;

                for(int i = 0; i < size; i++)
                {
                    var (r, c) = q.Dequeue();

                    for(int k = 0; k < 4; k++)
                    {
                        int nr = r + dr[k];
                        int nc = c + dc[k];

                        if (nr < 0 || nr >= m || nc < 0 || nc >= n) continue;
                        if (visited[nr, nc]) continue;
                        if (maze[nr][nc] != '.') continue;

                        // if it's on the boundary and not an enterance
                        // found exit
                        if((nr ==0 || nc == 0 || nr == m -1 || nc == n -1) &&
                            !(nr == sr && nc == sc))
                        {
                            return steps + 1;
                        }

                        visited[nr, nc] = true;
                        q.Enqueue((nr, nc));

                    }
                }
                steps++;
            }

            return -1;

        }

        /// <summary>
        /// 1091. Shortest Path in Binary Matrix
        /// https://leetcode.com/problems/shortest-path-in-binary-matrix/description/
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int ShortestPathBinaryMatrix(int[][] grid)
        {

            // constraints
            // 0/1 binary.. (0,0) -> (n-1, n-1)
            // plan
            // bfs starting (0,0) add 0 nbrs, 
            // visited (inpace)
            // 
            // examples
            // code
            // test

            var row = grid.Length;
            var col = grid[0].Length;
            if (grid[0][0] == 1 || grid[row - 1][col - 1] == 1) return -1;
            if (row == 1 && col == 1) return 1;

            var q = new Queue<(int, int)>();
            q.Enqueue((0, 0));
            // missed marking start as visisted
            grid[0][0] = -1;
            // didn't start steps at 1
            var steps = 1;

            int[] dr = { -1, 1, 0, 0, -1, -1, 1, 1 };
            int[] dc = { 0, 0, -1, 1, -1, 1, -1, 1 };

            while (q.Count > 0)
            {
                var lvl = q.Count;

                for (int i = 0; i < lvl; i++)
                {
                    var (r, c) = q.Dequeue();

                    for (int k = 0; k < 8; k++)
                    {
                        int nr = r + dr[k];
                        int nc = c + dc[k];

                        if (nr < 0 || nc < 0 || nr >= row || nc >= col) continue;
                        if (grid[nr][nc] == -1 || grid[nr][nc] == 1) continue;

                        // didn't return a +1 here
                        if (nr == row - 1 && nc == col - 1 && grid[nr][nc] == 0) return steps + 1;

                        grid[nr][nc] = -1;
                        q.Enqueue((nr, nc));
                    }
                }
                steps++;
            }

            return -1;
        }
    }
}
