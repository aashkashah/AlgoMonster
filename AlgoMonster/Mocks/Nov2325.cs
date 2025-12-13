using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AlgoMonster.Mocks
{
    public static class Nov2325
    {

        /// <summary>
        ///  Deletion Distance
        /// The deletion distance of two strings is the minimum number of characters you need to
        /// delete in the two strings in order to get the same string. For instance,
        /// the deletion distance between "heat" and "hit" is 3:
        /// By deleting 'e' and 'a' in "heat", and 'i' in "hit", we get the string "ht" in both cases.
        /// We cannot get the same string from both strings by deleting 2 letters or fewer.
        /// Given the strings str1 and str2, write an efficient function deletionDistance 
        /// that returns the deletion distance between them. Explain how your function works, 
        /// and analyze its time and space complexities.
        /// input:  str1 = "some", str2 = "some"
        /// output: 0
        /// input:  str1 = "dog", str2 = "frog"
        /// output: 3
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns> 
        public static int DeletionDistance(string str1, string str2)
        {
            // dog, frog
            var deletion = 0;

            var firstPtr = 0;
            var scndPtr = 0;
            while (firstPtr < str1.Length && scndPtr < str2.Length)
            {
                if (str1[firstPtr] !=  str2[firstPtr])
                {
                    
                }
            }
            return -1;
        }
    }
}
