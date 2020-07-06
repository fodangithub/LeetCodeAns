using System;

namespace LeetCode63
{
    class Program
    {

        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[][] obs = new int[][]{
                new int[]{0,0,0},
                new int[]{0,1,0},
                new int[]{0,0,0}
            };
            int res = s.UniquePathsWithObstacles(obs);
            Console.WriteLine($"LC63 Test {res}");
        }
    }

    public class Solution
    {
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            int n = obstacleGrid.Length;
            int m = obstacleGrid[0].Length;

            int[] f = new int[m];

            f[0] = obstacleGrid[0][0] == 0 ? 1 : 0;
            for (int nInd = 0; nInd < n; ++nInd)
            {
                for (int mInd = 0; mInd < m; ++mInd)
                {
                    if (obstacleGrid[nInd][mInd] == 1)
                    {
                        f[mInd] = 0;
                        continue;
                    }
                    if (mInd - 1 >= 0 && obstacleGrid[nInd][mInd - 1] == 0)
                    {
                        f[mInd] += f[mInd - 1];
                    }
                }
            }
            return f[m - 1];
        }
    }
}
