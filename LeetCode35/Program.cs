using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace LeetCode35
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LC35:");
            int[] nums = new int[] { 1, 3, 5, 6 };
            int target = 5;
            Solution s = new Solution();
            int res = s.SearchInsert(nums, target);
            Console.WriteLine(res.ToString());
        }
    }

    public class Solution
    {
        public int SearchInsert(int[] nums, int target)
        {
            return nums.Where(number => number < target).Count();
        }
    }

    public class S2
    {
        public int SearchInsert(int[] nums, int target)
        {
            for (int index = 0; index < nums.Length; ++index)
            {
                if (nums[index] >= target) { return index; }
            }
            return nums.Length;
        }
    }
}
