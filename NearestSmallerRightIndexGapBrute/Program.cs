namespace NearestSmallerRightIndexGapBrute
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 4, 5, 2, 10, 8 };
            //int[] result = NearestSmallerRightIndexGap(arr);
            int[] result = NearestSmallerRightGap(arr);
            Console.WriteLine(string.Join(", ", result));
        }
        //static int[] NearestSmallerRightIndexGap(int[] arr)
        //{
        //    int n = arr.Length;
        //    int[] result = new int[n];
        //    for (int i = 0; i < n; i++)
        //    {
        //        result[i] = -1; // Default value if no smaller element is found
        //        for (int j = i + 1; j < n; j++)
        //        {
        //            if (arr[j] < arr[i])
        //            {
        //                result[i] = j - i; // Store the gap (index difference)
        //                break; // Stop after finding the first smaller element
        //            }
        //        }
        //    }
        //    return result;
        //}


        static int[] NearestSmallerRightGap(int[] arr)
        {
            int n = arr.Length;
            int[] result = new int[n];
            Array.Fill(result, -1); // Default value if no smaller element is found
            Stack<int> stack = new Stack<int>();
            // Traverse the array from right to left
            for (int i = n - 1; i >= 0; i--)
            {
                // Pop elements from the stack until we found the smaller element
                while (stack.Count > 0 && arr[stack.Peek()] >= arr[i])
                {
                    stack.Pop();
                }
                //if stack is empty -> no smaller element on right
                if (stack.Count == 0)
                {
                    result[i] = -1;
                }
                else
                {
                    //neareast smaller index
                    int neareastIndex = stack.Peek();

                    // caculate the gap
                    result[i] = neareastIndex - i;
                }
                //push current index onto stack
                stack.Push(i);
            }

            return result;
        }
    }
}