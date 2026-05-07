namespace AlgoMonster.Grid
{
    public class NumOfIslands
    {   public int FindNumOfIslands(int[][] grid)
        {
            // fllood fill
            // visited bfs (queue layers) + visited
            
            var rowLen = grid.Length;
            var colLen = grid[0].Length;

            var visited = new int[rowLen, colLen];
            var queue = new Queue<(int, int)>();
            var islands = 0;

            var dirR = new int[] { -1, 1, 0, 0 };
            var dirC = new int[] { 0, 0, -1, 1 };

            for(int i = 0; i < rowLen; i++)
            {
                for (int j = 0; j < colLen; j++)
                {
                    if(grid[i][j] == 1 && visited[i, j] == 0)
                    {
                        islands++;
                        queue.Enqueue((i, j));
                        visited[i, j] = 1;

                        while (queue.Count > 0)
                        {
                            var (r, c) = queue.Dequeue();

                            for(int k = 0; k < 4; k++)
                            {
                                var kr = dirR[k] + r;
                                var kc = dirC[k] + c;

                                if(kr < 0 || kc < 0 || kr >= rowLen || kc >= colLen)
                                    continue;

                                if(visited[kr, kc] == 1) continue;

                                queue.Enqueue((kr, kc));
                                visited[kr, kc] = 1;
                            }
                        }
                    }
                }
            }

            return islands;
        }
    }
}
