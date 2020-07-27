using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode12
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            Console.WriteLine(s.IntToRoman(4));
            Console.WriteLine(s.IntToRoman(9));
            Console.WriteLine(s.IntToRoman(58));
            Console.WriteLine(s.IntToRoman(1994));
        }
    }

    public class Solution
    {
        public string IntToRoman(int num)
        {
            Dictionary<char, string[]> dict = new Dictionary<char, string[]>()
            {
                ['1'] = new string[] {"I", "X", "C", "M"},
                ['2'] = new string[] { "II", "XX", "CC", "MM" },
                ['3'] = new string[] { "III", "XXX", "CCC", "MMM" },
                ['4'] = new string[] { "IV", "XL", "CD" },
                ['5'] = new string[] { "V", "L", "D" },
                ['6'] = new string[] { "VI", "LX", "DC" },
                ['7'] = new string[] { "VII", "LXX", "DCC" },
                ['8'] = new string[] { "VIII", "LXXX", "DCCC" },
                ['9'] = new string[] { "IX", "XC", "CM" },
            };

            string inp = num.ToString();
            StringBuilder sb = new StringBuilder();

            for (int index = 0; index < inp.Length; ++index)
            {
                char n = inp[^(1 + index)];
                if (n != '0')
                {
                    sb.Insert(0, dict[n][index]);
                }
            }
            
            return sb.ToString();
        }
    }
}
