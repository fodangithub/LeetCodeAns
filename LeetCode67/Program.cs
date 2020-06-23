using System;
using System.Text;

namespace LeetCode67
{
    public class Solution
    {
        public void Add(ref string a, int positionOfOne)
        {
            if (a[0] == '0') { a = "1"; return; }
            StringBuilder sb = new StringBuilder(a);
            if (positionOfOne == 0 && a[0] == '1')
            {
                sb[0] = '0';
                sb.Insert(0, '1');
                a = sb.ToString();
                return;
            }
            else
            {
                if (a[positionOfOne] == '1')
                {
                    sb[positionOfOne] = '0';
                    a = sb.ToString();
                    Add(ref a, positionOfOne - 1);
                    return;
                }
                else
                {
                    sb[positionOfOne] = '1';
                    a = sb.ToString();
                    return;
                }
            }
        }
        public string AddBinary(string a, string b)
        {
            if (a.Length < b.Length)
            {
                string tmp = a;
                a = b;
                b = tmp;
            }

            for (int ind = 0; ind < b.Length; ++ind)
            {
                int pos = ind + a.Length - b.Length;

                if (b[ind] == '1')
                {
                    Add(ref a, pos);
                }
            }
            return a;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string a = "1000100101011010101";
            string b = "101101010101";
            Solution s = new Solution();
            string res = s.AddBinary(a, b);
            Console.WriteLine(res);

        }
    }
}
