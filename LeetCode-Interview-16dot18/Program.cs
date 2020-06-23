using System;
using System.Globalization;
using System.Reflection.Metadata;
using System.Text;

namespace LeetCode_Interview_16dot18
{
    public class Solution
    {
        public bool PatternMatching(string pattern, string value)
        {
            // la -> length of 'a' string pattern
            // lb -> length of 'b' string pattern
            // lp -> length of pattern (total number of chars in pattern)
            // lv -> length of value (total number of chars in value)
            // aCount -> number of 'a's in pattern
            // bCount -> you got it

            int aCount = 0;
            int bCount = 0;


            foreach (char c in pattern)
            {
                if (c == 'a')
                { aCount++; }
                else
                { bCount++; }
            }
            if (value.Length == 0) { return bCount == 0; }
            if (pattern.Length == 0) { return false; }
            // swap a, b if the number of 'b' in pattern is greater than 'a'.
            if (aCount < bCount)
            {
                StringBuilder sb = new StringBuilder();
                for (int ind = 0; ind < pattern.Length; ++ind)
                { sb.Append(pattern[ind] == 'a' ? 'b' : 'a'); }
                pattern = sb.ToString();
                int tmp = 0;
                aCount = bCount;
            }

            for (int la = 0; aCount * la <= value.Length; ++la)
            {

                // la * aCount + (lp - aCount) * lb = lv
                // ->>  
                //      lb = (lv - la * aCount) / (lp - aCount)    must be a integer

                double lenB = (double)(value.Length - la * aCount) / (double)(pattern.Length - aCount);
                if (Math.Abs(lenB - Math.Round(lenB)) > 1e-6)
                {
                    continue;
                }
                else
                {
                    bool res = true;
                    int position = 0;
                    int lb = (int)Math.Round(lenB);
                    string aVal = "";
                    string bVal = "";
                    string processed = "";
                    foreach (char p in pattern)
                    {
                        processed += p;
                        Console.WriteLine($"Processed: {processed}, now processing:{p}");
                        if (p == 'a')
                        {
                            string subs = value.Substring(position, la);
                            if (aVal.Length == 0) { aVal = subs; }
                            else if (aVal != subs) { res = false; break; }
                            position += la;
                        }
                        else // p == 'b'
                        {
                            string subs = value.Substring(position, lb);
                            if (bVal.Length == 0) { bVal = subs; }
                            else if (bVal != subs) { res = false; break; }
                            position += lb;
                        }
                    }
                    if (res && aVal != bVal) { return res; }
                }
            }
            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Solution s = new Solution();
            string pattern = "bbbaa";
            string value = "xxxxxxy";
            bool b = s.PatternMatching(pattern, value);
            Console.WriteLine(b.ToString());
        }
    }
}
