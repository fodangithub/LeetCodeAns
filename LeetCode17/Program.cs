using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode17
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            IList<string> res = s.LetterCombinations("23");

            foreach(string ss in res) { Console.WriteLine(ss); }
        }
    }

    public class Solution
    {
        public IList<string> LetterCombinations(string digits)
        {
            if (digits.Length == 0)
            {
                return new List<string>();
            }
            List<string> res = new List<string>();
            int[] indicators = new int[digits.Length];
            while (true)
            {
                // Handle the digit overflow
                for (int ind = 0; ind < indicators.Length - 1; ++ind)
                {
                    if (indicators[ind] == numpad[digits[ind]].Count)
                    {
                        indicators[ind + 1] += 1;
                        indicators[ind] = 0;
                    }
                }
                if (indicators[^1] == numpad[digits[^1]].Count) { break; }

                // Put in chars
                StringBuilder sb = new StringBuilder();
                for (int ind = 0; ind < indicators.Length; ++ind)
                {
                    int n = indicators[ind];
                    char number = digits[ind];
                    char charToAppend = numpad[number][n];
                    sb.Append(charToAppend);
                }
                res.Add(sb.ToString());
                ++indicators[0];
            }
            return res;
        }
        Dictionary<char, List<char>> numpad = new Dictionary<char, List<char>>
        {
            ['2'] = new List<char> { 'a', 'b', 'c' },
            ['3'] = new List<char> { 'd', 'e', 'f' },
            ['4'] = new List<char> { 'g', 'h', 'i' },
            ['5'] = new List<char> { 'j', 'k', 'l' },
            ['6'] = new List<char> { 'm', 'n', 'o' },
            ['7'] = new List<char> { 'p', 'q', 'r', 's' },
            ['8'] = new List<char> { 't', 'u', 'v' },
            ['9'] = new List<char> { 'w', 'x', 'y', 'z' }
        };
    }
}
