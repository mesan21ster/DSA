namespace SplitLinkedListinParts
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
        public ListNode[] SplitListToParts(ListNode head, int k)
        {
            ListNode curr = head;
            int l = 0;//length of list
            while (curr != null)
            {
                l++;
                curr = curr.next;
            }

            int eachbucketNode = l / k;
            int remainderNodes = l % k;

            ListNode[] result = new ListNode[k];
            curr = head;
            ListNode prev = null;

            for (int i = 0; i < k; i++)
            {
                result[i] = curr;
                for (int count = 1; count <= eachbucketNode + (remainderNodes > 0 ? 1 : 0); count++)
                {
                    prev = curr;
                    curr = curr.next;
                }
                if (prev != null)
                    prev.next = null;

                remainderNodes--;
            }
            return result;
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

            var res = solution.SplitListToParts(head, 2);

            while (res != null)
            {
                Console.WriteLine(res.Length);
            }
            Console.ReadLine();
        }
    }
}