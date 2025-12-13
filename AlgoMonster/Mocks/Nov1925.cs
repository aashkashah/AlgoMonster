using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.Mocks
{
    public class Nov1925
    {
        // coin change
        // 1 , 2, 3, 10 -- 16
        // 10, 3, 3
        // 1, 2, 4, 7, 10 -- 

        /// <summary>
        /// Coin Change
        // You are given an integer array coins representing different coin denominations
        // and an integer amount representing a total amount of money.Write a function coinChange
        // that returns the fewest number of coins needed to make up that amount.
        // If that amount cannot be made up by any combination of the coins, return -1.
        //You may assume that you have an infinite number of each kind of coin.
        /// </summary>
        //    public int CoinChange(int[] coins,  int amount)
        //    {

        //        int[] dp = new int[amount + 1];

        //        for(int i = 1; i < amount; i++)
        //        {
        //            foreach(int coin in coins)
        //            {
        //                if(i - coin >= 0 && dp[i - coin] != )
        //            }
        //        }

        //        return -1;
        //    }
        //}
    }
}


    #region mysolution
    //    int[] coins = [1, 2, 5];
    //    int amount = 11;
    //    public static void Main()
    //    {
    //        var result = CoinChange(coins, 11);
    //    }

    //    public static int CoinChange(int[] coins, int amount)
    //    {
    //        return RecurseCoins(amount, 0);
    //    }

    //    public static int RecurseCoins(int remaining, int count)
    //    {
    //        if (remaining < 0)
    //        {
    //            return -1;
    //        }
    //        if (remaining == 0)
    //        {
    //            return count;
    //        }

    //        // try to find numer in array that is slightly less than remaining
    //        for (int i = coins.length() - 1; i >= 0; i--) // modify
    //        {
    //            if (coins[i] > remaining) continue;
    //            // recurse and calculate remaining
    //            remaining = remaining - coins[i];
    //            RecurseCoins(coins, amount, remaining, count++);
    //        }

    //    }
    //}
    #endregion 

    
