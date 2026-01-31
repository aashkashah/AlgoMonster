using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
