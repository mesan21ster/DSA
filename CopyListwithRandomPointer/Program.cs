namespace CopyListwithRandomPointer
{
    // Definition for a Node.
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }
    public class Solution
    {
        public Node CopyRandomList(Node head)
        {
            if (head == null) return null;

            Dictionary<Node, Node> map = new Dictionary<Node, Node>();

            Node curr = head;
            Node prev = null;
            Node newHead = null;

            while (curr != null)
            {
                Node temp = new Node(curr.val);
                map[curr] = temp;//store in map
                if (newHead == null)
                {
                    newHead = temp;
                    prev = newHead;
                }
                else
                {
                    prev.next = temp;
                    prev = temp;
                }
                curr = curr.next;
            }

            //store random node corresponding to origional node

            curr = head;
            Node newCurrent = newHead;
            while (curr != null)
            {
                if (curr.random == null)
                {
                    newCurrent.random = null;
                }
                else
                {
                    newCurrent.random = map[curr.random]; // update random
                }
                curr = curr.next;
                newCurrent = newCurrent.next;
            }
            return newHead;
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Node head = new Node(1);
            head.next = new Node(2);
            head.random = null;
            head.next.random = head;
            var res = solution.CopyRandomList(head);
            while (res != null)
            {
                Console.WriteLine(res.val);
                res = res.next;
            }

            Console.ReadLine();
        }
    }
}