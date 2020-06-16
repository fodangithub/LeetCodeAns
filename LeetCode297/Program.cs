using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3) { left = new TreeNode(4) { left = new TreeNode(6) }, right = new TreeNode(5) };
            Codec c = new Codec();
            Console.WriteLine( c.serialize(root));

            root = c.deserialize(c.serialize(root));
            Console.WriteLine(root.ToString());
        }
    }



    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
        public override string ToString()
        {
            return $"TN {val}: left {(left == null ? "null": left.val.ToString())}, right {(right == null ? "null" : right.val.ToString())}";
        }
    }
    public class Codec
    {

        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            List<string> nodeVals = new List<string>();
            if (root == null) { return "null"; }
            List<TreeNode> currentLayer = new List<TreeNode>() { root };
            do
            {
                currentLayer = ProceedNextLayer(ref currentLayer, ref nodeVals);
            } while (currentLayer != null);
            return string.Join(",", nodeVals);
        }

        public List<TreeNode> ProceedNextLayer(ref List<TreeNode> currentLayer, ref List<string> nodeVals)
        {
            Console.WriteLine($"Current Layer:");
            int nullCount = 0;
            const string NULL = "null";
            List<TreeNode> nextLayer = new List<TreeNode>();
            foreach (TreeNode tn in currentLayer)
            {
                if (tn == null)
                {
                    Console.WriteLine("TN: null");
                    nodeVals.Add(NULL);
                }
                else
                {
                    Console.WriteLine(tn.ToString());
                    nodeVals.Add(tn.val.ToString());
                    if (tn.left == null) { ++nullCount; }
                    if (tn.right == null) { ++nullCount; }
                    nextLayer.Add(tn.left);
                    nextLayer.Add(tn.right);
                }
            }
            return nullCount == nextLayer.Count ? null : nextLayer;
        }


        public TreeNode deserialize(string data)
        {
            string[] nodeVals = data.Split(',');
            if (nodeVals[0] == "null") { return null; }

            int vInd = 1;
            TreeNode root = new TreeNode(int.Parse(nodeVals[0]));
            List<TreeNode> currentLayer = new List<TreeNode>() { root };
            do
            {
                currentLayer = ParseNextLayer(ref currentLayer, ref vInd, ref nodeVals);
                Console.WriteLine(currentLayer.Count.ToString());
            } while (currentLayer.Count > 0);

            return root;
        }

        public List<TreeNode> ParseNextLayer(ref List<TreeNode> currentLayer, ref int vInd, ref string[] nodeVals)
        {
            List<TreeNode> nextLayer = new List<TreeNode>();
            foreach(TreeNode tn in currentLayer)
            {
                if (tn != null)
                {
                    try
                    {
                        string l = nodeVals[vInd++];
                        string r = nodeVals[vInd++];
                        if (l != "null")
                        {
                            TreeNode tnode = new TreeNode(int.Parse(l));
                            nextLayer.Add(tnode);
                            tn.left = tnode;
                        }
                        if (r != "null")
                        {
                            TreeNode tnode = new TreeNode(int.Parse(r));
                            nextLayer.Add(tnode);
                            tn.right = tnode;
                        }
                    }
                    catch
                    {
                        return nextLayer;
                    }
                }
            }
            return nextLayer;
        }
    }

}
