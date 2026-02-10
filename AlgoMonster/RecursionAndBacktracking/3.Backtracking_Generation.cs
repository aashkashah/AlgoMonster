using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace AlgoMonster.RecursionAndBacktracking
{
    /// <summary>
    /// Fixed depth generation
    /// 
    /// “Generate all sequences of length N”
    /// 
    /// level = position
    /// branching = choices per position
    /// 
    /// Mental trigger 
    ///     "Depth = output length"
    /// </summary>
    public static class Backtracking_Generation
    {
        private static List<string> _combinations = new List<string>();

        private static Dictionary<char, string> _letters = new Dictionary<char, string>()
            {
                { '2', "abc" }, { '3', "def" },  { '4', "ghi" }, { '5', "jkl" },
                { '6', "mno" }, { '7', "pqrs" }, { '8', "tuv" }, { '9', "wxyz" }
            };

        /// <summary>
        /// Phone Letter Combinations
        /// https://leetcode.com/problems/letter-combinations-of-a-phone-number
        /// </summary>
        public static IList<string> LetterCombinations(string digits)
        {
            if(digits.Length == 0) return _combinations;
            LetterCombinationsHelper(0, new StringBuilder(), digits);
            return _combinations.ToList();
        }

        private static void LetterCombinationsHelper(int index, StringBuilder curr, string digits)
        {
            if(curr.Length == digits.Length)
            {
                _combinations.Add(curr.ToString());
                return;
            }

            // backtrack
            var possibleLetters = _letters[digits[index]];
            foreach(char ch in possibleLetters)
            {
                // choose
                curr.Append(ch);

                // explore
                LetterCombinationsHelper(index+1, curr, digits);

                // undo
                curr.Remove(curr.Length - 1, 1);
            }

        }

        /// <summary>
        /// Find all possible dice roll combinations
        /// 
        /// “Each level represents a die. From each node, I branch into 6 choices. 
        /// I DFS until I place all dice, then record the path.”
        /// </summary>
        public static void DiceRoll(int num)
        {
            DiceRollHelper(2, new List<string>());
        }

        private static void DiceRollHelper(int dice, List<string> selection)
        {
            if(dice == 0)
            {
                Console.WriteLine(string.Join("", selection));
                return;
            }

            // recursion
            // how many options/possibilities at each level? == 6 (6 face of per die)
            for(int i = 1; i <= 6; i++) 
            {
                // choose a die
                selection.Add(dice.ToString());

                // explore
                DiceRollHelper(dice - 1, selection);

                // undo 'backtrack'
                selection.RemoveAt(selection.Count - 1);
            }

        }

    }
}
