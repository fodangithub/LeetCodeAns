using System;

namespace LeetCode2
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            bool additionalOne = false;
            ListNode head = new ListNode(-1);
            ListNode current = new ListNode(-1);
            head.next = current;
            do
            {
                int v1 = 0; int v2 = 0;
                if (l1 != null) { v1 = l1.val; l1 = l1.next; }
                if (l2 != null) { v2 = l2.val; l2 = l2.next; }
                int num = additionalOne ? v1 + v2 + 1 : v1 + v2;
                additionalOne = false;
                if (num > 9) { num -= 10; additionalOne = true; }
                current.next = new ListNode(num);
                current = current.next;
            } while (l1 != null || l2 != null || additionalOne);
            return head.next.next;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            ListNode l = s.AddTwoNumbers(new ListNode(5), new ListNode(5));
            do
            {
                Console.WriteLine(l.val);
                l = l.next;
            } while (l != null);
            Console.ReadKey();
        }
    }
}
