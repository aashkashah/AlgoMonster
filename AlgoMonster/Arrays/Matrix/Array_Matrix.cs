using System.Data;
using AlgoMonster.Heap;

namespace AlgoMonster.Arrays.Matrix
{
    /// <summary> 
    /// 1380. Lucky Numbers in a Matrix https://leetcode.com/problems/lucky-numbers-in-a-matrix
    /// 54. Spiral Matrix https://leetcode.com/problems/spiral-matrix
    /// </summary>
    public static class Array_Matrix
    {

        /// <summary>
        /// https://leetcode.com/problems/flood-fill/
        /// </summary>
        /// <returns></returns>
        public static int[][] FloodFill(int[][] image, int sr, int sc, int color) 
        {
            /*
                bfs + queue -> 4 direction
                add every elem 4 dir (update if matches original color)
                
                O(n) time
                O(n) space
            */

            var rows = image.Length;
            var cols = image[0].Length;

            var queue = new Queue<(int, int)>();
            queue.Enqueue((sr, sc));

            var dirR = new int[] { -1, 1, 0, 0};
            var dirC = new int[] { 0, 0, -1, 1};

            var visited = new bool[rows, cols];
            var startingColor = image[sr][sc];

            while(queue.Count > 0)
            {
                var levelCount = queue.Count;

                for(int i = 0; i < levelCount; i++)
                {
                    var (r, c) = queue.Dequeue();
                    visited[r, c] = true;
                    image[r][c] = color;

                    // 4 directions
                    for(int k = 0; k < 4; k++)
                    {
                        var kr = dirR[k] + r;
                        var kc = dirC[k] + c;

                        if(kr < 0 || kc < 0 || kr >= rows || kc >= cols)
                            continue;

                        if(visited[kr, kc])
                            continue;

                        if(image[kr][kc] != startingColor)
                            continue;
                        
                        image[kr][kc] = color;
                        queue.Enqueue((kr, kc));
                    }
                }
            }

            return image;

        }
        /// <summary>
        /// 1380. Lucky Numbers in a Matrix
        /// https://leetcode.com/problems/lucky-numbers-in-a-matrix
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
        /// 54. Spiral Matrix
        /// https://leetcode.com/problems/spiral-matrix
        /// </summary>
        public static IList<int> SpiralOrder(int[][] matrix)
        {
            // your code goes here
            // row = 3, col = 4
            // for 
            // for
            // direction -- go right -> down -> left -> up
            // (0,0) -> (0,4)
            // (3,4) -> (3,0)
            // (2,0) -> (1,0)

            int row = matrix.Length;
            int col = matrix[0].Length;

            var result = new List<int>();

            int r = 0, c = 0;

            int colRightEdge = col; // exclusive
            int colLeftEdge = -1;   // exclusive

            int rowTopEdge = 0;   // exclusive
            int rowBottomEdge = row; // exclusive

            while (result.Count < row * col)
            {
                // go right
                colRightEdge--;
                while (c <= colRightEdge && result.Count < row* col)
                {
                    result.Add(matrix[r][c]);
                    c++;
                }

                // go down 
                r++;
                c--;
                rowBottomEdge--;
                while (r <= rowBottomEdge && result.Count < row * col)
                {
                    result.Add(matrix[r][c]);
                    r++;
                }

                // go left
                c--;
                r--;
                colLeftEdge++;
                while (c >= colLeftEdge && result.Count < row * col)
                {
                    result.Add(matrix[r][c]);
                    c--;
                }

                // go up
                r--;
                c++;
                rowTopEdge++;
                while (r >= rowTopEdge && result.Count < row * col)
                {
                    result.Add(matrix[r][c]);
                    r--;
                }
                r++;  // move to the next inner top row
                c++;  // move to the next inner left col 
            }

            return result;
        }

        /// <summary>
        /// Spiral Matrix
        /// https://leetcode.com/problems/spiral-matrix
        /// </summary>
        public static IList<int> SpiralOrderCleanerVersion(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
                return new List<int>();

            int rows = matrix.Length;
            int cols = matrix[0].Length;

            var result = new List<int>(rows * cols);

            int top = 0, bottom = rows - 1;
            int left = 0, right = cols - 1;

            while (top <= bottom && left <= right)
            {
                // go right
                for (int c = left; c <= right; c++)
                    result.Add(matrix[top][c]);
                top++;

                // go down
                for (int r = top; r <= bottom; r++)
                    result.Add(matrix[r][right]);
                right--;

                // go left (only if we still have a row)
                if (top <= bottom)
                {
                    for (int c = right; c >= left; c--)
                        result.Add(matrix[bottom][c]);
                    bottom--;
                }

                // go up (only if we still have a col)
                if (left <= right)
                {
                    for (int r = bottom; r >= top; r--)
                        result.Add(matrix[r][left]);
                    left++;
                }
            }

            return result;
        }

    }
}
