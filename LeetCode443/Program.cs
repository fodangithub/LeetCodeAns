using System;
using System.Collections.Generic;

namespace LeetCode443
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Solution s = new Solution();
            Console.WriteLine(s.Compress(new char[] { 'a', 'a', 'a', 'b', 'b' }).ToString());
        }
    }

    public class Solution
    {
        public int Compress(char[] chars)
        {
            if (chars.Length < 1) { return 0; }
            else if (chars.Length == 1) { return 1; }
            char lastChar = chars[0];
            int count = 0;
            int charCounter = 0;
            int arrayIndexer = 0;
            for (int index = 0; index < chars.Length; ++index)
            {
                char c = chars[index];

                if (c == lastChar)
                {
                    ++charCounter;
                }
                else
                {
                    chars[arrayIndexer++] = lastChar;
                    if (charCounter > 1)
                    {
                        count += 1 + charCounter.ToString().Length;
                        foreach (char cc in charCounter.ToString()) { chars[arrayIndexer++] = cc; }
                    }
                    else
                    {
                        count += 1;
                    }
                    charCounter = 1;
                    lastChar = c;
                }

                if (index == chars.Length - 1)
                {
                    chars[arrayIndexer++] = lastChar;
                    if (charCounter > 1)
                    {
                        count += 1 + charCounter.ToString().Length;
                        foreach (char cc in charCounter.ToString()) { chars[arrayIndexer++] = cc; }
                    }
                    else
                    {
                        count += 1;
                    }
                }
            }
            return count;
        }
    }
}
