using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace LeetCode785
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public bool IsBipartite(int[][] graph)
        {
            List<bool[]> connectivityMatrix = new List<bool[]>();
            
            for (int nodeIndex = 0; nodeIndex < graph.Length; ++nodeIndex)
            {
                foreach(int connectedNode in graph[nodeIndex])
                {
                    if(connectedNode > nodeIndex)
                    {
                        bool[] lineConnection = new bool[graph.Length];
                        lineConnection[nodeIndex] = true;
                        lineConnection[connectedNode] = true;
                        connectivityMatrix.Add(lineConnection);
                    }
                }
            }

            bool[] setAValidation = new bool[connectivityMatrix.Count];
            bool[] setBValidation = new bool[connectivityMatrix.Count];
            HashSet<int> processedNodes = new HashSet<int>();
            int nowProcessingNode = 0;
            while (processedNodes.Count < graph.Length)
            {
                List<bool> connect = connectivityMatrix.GetConnectivityForNode(nowProcessingNode);
                bool flag = false;
                foreach(bool b in connect)
                {
                    //// TODO::
                    if (b && !flag)
                    {

                    }
                    else if (b)
                    {

                    }
                    else
                    {

                    }
                }
            }
        }
    }
    public static class Extension
    {
        public static List<bool> GetConnectivityForNode(this List<bool[]> matrix, int node)
        {
            List<bool> res = new List<bool>();
            foreach(bool[] b in matrix)
            {
                res.Add(b[node]);
            }
            return res;
        }
    }
}
