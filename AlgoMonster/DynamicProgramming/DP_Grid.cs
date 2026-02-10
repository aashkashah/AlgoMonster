using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.DynamicProgramming
{
    /// <summary>
    /// 221. Maximal Square https://leetcode.com/problems/maximal-square
    /// </summary>
    public class DP_Grid
    {
        /// <summary>
        /// maximal Square
        /// https://leetcode.com/problems/maximal-square
        /// </summary>
        public int MaximalSquare(char[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;

            int maxsqlen = 0;
            var dp = new int[rows + 1, cols + 1];

            for(int i = 1; i <= rows; i++)
            {
                for(int j = 1; j <= cols; j++)
                {
                    if (matrix[i-1][j-1] == '1')
                    {
                        dp[i,j] = Math.Min(Math.Min(dp[i, j-1], dp[i-1,j]), dp[i-1, j-1]) + 1;
                        maxsqlen = Math.Max(maxsqlen, dp[i, j]);
                    }
                }
            }
            return maxsqlen * maxsqlen;
        }

        /// <summary>
        /// Unique Paths II
        /// https://leetcode.com/problems/unique-paths-ii/
        /// </summary>
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            // we will be re-using the exisiting grid
            int rows = obstacleGrid.Length;
            int cols = obstacleGrid[0].Length;

            // if starting cell has an obstacle, there's no path avail. to the destination
            if (obstacleGrid[0][0] == 1)
            {
                return 0;
            }

            // number of ways of reaching starting cell
            obstacleGrid[0][0] = 1;

            // filling values for first column
            for (int i =1; i <rows; i++)
            {
                obstacleGrid[i][0] = (obstacleGrid[i][0] == 0 && obstacleGrid[i - 1][0] == 1) ? 1 : 0;
            }

            // filling values for first row
            for(int i =0; i <cols; i++)
            {
                obstacleGrid[0][i] = (obstacleGrid[0][i] == 0 && obstacleGrid[0][i - 1] == 1) ? 1 : 0;
            }

            // starting from cell (1,1)
            // no of ways of reaching cell[i][j] = cell[i-1][j] + cell[i][j-1]
            // from above ane left
            for (int i =1; i < rows; i++)
            {
                for(int j=0; j < cols; j++)
                {
                    if (obstacleGrid[i][j] == 0)
                    {
                        obstacleGrid[i][j] = obstacleGrid[i - 1][j] + obstacleGrid[i][j - 1];
                    }
                    else
                    {
                        // obstacle was encountered 
                        obstacleGrid[i][j] = 0;
                    }
                }
            }

            // return value stored in bottom most cell == destination
            return obstacleGrid[rows - 1][cols - 1];
        }


    }
}
