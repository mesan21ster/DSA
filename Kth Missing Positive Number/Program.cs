namespace KthMissingPositiveNumber
{
    public class Solution
    {

        /*
         * 
         * Approach for this Problem:
Initialize start to 0 and end to n-1, where n is the size of the input array arr.
Use binary search to find the index i of the kth missing positive integer.
While start is less than or equal to end, calculate the midpoint mid as start + (end - start) / 2.
If the number of missing positive integers before arr[mid] is less than k, set start to mid + 1.
Otherwise, set end to mid - 1.
After the binary search is complete, calculate the kth missing positive integer as start + k, where start is the index found by binary search.

         Complexity:
Time complexity: O(logn)O(log n)O(logn), where n is the length of the input array. We are using binary search to find the index of the kth missing positive integer, which takes logarithmic time.
Space complexity: O(1)O(1)O(1). We are using constant extra space to store the left and right pointers in binary search.
         */
        public int FindKthPositive(int[] arr, int k)
        {
            int left = 0;
            int right = arr.Length -1;
            while (left <=  right) {
                int mid = (left + right) / 2; // find mid value
                int missing = arr[mid] - mid - 1;// find number of missing values till the mid index
                if(missing < k)//based on missing value take desision whether to move towards left or right
                {
                  left= mid + 1;
                }
                else
                {
                    right= mid - 1;
                }
            }

            return right + k + 1; // return right + k + 1 to get value why 1 , becaause array is 0 based index

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] arr = { 2, 3, 4, 7, 11 };
            int k = 5;
            Console.WriteLine(solution.FindKthPositive(arr, k));
            Console.ReadLine();
        }
    }
}