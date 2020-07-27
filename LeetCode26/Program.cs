using System;
using System.Linq;

namespace LeetCode26
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] inp = new int[] { 0, 0, 0, 1, 2, 3, 3, 4, 5, 5 };
            Console.WriteLine(s.RemoveDuplicates(inp).ToString());
            Console.WriteLine($"[{ string.Join(@", ", inp) }]");
        }
    }

    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            try
            {
                int modifyingIndex = 1;
                int compared = nums[0];
                for (int ind = 1; ind < nums.Length; ++ind)
                {
                    if (nums[ind] != compared)
                    {
                        compared = nums[ind];
                        nums[modifyingIndex] = compared;
                        modifyingIndex++;
                    }
                }
                return modifyingIndex;
            }
            catch (IndexOutOfRangeException)
            {
                if (nums.Length == 0) { return 0; }
                else { return 1; }
            }
        }
    }
}
