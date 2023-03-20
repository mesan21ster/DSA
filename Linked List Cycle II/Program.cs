namespace LinkedListCycleII
{
    //O(N) time
    //O(1) space
    /*
     Floyd's cycle-finding algorithm / "tortoise and hare" algorithm
The idea is to use 2 pointers, fast and slow. Fast travels 2 nodes at a time and slow 1 node at a time. If a cycle exists, they have to meet at a point, since the fast has to overtake slow pointer within the circle/cycle.

Initialize two pointers, slow and fast, to the head of the linked list.

Move the fast pointer two steps at a time and the slow pointer one step at a time.

If the fast pointer encounters a null node or reaches the end of the list, then there is no cycle in the list. Return null.

If the fast pointer and slow pointer meet at any node, then there is a cycle in the list.

To find the start of the cycle, initialize the slow pointer to the head of the list and keep the fast pointer at the node where slow and fast met.

Move both pointers one step at a time until they meet. The node where they meet is the start of the cycle.
     */
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
        public ListNode DetectCycle(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
                if (fast == slow)//here indicats that there is cycle , both meets 
                {
                    slow = head;// assign slow to head
                    while (slow != fast)//loop till both are not matched and forward 1 step to both 
                    {
                        fast = fast.next;
                        slow = slow.next;
                    }
                    return slow; //if both meets than return, this is the point where cycle starts 
                }
            }
            return null;// return null if there are no cycle
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            ListNode listNode = new ListNode(3);
            listNode.next = new ListNode(2);
            listNode.next.next = new ListNode(0);
            listNode.next.next.next = new ListNode(-4);
            listNode.next.next.next.next = listNode.next;
            var cycle = solution.DetectCycle(listNode);
            Console.WriteLine(cycle.val);
            Console.ReadLine();
        }
    }
}