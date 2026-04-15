namespace MergekSortedLists
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
            while (lists.Count > 1)// Continue merging until only one list remains
            {
                var mergedLists = new List<ListNode>();
                for (int i = 0; i < lists.Count; i += 2)// Merge pairs of lists
                {
                    var l1 = lists[i];// Get the first list in the pair
                    var l2 = (i + 1 < lists.Count) ? lists[i + 1] : null;// Handle odd number of lists
                    mergedLists.Add(MergeTwoLists(l1, l2));// Merge the two lists and add the result to the mergedLists
                }
                lists = mergedLists;// Update the lists to the merged lists for the next iteration
            }
            return lists[0];// Return the single remaining merged list
        }
        private static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            var dummyHead = new ListNode();
            var current = dummyHead;// Initialize a dummy head to simplify edge cases and a current pointer for building the merged list
            while (l1 != null && l2 != null)// Merge nodes from both lists until one is exhausted
            {
                if (l1.val < l2.val)// Compare the current nodes of both lists and append the smaller one to the merged list
                {
                    current.next = l1;// Append l1 to the merged list
                    l1 = l1.next;// Move the pointer of l1 to the next node
                }
                else
                {
                    current.next = l2;// Append l2 to the merged list
                    l2 = l2.next;// Move the pointer of l2 to the next node
                }
                current = current.next;// Move the current pointer to the next node in the merged list
            }
            current.next = (l1 != null) ? l1 : l2;// Append the remaining nodes of l1 or l2
            return dummyHead.next;// Return the merged list, skipping the dummy head
        }
        private static void PrintList(ListNode head)
        {
            while (head != null)
            {
                Console.Write(head.val + " ");
                head = head.next;
            }
            Console.WriteLine();
        }
    }
}