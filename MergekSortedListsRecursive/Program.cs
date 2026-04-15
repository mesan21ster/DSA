namespace MergekSortedListsRecursive
{
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
    internal class Program
    {
        static void Main(string[] args)
        {
            var list1 = new ListNode(1, new ListNode(4, new ListNode(5)));
            var list2 = new ListNode(1, new ListNode(3, new ListNode(4)));
            var list3 = new ListNode(2, new ListNode(6));
            var lists = new List<ListNode> { list1, list2, list3 };
            var mergedList = MergeKLists(lists);
            PrintList(mergedList);
        }
        public static ListNode MergeKLists(List<ListNode> lists)
        {
            if (lists == null || lists.Count == 0) return null;
            if (lists.Count == 1) return lists[0];// Base case: if there's only one list, return it
            
            int mid = lists.Count / 2;// Divide the lists into two halves
            
            var leftHalf = MergeKLists(lists.GetRange(0, mid));// Recursively merge the left half
            var rightHalf = MergeKLists(lists.GetRange(mid, lists.Count - mid));// Recursively merge the right half
            
            return MergeTwoLists(leftHalf, rightHalf);// Merge the two halves and return the result
        }
        private static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;// If l1 is null, return l2
            if (l2 == null) return l1;// If l2 is null, return l1
            
            if (l1.val < l2.val)// Compare the current nodes of both lists and recursively merge the smaller one with the rest of the other list
            {
                l1.next = MergeTwoLists(l1.next, l2);// Merge the rest of l1 with l2 and set it as the next node of l1
                return l1;// Return l1 as the head of the merged list
            }
            else
            {
                l2.next = MergeTwoLists(l1, l2.next);// Merge l1 with the rest of l2 and set it as the next node of l2
                return l2;// Return l2 as the head of the merged list
            }
        }
        private static void PrintList(ListNode head)
        {
            var current = head;
            while (current != null)
            {
                Console.Write(current.val + " ");
                current = current.next;
            }
            Console.WriteLine();
        }
    }
}