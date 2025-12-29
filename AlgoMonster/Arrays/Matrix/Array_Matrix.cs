using System.Data;

namespace AlgoMonster.Arrays.Matrix
{
    public static class Array_Matrix
    {
        /// <summary>
        /// Lucky number in a matrix
        /// https://leetcode.com/problems/lucky-numbers-in-a-matrix/description
        /// </summary>
        public static IList<int> LuckyNumbers(int[][] matrix)
        {
            // 0  1  2  indx
            // 3  7  8   0
            // 9  11 13  1
            // 15 16 17  2

            // 3, 9 15
            // 15 16 17

            var res = new List<int>();
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            var rowMin = new int[rows];
            var colMax = new int[cols];

            for (int r = 0; r < rows; r++)
            {
                // 00 01 02
                for (int c = 0; c < cols; c++)
                {
                    rowMin[r] = Math.Min(matrix[r][c], rowMin[r]);
                    colMax[c] = Math.Max(matrix[r][c], colMax[c]);
                }
            }

            for (int r = 0; r < rows; r++)
            {
                // 00 01 02
                for (int c = 0; c < cols; c++)
                {
                    if (matrix[r][c] == rowMin[r] && matrix[r][c] == colMax[c])
                        res.Add(matrix[r][c]);
                }
            }

            return res;
        }

        /// <summary>
        /// Spiral Matrix
        /// https://leetcode.com/problems/spiral-matrix/description
        /// </summary>
        public static IList<int> SpiralOrder(int[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;

            var res = new List<int>();

            // prevR = 0 prevC = 0
            // rs = 0, re = 0, cs = 0, ce = cols-1  (east)
            // rs = 1, re = rows-1, cs = 1 , ce = 1 (south)
            // rs = rows-1, re = rows.-1, cs = cols-2, ce = 0 (west)
            // rs = rows -2, re = rows-2, cs= 0, ce = cols-2 (north)

            return res;
        }
       
    }
}
