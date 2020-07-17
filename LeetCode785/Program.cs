using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;

namespace LeetCode785
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] g = new int[][] { new int[] { 1, 3 }, new int[] { 0, 2 }, new int[] { 1, 3 }, new int[] { 0, 2 } };
            int[][] c = new int[][] { new int[] { 1, 3 } };
            Solution s = new Solution();
            Console.WriteLine(s.IsBipartite(g).ToString());

        }
    }

    public class Solution
    {
        private bool res;
        private List<bool?> nodeInSet;
        public bool IsBipartite(int[][] graph)
        {
            res = true;
            nodeInSet = new List<bool?>(Enumerable.Repeat<bool?>(null, graph.Length));

            for(int index = 0; index < graph.Length; ++index)
            {
                if (!nodeInSet[index].HasValue)
                {
                    this.Assign(index, true, ref graph);
                }
            }
            return res;
        }
        private void Assign(int nodeNum, bool assignment, ref int[][] graph)
        {
            nodeInSet[nodeNum] = assignment;
            bool nAssign = !assignment;
            foreach(int neighborNodeNumber in graph[nodeNum])
            {
                if (!nodeInSet[neighborNodeNumber].HasValue)
                {
                    this.Assign(neighborNodeNumber, nAssign, ref graph);
                    if(!res)
                    {
                        return;
                    }
                }
                else if (nodeInSet[neighborNodeNumber] != nAssign)
                {
                    res = false;
                    return;
                }
            }
        }
    }
}
