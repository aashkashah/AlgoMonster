namespace AlgoMonster.Grid
{
    public class NumOfIslands
    {
        public class Coordinate
        {
            public int r;
            public int c;

            public Coordinate(int r, int c)
            {
                this.r = r;
                this.c = c;
            }
        }
        /// <summary>
        /// Find the Number of Islands

        /// </summary>
        /// <returns></returns>
        public int FindNumOfIslands(int[][] grid)
        {

            // visited grid
            // fllood fill, bfs
            // queue.
            // loop the grid
            
            //  breaking loop until reach end of grid
            //  curr elem to queue if unvisited and == 1, pop, add unvisited neigbors to queue only if == 1
            //      start another loop until this queue is empty
            // increment island count 
            
            var rowLen = grid.Length;
            var colLen = grid[0].Length;
            var visited = new int[rowLen, colLen];
            var queue = new Queue<Coordinate>();
            var islands = 0;

            for(int i = 0; i < rowLen; i++)
            {
                for (int j = 0; j < colLen; j++)
                {
                    if(grid[i][j] == 1 && visited[i, j] == 0)
                    {
                        islands++;
                        queue.Enqueue(new Coordinate(i, j));
                        visited[i, j] = 1;

                        while (queue.Count > 0)
                        {
                            var cor = queue.Dequeue();
                            var r = cor.r;
                            var c = cor.c;
                            
                            // add neighbors - top bottom left right
                            // top
                            if (r - 1 >= 0 && grid[r - 1][c] == 1) // check out of bounds
                            {
                                queue.Enqueue(new Coordinate(r - 1, c));
                                visited[r - 1, c] = 1;
                            }

                            // bottom
                            if (r + 1 < rowLen && grid[r + 1][c] == 1)
                            {
                                queue.Enqueue(new Coordinate(r + 1, c));
                                visited[r + 1, c] = 1;
                            }

                            // left
                            if (c - 1 >= 0 && grid[r][c - 1] == 1)
                            {
                                queue.Enqueue(new Coordinate(r, c - 1));
                                visited[r, c - 1] = 1;
                            }

                            // right
                            if (c + 1 < colLen && grid[r][c + 1] == 1)
                            {
                                queue.Enqueue(new Coordinate(r, c + 1));
                                visited[r, c + 1] = 1;
                            }
                        }
                    }
                }
            }

            return islands;
        }
    }
}
