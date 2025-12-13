using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.DynamicProgramming
{
    /// <summary>
    /// Given two strings of uppercase letters source and target, list (in string form)
    /// a sequence of edits to convert from source to target that uses the least edits possible.
    /// 
    /// For example, with strings source = "ABCDEFG", and target = "ABDFFGH" 
    /// we might return: ["A", "B", "-C", "D", "-E", "F", "+F", "G", "+H"
    /// In the example, the answer of A B -C D -E F +F G +H has total number of 
    /// edits 4 (the minimum possible), and ignoring subtraction-tokens, 
    /// spells out A, B, D, F, +F, G, +H which represents the string target.

    /// If there are multiple answers, use the answer that favors removing from the source last.
    /// </summary>
    public static class DifferenceBetweenTwoStrings
    {
        public static List<char> DiffBetweenTwoString(string str1, string str2)
        {

            return null;
        }

    }
}
