using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace LeetCode1014
{
    class Program
    {
        public class Solution
        {
            public int MaxScoreSightseeingPair(int[] A)
            {
                int l = A[0];
                int res = int.MinValue;

                for (int ind = 1; ind < A.Length; ++ind)
                {
                    int sum = l + A[ind] - ind;
                    res = sum > res ? sum : res;
                    sum = A[ind] + ind;
                    l = sum > l ? sum : l;
                }
                return res;
            }
        }

        public class Solution2
        {
            struct CS { public int index; public int value; public CS(int ind, int val) { this.index = ind; this.value = val; } }
            public int MaxScoreSightseeingPair(int[] A)
            {
                List<CS> cList = new List<CS>();
                for (int ind = 0; ind < A.Length; ++ind) { cList.Add(new CS(ind, A[ind])); }

                var tmpQ = from a1 in cList
                           from a2 in cList
                           let res1 = a1.index - a2.index + a1.value + a2.value
                           where a1.index < a2.index
                           orderby res1 descending
                           select res1;

                foreach (var tmpVar in tmpQ) { return tmpVar; }
                return 0;
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] A = { 8, 1, 5, 2, 6 };
            Solution s = new Solution();
            Solution2 s2 = new Solution2();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int res1 = s.MaxScoreSightseeingPair(A);
            long et1 = sw.ElapsedMilliseconds;
            int res2 = s.MaxScoreSightseeingPair(A);
            long et2 = sw.ElapsedMilliseconds;
            Console.WriteLine($"Solution 1: {res1}, elapsed time: {et1}ms");
            Console.WriteLine($"Solution 2: {res2}, elapsed time: {et2 - et1}ms");
        }
    }
}
