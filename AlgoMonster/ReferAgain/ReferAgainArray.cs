using AlgoMonster.LinkedList;

namespace AlgoMonster.ReferAgain
{
    /// <summary>
    /// 680. Valid Palindrome II https://leetcode.com/problems/valid-palindrome-ii
    /// 560. Subarray Sum Equals K https://leetcode.com/problems/subarray-sum-equals-k
    /// 523. Continuous Subarray Sum https://leetcode.com/problems/continuous-subarray-sum
    /// 408. Valid Word Abbreviation https://leetcode.com/problems/valid-word-abbreviation
    /// 1891. Cutting Ribbons https://leetcode.com/problems/cutting-ribbons
    /// 
    /// 708. Insert into a Sorted Circular Linked List https://leetcode.com/problems/insert-into-a-sorted-circular-linked-list
    /// 227. Basic Calculator II https://leetcode.com/problems/basic-calculator-ii
    /// </summary>
    public static class ReferAgainArray
    {
        /// <summary>
        /// Asked at Meta 4/7/26
        /// 680. Valid Palindrome II
        /// https://leetcode.com/problems/valid-palindrome-ii
        /// </summary>
        public static bool ValidPalindrome(string s)
        {
            var l = 0;
            var r = s.Length - 1;

            while (l < r)
            {
                if (s[l] != s[r])
                {
                    // give once chance, but we don't know which direction is correct
                    return IsPalindrome(s, l + 1, r) || IsPalindrome(s, l, r - 1);
                }
                l++;
                r--;
            }

            return true;

            bool IsPalindrome(string str1, int l, int r)
            {
                while (l < r)
                {
                    if (s[l] != s[r]) return false;
                }
                l++; r--;

                return true;
            }
        }

        /// <summary>
        /// 560. Subarray Sum Equals K 
        /// https://leetcode.com/problems/subarray-sum-equals-k
        /// </summary>
        public static int SubarraySum(int[] nums, int k)
        {
            // prefix + dictionary

            var sum = 0;
            var count = 0;
            var freq = new Dictionary<int, int>();  

            for(int i =0; i < nums.Length; i++)
            {
                sum += nums[i];

                if (sum == k) count++;

                if (freq.TryGetValue((sum - k), out var c)) count += c;

                if (freq.TryGetValue(sum, out var cc)) freq[sum]++;
                else freq.Add(sum, 1);

            }

            return count;
        }

        /// <summary>
        /// 523. Continuous Subarray Sum 
        /// https://leetcode.com/problems/continuous-subarray-sum
        /// </summary>
        public static bool CheckSubarraySum(int[] nums, int k)
        {

            var seen = new Dictionary<int, int>();
            seen[0] = 1;

            int sum = 0;

            for(int i = 1; i < nums.Length; i++)
            {
                sum += nums[i - 1];

                var rem = sum % k;

                if(seen.ContainsKey(rem))
                {
                    if (i - seen[rem] >= 2) return true;
                }
                else
                {
                    seen[rem] = i;
                }
            }

            return false;
        }

        /// <summary>
        /// 408. Valid Word Abbreviation
        /// https://leetcode.com/problems/valid-word-abbreviation
        /// </summary>
        public static bool ValidWordAbbreviation(string word, string abbr)
        {
            /*
             
                Input: word = "internationalization", abbr = "i12iz4n"
                Output: true

            */

            var digit = 0;
            var index = 0;

            for(int i = 0; i < abbr.Length; i++)
            {
                if (char.IsLetter(abbr[i]))
                {
                    if (digit != 0)
                    {  
                        index += digit; 
                        digit = 0;
                    }
                   
                    if (index >= word.Length || abbr[i] != word[index]) return false;
                    index++;
                }
                else
                {
                    // missed leading zero case
                    if (abbr[i] == '0' && digit == 0) return false; // leading zero
                    digit = digit * 10 + int.Parse(abbr[i].ToString());
                }
            }

            return index + digit == word.Length; // flush trailing digits, missed this
        }

        /// <summary>
        /// 1891. Cutting Ribbons
        /// https://leetcode.com/problems/cutting-ribbons
        /// </summary>
        public static int MaxLength(int[] ribbons, int k)
        {
            /*
                
                Input: ribbons = [9,7,5], k = 3
                Output: 5

                O(log n) -> binary
                
                l = 1, r = max

                9,7,5
            
             */

            var l = 0;
            var r = ribbons.Max();

            while (l < r)
            {
                // important to use upper mid, or it will be TLE as l will not move
                // case: l = 4, m = 5, below will be stuck in TLE
                //var m = (l + r) / 2;

                // for ref, lower mid is this, when we use r = m, usually this needed.
                //var m = l + (m - l) / 2; 

                var m = + (r - l + 1) / 2; // upper mid

                if (CanCut(m))
                {
                    l = m;
                }
                else
                {
                    r = m - 1;
                }
            }

            return l;

            bool CanCut(int m)
            {
                var count = 0;

                for(int i = 0; i < ribbons.Length; i++)
                {
                    count += ribbons[i] / m;
                    if (count >= k) return true;
                }
                return false;
            }
        }

        /// <summary>
        /// 708. Insert into a Sorted Circular Linked List
        /// https://leetcode.com/problems/insert-into-a-sorted-circular-linked-list
        /// </summary>
        public static ListNode Insert(ListNode head, int insertVal)
        {
            if(head == null)
            {
                var insertNode = new ListNode(insertVal);
                insertNode.next = insertNode;
                return insertNode;
            }

            // figure out start and end of list
            var start = head.next;
            var end = head;
            var cur = head.next;

            while(cur != head)
            {
                if(cur.value > cur.next.value)
                {
                    end = cur;
                    start = cur.next;
                    break;
                }
                cur = cur.next;
            }

            // temporarliy make list circular
            end.next = null;

            // loop from start to end to insert at the correct position
            // then restore the list
            var nd = start;
            while(nd != null)
            {
                if (nd.next == null)
                {
                    // reached end
                    nd.next = new ListNode(insertVal);
                    // stitch it to start
                    nd.next.next = start;
                    break;
                }
                else if (insertVal >= nd.value && insertVal <= nd.next.value)
                {
                    var temp = nd.next;
                    nd.next = new ListNode(insertVal);
                    nd.next.next = temp;
                    // stitch it back
                    end.next = start;
                    break;
                    
                } 
                nd = nd.next; 
            }

            return head;
        }

        /// <summary>
        /// 227. Basic Calculator II
        /// https://leetcode.com/problems/basic-calculator-ii
        /// </summary>
        public static int Calculate(string s)
        {
            /*
            Input: s = "3+2*2"
            Output: 7

            Input: s = " 3+5 / 2 "
            Output: 5
             */

            s += '+';

            var stk = new Stack<int>();
            var digit = 0;
            var sign = '+';

            for(int i = 0; i < s.Length; i ++)
            {
                if (char.IsDigit(s[i])) digit = digit * 10 + (s[i] - '0');

                else if (s[i] == '+' || s[i] == '-' || s[i] == '*' || s[i] == '/')
                {
                    if (s[i] == '+') 
                        stk.Push(digit);
                    else if (s[i] == '-') 
                        stk.Push(digit * -1);
                    else if (s[i] == '*')
                        stk.Push(stk.Pop() * digit);
                    else if (s[i] == '/') 
                        stk.Push(stk.Pop() / digit);

                    sign = s[i];
                    digit = 0;
                }
            }

            var res = 0;
            while(stk.Count > 0)
            {
                res += stk.Pop();
            }
            return res;
        }
    }
}
