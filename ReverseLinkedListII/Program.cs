namespace ReverseLinkedListII
{
    //Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            ListNode dummy = new ListNode(0);
            dummy.next = head;

            ListNode prev = dummy;
            for (int i = 1; i < left; i++)
            {
                prev = prev.next;
            }
            ListNode curr = prev.next;

            for (int i = 1; i <= right - left; i++)
            {
                ListNode temp = prev.next;
                prev.next = curr.next;
                curr.next = curr.next.next;
                prev.next.next = temp;
            }
            return dummy.next;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);

            var res = solution.ReverseBetween(head, 2,4);

            while (res != null)
            {
                Console.WriteLine(res.val);
                res = res.next;
            }
            Console.ReadLine();
        }
    }
}
