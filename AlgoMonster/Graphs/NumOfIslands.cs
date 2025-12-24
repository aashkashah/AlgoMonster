using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.Grid
{
    public class NumOfIslands
    {
        public class Coordinate
        {
            int r;
            int c;

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

            for(int i = 0; i < rowLen; i++)
            {
                for (int j = 0; j < colLen; j++)
                {
                    if(grid[i][j] == 1 && visited[i, j] == 0)
                    {
                        // pop curr elem
                        var curr = grid[i][j];
                        
                        queue.Enqueue(new Coordinate(i, j));
                        visited[i, j] = 1;

                        // add neighbors - top bottom left right
                        if (grid[i - 1][j] == 1) // check out of bounds
                        {
                            queue.Enqueue(new Coordinate(i - 1, j));
                        }


                    }
                }
            }

            return -1;
        }
    }
}
