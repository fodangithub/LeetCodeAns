using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LeetCode15
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { -1, 0, 1, 2, -1, -4 };
            Solution s = new Solution();
            IList<IList<int>> res = s.ThreeSum(nums);
            foreach(IList<int> li in res)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendJoin(',', li);
                Console.WriteLine($"[{sb}]");
            }
        }
    }
    public class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            ConcurrentBag<IList<int>> resC = new ConcurrentBag<IList<int>>();
            Array.Sort(nums);
            Parallel.For(0, nums.Length, (fInd) =>
            {
                if (nums[fInd] > 0) { return; }
                if (fInd == 0 || nums[fInd] > nums[fInd - 1])
                {
                    int i = fInd + 1;
                    int j = nums.Length - 1;
                    while (i < j)
                    {
                        if (nums[i] + nums[j] + nums[fInd] < 0)
                        {
                            ++i;
                        }
                        else if (nums[i] + nums[j] + nums[fInd] > 0)
                        {
                            --j;
                        }
                        else
                        {
                            resC.Add(new List<int>() { nums[fInd], nums[i], nums[j] });
                            ++i; --j;
                            while (i < j && nums[i] == nums[i - 1])
                            {
                                ++i;
                            }
                            while (i < j && nums[j] == nums[j + 1])
                            {
                                --j;
                            }
                        }
                    }
                }
            });

            return resC.ToList();
        }
    }
}
