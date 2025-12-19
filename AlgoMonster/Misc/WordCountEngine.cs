using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.Misc
{
    /// <summary>
    /// Implement a document scanning function wordCountEngine, 
    /// which receives a string document and returns a list of all 
    /// unique words in it and their number of occurrences, sorted by the number of occurrences in a descending order. 
    /// If two or more words have the same count, they should be sorted according to their order in the original sentence. 
    /// Assume that all letters are in english alphabet. You function should be case-insensitive, 
    /// so for instance, the words “Perfect” and “perfect” should be considered the same word.
    /// The engine should strip out punctuation(even in the middle of a word) and use whitespaces to separate words.
    /// Analyze the time and space complexities of your solution. 
    /// Try to optimize for time while keeping a polynomial space complexity.
    /// </summary>
    public static class WordCountEngine
    {
        public static List<(string, int)> FindWordCountEngine(string document)
        {
            var dict = new Dictionary<string, (int, int)>();
            var splitWords = document.Split(' ');

            // clean words
            int index = 0;
            foreach (var word in splitWords)
            {
                var strBuilder = new StringBuilder();
                foreach (var ch in word)
                {
                    if (char.IsLetter(word[ch]))
                    {
                        strBuilder.Append(word[ch]);
                    }
                }
                splitWords[index] = strBuilder.ToString();
                index++;
            }

            // loop and count words
            index = 0;
            foreach(var word in splitWords)
            {
                if(!dict.ContainsKey(word))
                {
                    dict.Add(word, (0, index));
                }
                else
                {
                    dict[word] = (dict[word].Item1 + 1, dict[word].Item2);
                }
            }

            List<(string, int)> res = dict.OrderByDescending(x => x.Value.Item1)
                 .ThenByDescending(y => y.Value.Item2)
                 .Select(x => (x.Key, x.Value.Item1))
                 .ToList();

            return res;

        }
    }
}
