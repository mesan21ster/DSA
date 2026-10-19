namespace CountofSmallerNumbersAfterSelf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 5, 2, 6, 1 };
            IList<int> result = CountSmaller(arr);
            Console.WriteLine(string.Join(", ", result));
        }
        static IList<int> CountSmaller(int[] nums)
        {
            int n = nums.Length;
            
            
            // Initialize the result list with default values (0)
            List<int> result = new List<int>(new int[n]);
            
            // Stack to keep track of the elements we have seen so far
            Stack<int> stack = new Stack<int>();
            
            // Traverse the array from right to left
            for (int i = n - 1; i >= 0; i--)
            {
                // Pop elements from the stack until we found the smaller element
                while (stack.Count > 0 && stack.Peek() >= nums[i])
                {
                    stack.Pop();
                }
                // The number of smaller elements to the right is the current size of the stack
                result[i] = stack.Count;
                stack.Push(nums[i]);
            }
            return result;
        }
    }
}