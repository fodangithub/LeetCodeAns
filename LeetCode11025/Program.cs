using System;

namespace LeetCode1025
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            Console.WriteLine(s.DivisorGame(10));
        }
    }
    public class Solution
    {
        public bool DivisorGame(int N)
        {
            return N % 2 == 0;
        }
    }

}
