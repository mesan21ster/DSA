namespace SortanArray
{
    /*
     Merge Sort Time Complexity -> Best :- O(N log N) Average :- O(N log N) Worst :- O(N log N)
Space Complexity :- O(N)
Stable and not in-place
     */
    public class Solution
    {
        public int[] SortArray(int[] nums)
        {
            mergeSort(nums, 0, nums.Length - 1);
            return nums;
        }

        private void mergeSort(int[] nums, int low, int high)
        {
            if(low < high)
            {
                int mid = (low + high) / 2;//take middle
                mergeSort(nums, low, mid); //call left
                mergeSort(nums, mid + 1, high);//call right
                merge(nums, low, mid, high);//merge 
            }
        }

        private void merge(int[] nums, int low, int mid, int high)
        {

            int n1 = mid + 1 - low;
            int n2 = high -mid;
            int[] left = new int[n1];

            for (int p = 0; p < n1; p++)
            {
                left[p] = nums[low + p];
            }

            int[] right = new int[n2];
            for (int q = 0; q < n2; q++)
            {
                right[q] = nums[mid + 1 + q];
            }

            int i = 0, j = 0, k = low;
            while(i<n1 || j <n2)
            {
                if(j==n2 || i<n1 && left[i] < right[j])
                {
                    nums[k++] = left[i++];
                }
                else
                {
                    nums[k++] = right[j++];
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] nums = new int[] { 5, 2, 3, 1 };
            solution.SortArray(nums);
            Console.ReadLine();
        }
    }
}