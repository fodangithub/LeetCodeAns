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
            TreeNode root = new TreeNode(int.Parse(S.Substring(0, firstDash).ToString()));
            int dashCount = 0;
            StringBuilder sb = new StringBuilder();
            List<TreeNode> tnList = new List<TreeNode> { root };

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
                        if (ind == S.Length - 1) { sb.Append(S[ind]); }
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

    public class Solution2
    {
        public TreeNode RecoverFromPreorder(string S)
        {
            MatchCollection mcNumbers = Regex.Matches(S, @"\d+");
            MatchCollection mcDashes = Regex.Matches(S, @"\-+");

            TreeNode root = new TreeNode(int.Parse(mcNumbers[0].Value));
            List<TreeNode> tnList = new List<TreeNode> { root };
            for (int numInd = 1; numInd < mcNumbers.Count; ++numInd)
            {
                int dashCount = mcDashes[numInd - 1].Length;
                int numberVal = int.Parse(mcNumbers[numInd].Value);

                if (tnList.Count <= dashCount)
                { tnList.Add(new TreeNode(numberVal)); }
                else
                { tnList[dashCount] = new TreeNode(numberVal); }

                if (tnList[dashCount - 1].left == null)
                { tnList[dashCount - 1].left = tnList[dashCount]; }
                else
                { tnList[dashCount - 1].right = tnList[dashCount]; }
            }
            return root;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string S = "1-2--3--4-5--6--7";
            Solution2 s = new Solution2();
            s.RecoverFromPreorder(S);
        }
    }

}
