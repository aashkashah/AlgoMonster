using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.Arrays
{
    public static class ArrayMisc
    {
        /// <summary>
        /// Pascal's Triange
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public static IList<IList<int>> Generate(int numRows)
        {
            var result = new List<IList<int>>();

            // i = 0
            // dp[i] = dp[i] + dp[i+1]
            var dp = new List<List<int>>();
            var elem = new List<int>() { 1 };
            dp.Add(elem);
            dp.Add(new List<int> { 1, 1 });
            
            // f this
           

            return result;
        }
    }
}
