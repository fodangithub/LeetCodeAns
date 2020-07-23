using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode64
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[][] inp = new int[][] {
                new int[]{1,3,1},
                new int[]{1,5,1},
                new int[]{4,2,1}
            };
            Console.WriteLine(s.MinPathSum(inp).ToString());
        }
    }

    public class Solution
    {
        public int MinPathSum(int[][] grid)
        {
            int rowNum = grid.Length;
            int colNum = grid[0].Length;
            int[] lastRow;
            int[] currentRow = new int[colNum];// (new List<int>(Enumerable.Repeat(grid[0].Sum(), colNum))).ToArray();

            for (int row = 0; row < rowNum; ++row)
            {
                lastRow = currentRow;
                currentRow = new int[colNum];
                for (int col = 0; col < colNum; ++col)
                {
                    int steps = 0;
                    if (row > 0)
                    {
                        steps = lastRow[col] + grid[row][col]; // step from top
                        try
                        {
                            int stepFromLeft = currentRow[col - 1] + grid[row][col]; // step from left
                            steps = stepFromLeft < steps ? stepFromLeft : steps;
                        }
                        catch (IndexOutOfRangeException) {; }
                    }
                    else
                    { 
                        if (col == 0)
                        {
                            steps = grid[row][col];
                        }
                        else
                        {
                            steps = currentRow[col - 1] + grid[row][col];
                        }
                    }
                    currentRow[col] = steps;
                }
            }
            return currentRow[^1];
        }
    }
}
