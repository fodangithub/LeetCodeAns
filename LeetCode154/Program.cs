using System;
using System.Globalization;
using System.Linq;

namespace LeetCode154
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            Solution s = new Solution();

            Console.WriteLine($"Result: { s.FindMin(new int[] { 2, 2, 2, 0, 1 })}");
            Console.WriteLine($"Result: { s.FindMin(new int[] { 1, 3, 5 })}");
        }
    }

    public class Solution
    {
        public int FindMin(int[] nums)
        {
            foreach (int ind in Enumerable.Range(0, nums.Length - 1))
            {
                if (nums[ind] > nums[ind + 1])
                {
                    return nums[ind + 1];
                }
            }
            return nums[0];
        }
    }
}
