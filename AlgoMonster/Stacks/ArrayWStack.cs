using System.Text;

namespace AlgoMonster.Arrays.ArrayWithStacks
{
    public static class ArrayWStack
    {
        /// <summary>
        /// Make The String Great
        /// https://leetcode.com/problems/make-the-string-great
        /// Input: s = "leEeetcode"
        /// Output: "leetcode"
        /// </summary>
        public static string MakeGood(string s)
        {

            var stack = new Stack<char>();
            foreach (char c in s)
            {  
                var topChar = stack.Peek(); // missing stack.Count check
                if (stack.Count > 0 && Math.Abs(c - stack.Peek()) == 32)
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
        /// https://leetcode.com/problems/decode-string
        /// Input: s = "3[a2[c]]"
        /// Output: "accaccacc"
        /// Input: s = "2[abc]3[cd]ef"
        /// Output: "abcabccdcdcdef"
        /// </summary>

        public static string DecodeString(string s)
        {
            // 2[abc]3[cd]ef
           var stringStack = new Stack<string>();
           var numberStack = new Stack<int>();

           var currentString = string.Empty;
           var currentNumber = 0;

           foreach(char c in s)
            {
                if(c == '[')
                {
                    // reset for next 
                    stringStack.Push(currentString);
                    numberStack.Push(currentNumber);
                    currentNumber = 0;
                    currentString = "";
                }
                else if(c == ']')
                {
                    int num = numberStack.Pop();
                    var pervString = stringStack.Pop();

                    var repeated = new StringBuilder();

                    for(int i = 0; i < num; i++)
                    {
                        repeated.Append(currentString);
                    }

                    currentString = pervString + repeated;
                    
                }
                else if(char.IsDigit(c))
                {
                    currentNumber += currentNumber * 10 + ( c- '0');
                }
                else
                {
                    // string
                    currentString += c;
                }
            }

            return currentString;
        }

        /// <summary>
        /// 682. Baseball Game https://leetcode.com/problems/baseball-game
        /// </summary>
        public static int CalPoints(string[] operations)
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
        /// Crawler Log Folder
        /// https://leetcode.com/problems/crawler-log-folder/
        /// Input: logs = ["d1/","d2/","../","d21/","./"]
        /// Output: 2
        /// </summary>
        public static int MinOperations(string[] logs)
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

        public static string MinRemoveToMakeValid(string s)
        {
            // lee(t(c)o)de)
            //             ^ 
            // 
            // stack: ),12
            // 
            //    
            // a)b(c)d
            //      ^
            // stack: (,3 
            // res: ab(c)d
            // remove a closing brace if no open brace present

            var stack = new Stack<(char, int)>();
            var map = new HashSet<int>();

            for (int i = 0; i < s.Length; i++)
            {
                var cur = s[i];
                if (cur != '(' && cur != ')') continue;

                if (cur == '(')
                    stack.Push(('(', i));

                if (cur == ')')
                {
                    if(stack.Count > 0)
                    {
                        var (pk, idx) = stack.Peek();
                        if (pk == '(')
                        {
                            stack.Pop();
                            continue;
                        }
                    }
                    stack.Push((')', i));
                    map.Add(i);
                }
            }

            while (stack.Count > 0)
            {
                var (pk, idx) = stack.Pop();
                if (!map.Contains(idx)) map.Add(idx);
            }

            var res = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (map.Contains(i))
                {
                    // remove 
                    continue;
                }
                else
                {
                    res.Append(s[i]);
                }
            }

            return res.ToString();
        }


    }
}

