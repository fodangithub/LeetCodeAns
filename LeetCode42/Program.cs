using System;
using System.Collections.Generic;

namespace LeetCode42
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Solution
    {
        /// <summary>
        /// //// NOT YET FINISHED.
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap(int[] height)
        {
            // (index, val)
            List<(int,int)> localMax = new List<(int, int)>();

            if (height[0] > height[1]) { localMax.Add((0, height[0])); }

            for(int ind = 1; ind < height.Length - 1; ++ind)
            {
                if(height[ind] > height[ind-1] && height[ind] > height[ind+1])
                {
                    localMax.Add((ind, height[ind]));
                }
            }

            if (height[^2] < height[^1]) { localMax.Add((height.Length - 1, height[^1])); }

            int res = 0;
            for (int ind = 0; ind < localMax.Count - 1; ++ind)
            {
                
            }
        }
    }
}
