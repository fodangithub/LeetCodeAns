using System;
using System.Collections.Generic;

namespace LeetCode20
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            string str = "([)]";
            Console.WriteLine($"{s.IsValid(str)}");
        }
    }

    public class Solution
    {
        public bool IsValid(string s)
        {
            Dictionary<char, char> validation = new Dictionary<char, char> { [']'] = '[', ['}'] = '{', [')'] = '(' };
            Stack<char> charStack = new Stack<char>();
            foreach(char c in s)
            {
                if(validation.ContainsKey(c))
                {
                    if (charStack.Count < 1 || charStack.Pop() != validation[c])
                        return false;
                }
                else
                {
                    charStack.Push(c);
                }
            }
            return charStack.Count < 1;
        }
    }
}
