using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.Search
{
    public static class BinarySearchGreedily
    {

        /// <summary>
        /// Capacity To Ship Packages Within D Days 
        /// https://leetcode.com/problems/capacity-to-ship-packages-within-d-days
        /// </summary>
        public static int ShipWithinDays(int[] weights, int days)
        {
            // 1,2,3,4,5,6,7,8,9,10

            int low = 0;
            int high = 0;

            // find low and high
            foreach (var w in weights)
            {
                low = Math.Max(low, w);  // at least the max single package
                high += w;               // at most the sum of all packages
            }

            while (low < high)
            {
                int mid = low + (high - low) / 2;

                if (CanShip(weights, days, mid))
                    high = mid;     // mid works, try smaller
                else
                    low = mid + 1; // mid too small, need bigger
            }

            return low;

        }

        private static bool CanShip(int[] weights, int days, int capacity)
        {
            int usedDays = 1;
            int load = 0;


            foreach (var w in weights)
            {
                if (load + w <= capacity)
                {
                    load += w;
                }
                else
                {
                    usedDays++;
                    load = w; // new day load

                    if (usedDays > days) return false;                }
            }

            return true;
        }
    }
}
