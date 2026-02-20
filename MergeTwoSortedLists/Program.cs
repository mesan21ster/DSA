namespace MergeTwoSortedLists
{

    // Definition for singly-linked list.
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
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null)
            {
                return list2;
            }
            if (list2 == null)
            {
                return list1;
            }
            if (list1.val >= list2.val)
            {
                list2.next = MergeTwoLists(list1, list2.next);
                return list2;
            }
            else
            {
                list1.next = MergeTwoLists(list1.next, list2);
                return list1;
            }
        }
        public class Program
        {
            public static void Main(string[] args)
            {
                ListNode l1 = new ListNode(1, new ListNode(2, new ListNode(4)));
                ListNode l2 = new ListNode(1, new ListNode(3, new ListNode(4)));

                Solution solution = new Solution();

                ListNode mergedList = solution.MergeTwoLists(l1, l2);

                PrintList(mergedList);
            }

            private static void PrintList(ListNode head)
            {
                while (head != null)
                {
                    Console.Write(head.val + " ");
                    head = head.next;
                }
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
}