using System;
using System.Collections.Generic;

namespace All_O_1__DataStructure_ZJTD
{
    class Program
    {
        static void Main(string[] args)
        {
            AllOne al = new AllOne();
            al.Inc("a");
            al.Inc("b");
            al.Inc("b");
            al.Inc("c");
            al.Inc("c");
            al.Inc("c");
            al.Dec("b");
            al.Dec("b");
            Console.WriteLine(al.GetMinKey());
            al.Dec("a");
            Console.WriteLine(al.GetMaxKey());
            Console.WriteLine(al.GetMinKey());
        }
    }
    public class AllOne
    {
        Dictionary<string, int> forward;
        Dictionary<int, List<string>> backward;
        int maxVal;
        int minVal;
        /** Initialize your data structure here. */
        public AllOne()
        {
            forward = new Dictionary<string, int>();
            backward = new Dictionary<int, List<string>>();
            maxVal = int.MinValue;
            minVal = int.MaxValue;
        }

        /** Inserts a new key <Key> with value 1. Or increments an existing key by 1. */
        public void Inc(string key)
        {
            if (forward.ContainsKey(key))
            {
                backward[forward[key]].Remove(key);
                if (backward[forward[key]].Count < 1) { backward.Remove(forward[key]); }

                forward[key]++;
                if (backward.ContainsKey(forward[key]))
                {
                    backward[forward[key]].Add(key);
                }
                else
                {
                    backward[forward[key]] = new List<string> { key };
                }
            }
            else
            {
                forward[key] = 1;
                if (backward.ContainsKey(1))
                {
                    backward[1].Add(key);
                }
                else
                {
                    backward[1] = new List<string> { key };
                }
            }

            if (forward[key] > maxVal)
            {
                maxVal = forward[key];
            }
            if (!backward.ContainsKey(minVal) || forward[key] < minVal)
            {
                minVal = forward[key];
            }
        }

        /** Decrements an existing key by 1. If Key's value is 1, remove it from the data structure. */
        public void Dec(string key)
        {
            if (!forward.ContainsKey(key)) { return; }

            if (--forward[key] == 0)
            {
                forward.Remove(key);
                backward[1].Remove(key);
            }
            else
            {
                backward[forward[key] + 1].Remove(key);
                if (backward[forward[key] + 1].Count < 1) { backward.Remove(forward[key]+1); }
                if (backward.ContainsKey(forward[key]))
                {
                    backward[forward[key]].Add(key); 
                }
                else
                {
                    backward[forward[key]] = new List<string> { key };
                }
            }



            if (forward.ContainsKey(key) && forward[key] < minVal)
            {
                --minVal;
            }
        }

        /** Returns one of the keys with maximal value. */
        public string GetMaxKey()
        {
            if (backward.Count > 0)
            {
                return backward[maxVal][0];
            }
            else
            {
                return "";
            }

        }

        /** Returns one of the keys with Minimal value. */
        public string GetMinKey()
        {
            if (backward.Count > 0)
            {
                return backward[minVal][0];
            }
            else
            {
                return "";
            }
        }
    }

    /**
     * Your AllOne object will be instantiated and called as such:
     * AllOne obj = new AllOne();
     * obj.Inc(key);
     * obj.Dec(key);
     * string param_3 = obj.GetMaxKey();
     * string param_4 = obj.GetMinKey();
     */
}
