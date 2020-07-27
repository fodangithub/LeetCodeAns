using System;

namespace LeetCode392
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solu = new Solution();
            string s = "abc";
            string t = "ahbgdc";
            Console.WriteLine(solu.IsSubsequence(s, t).ToString());

            s = "axc";
            t = "ahbgdc";
            Console.WriteLine(solu.IsSubsequence(s, t).ToString());
        }
    }

    public class Solution
    {
        public bool IsSubsequence(string s, string t)
        {
            // EMPTY string s
            if (s.Length == 0)
                return true;
            else if (t.Length == 0)
                return false;

            // double pointers
            int sInd = 0;
            int tInd = 0;
            while (tInd < t.Length)
            {
                if (t[tInd] == s[sInd])
                {
                    sInd++;
                    if (sInd == s.Length)
                        return true;
                }
                tInd++;
            }
            return false;
        }
    }
}
