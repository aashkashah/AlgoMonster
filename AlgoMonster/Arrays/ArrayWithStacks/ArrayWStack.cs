using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.Arrays.ArrayWithStacks
{
    public class ArrayWStack
    {
        /// <summary>
        /// Make The String Great
        /// https://leetcode.com/problems/make-the-string-great/?envType=problem-list-v2&envId=stack
        /// Input: s = "leEeetcode"
        /// Output: "leetcode"
        /// Explanation: In the first step, either you choose i = 1 or i = 2, both will result "leEeetcode" to be reduced to "leetcode"
        /// </summary>
        public string MakeGood(string s)
        {
            // leEeetCode
            //      ^
            // leetCode

            var stack = new Stack<char>();
            foreach (char c in s)
            {
                // this can also be used 
                // Math.Abs(stack.Peek() - c) == 32
                // 'a' (97) and 'A' (65) → difference = 32
                // so just 
                // if (stack.Count > 0 && Math.Abs(stack.Peek() - c) == 32)
                var topChar = stack.Peek(); // missing stack.Count check
                if (char.ToLower(topChar) == char.ToLower(c) &&
                    (char.IsUpper(c) && char.IsLower(topChar) ||
                    char.IsLower(c) && char.IsUpper(topChar)))
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(c);
                }
            }


            return new string(stack.Reverse().ToArray()); // thing i didn't know
        }

        /// <summary>
        /// Decode String
        /// https://leetcode.com/problems/decode-string/description/
        /// Input: s = "3[a2[c]]"
        /// Output: "accaccacc"
        /// Input: s = "2[abc]3[cd]ef"
        /// Output: "abcabccdcdcdef"
        /// </summary>
        public string DecodeString(string s)
        {
            // todo - needs fix
            // 3 stacks not required, bracket stack is implied 
            // missing multiple digit implementation
            // look for correct solution in DecodeStringCorrected()

            // 3[a2[c]]
            //       ^
            // stack 1: 3 
            // stack 2: acc
            // stack 3: [ ] 

            // keep looking for end of char until ] or a number
            // 2[abc]3[cd]ef
            //             ^
            // stack 1: 
            // stack 2: abcabccdcdcd ef
            // stack 3:  

            var stack1 = new Stack<int>();
            var stack2 = new Stack<string>();
            var stack3 = new Stack<char>();

            var ptr = 0;
            while (ptr < s.Length)
            {
                var currChar = s[ptr];
                // bracket check
                if (currChar == '[')
                {
                    stack3.Push(currChar);
                }
                else if (currChar == ']')
                {
                    // do 
                    if(stack1.Count > 0 && stack2.Count > 0)
                    {
                        var num = stack1.Pop();
                        var chars = stack2.Pop();

                        var strBldr = new StringBuilder();
                        for(int i = 0; i < num; i++)
                        {
                            strBldr.Append(chars);
                        }
                        stack2.Push(strBldr.ToString());   

                        stack3.Pop();
                    }
                    
                }
                else if (char.IsDigit(currChar))
                {
                    // error -- number can be multiple digit
                    // add to numbers stack
                    stack1.Push(currChar);
                }
                else if(char.IsLetter(currChar))
                {
                    var strbuilder = new StringBuilder();
                    while (ptr < s.Length && s[ptr] != ']' && char.IsDigit(s[ptr]))
                    {   
                        strbuilder.Append(s[ptr]);
                        ptr++;
                    }
                    stack2.Push(strbuilder.ToString());
                }
                ptr++;
            }
            var res = string.Empty;
            while(stack2.Count > 0)
            {
                res = stack2.Pop() + res;
            }

            return res;
        }

        public string DecodeStringCorrected(string s)
        {
            var countStack = new Stack<int>();
            var stringStack = new Stack<StringBuilder>();

            var current = new StringBuilder();
            int k = 0;

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (char.IsDigit(c))
                {
                    // build multi-digit number
                    // c - '0' just converts char to int
                    k = k * 10 + (c - '0');
                }
                else if (c == '[')
                {
                    // start a new nested frame
                    countStack.Push(k);
                    stringStack.Push(current);

                    current = new StringBuilder();
                    k = 0;
                }
                else if (c == ']')
                {
                    int repeat = countStack.Pop();
                    var prev = stringStack.Pop();

                    for (int r = 0; r < repeat; r++)
                        prev.Append(current);

                    current = prev;
                }
                else // letter
                {
                    current.Append(c);
                }
            }

            return current.ToString();
        }

        /// <summary>
        /// Baseball game
        /// https://leetcode.com/problems/baseball-game/description
        /// </summary>
        public int CalPoints(string[] operations)
        {
            var stack = new Stack<int>();

            for(int i = 0; i < operations.Length; i++)
            {
                var currOperation = operations[i];
                if (currOperation == "+")
                {
                    var top = stack.Pop();
                    var newTop = top + stack.Peek();
                    stack.Push(top);
                    stack.Push(newTop);
                }
                else if (currOperation == "D")
                {
                    stack.Push(2 * stack.Peek());    
                }
                else if (currOperation == "C")
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(Convert.ToInt32(currOperation));
                }
            }

            int ans = 0;
            while (stack.Count > 0)
            {
                ans += stack.Pop();
            }
            return ans;
        }

        /// <summary>
        /// Crwaler Log Folder
        /// https://leetcode.com/problems/crawler-log-folder/
        /// Input: logs = ["d1/","d2/","../","d21/","./"]
        /// Output: 2
        /// </summary>
        public int MinOperations(string[] logs)
        {
            if (logs.Count() == 0) return 0;

            var stack = new Stack<string>();

            for (int i = 0; i < logs.Length; i++)
            {
                var currOperation = logs[i];

                if(currOperation == "../")
                {
                    if (stack.Count > 0) stack.Pop();
                }
                else if (currOperation == "./")
                {
                    continue;
                }
                else
                {
                    // x/ operation -- go onto child folder
                    stack.Push(currOperation);
                }

            }

            return stack.Count;
        }


    }
}

