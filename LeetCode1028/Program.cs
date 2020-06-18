using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LeetCode1028
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }

    }
    public class Solution
    {
        public TreeNode RecoverFromPreorder(string S)
        {
            int firstDash = 0;
            while (firstDash < S.Length && S[firstDash] != '-') { firstDash++; }
            TreeNode root = new TreeNode(int.Parse(S.Substring(0,firstDash).ToString()));
            int dashCount = 0;
            StringBuilder sb = new StringBuilder();
            List<TreeNode> tnList = new List<TreeNode>{ root };

            for (int ind = firstDash; ind < S.Length; ++ind)
            {
                if (S[ind] == '-' || ind == S.Length - 1)
                {
                    if (sb.Length == 0 && ind != S.Length - 1)
                    {
                        dashCount++;
                    }
                    else
                    {
                        if (ind == S.Length -1) { sb.Append(S[ind]); }
                        int val = int.Parse(sb.ToString());
                        sb.Clear();

                        try { tnList[dashCount] = new TreeNode(val); }
                        catch (ArgumentOutOfRangeException) { tnList.Add(new TreeNode(val)); }

                        if (tnList[dashCount - 1].left == null) 
                        { tnList[dashCount - 1].left = tnList[dashCount]; }
                        else 
                        { tnList[dashCount - 1].right = tnList[dashCount]; }

                        dashCount = 1;
                    }

                }
                else
                {
                    sb.Append(S[ind]);
                }
            }
            return root;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string S = "1-2--3--4-5--6--7";
            Solution s = new Solution();
            s.RecoverFromPreorder(S);
        }
    }

}
