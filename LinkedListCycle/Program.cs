namespace LinkedListCycle
{
    /**
Definition for singly-linked list.**/
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }

    public class Solution
    {
        public bool HasCycle(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;
            while (fast != null && fast.next.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
                if (fast == slow)
                {
                    return true;
                }
            }
            return false;
        }
    }
    internal class Program
    {
        static void createCycle(ListNode head, int a, int b)
        {
            int current_a = 0, current_b = 0;
            ListNode p1 = head;
            ListNode p2 = head;
            while (current_a != a || current_b != b)
            {
                if (current_a != a)
                { p1 = p1.next; ++current_a; }
                if (current_b != b)
                { p2 = p2.next; ++current_b; }
            }
            p2.next = p1;
        }
        static void Main(string[] args)
        {
            Solution s = new Solution();
            ListNode node = new ListNode(3);
            node.next = new ListNode(2);
            node.next.next = new ListNode(0);
            node.next.next.next = new ListNode(-4);
            createCycle(node, 1, 3);//create cycle at 1st index and 3rd index
            var res =  s.HasCycle(node);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
