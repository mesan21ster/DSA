namespace CountSubarraysWithFixedBounds
{
    public class Solution
    {

        /*
         You are given an integer array nums and two integers minK and maxK.

A fixed-bound subarray of nums is a subarray that satisfies the following conditions:

The minimum value in the subarray is equal to minK.
The maximum value in the subarray is equal to maxK.
Return the number of fixed-bound subarrays.

A subarray is a contiguous part of an array.
         */


        /*
         Explanation of code point wise :

int n = nums.size(); : This statement initializes a variable n with the size of the input vector nums.
int lastInvalidElement = -1; : This statement initializes a variable lastInvalidElement to -1. This variable represents the index of the left endpoint of the current subarray being considered. Initially, there is no subarray being considered, so we set lastInvalidElement to -1.
int lastMin = -1, lastMax = -1; : These statements initialize two variables lastMin and lastMax to -1. These variables represent the indices of the most recent occurrences of minK and maxK, respectively. Initially, there are no occurrences of minK and maxK, so we set both variables to -1.
long long count = 0; : This statement initializes a variable count to 0. This variable represents the count of valid subarrays that we will be computing.
for (int i = 0; i < n; i++) { ... } n : This statement starts a loop that iterates over each element of the input vector nums.
if (nums[i] >= minK && nums[i] <= maxK) { ... } : This statement checks if the current element nums[i] is within the range [minK, maxK].
lastMin = (nums[i] == minK) ? i : lastMin; : This statement updates lastMin to the current index i if nums[i] is equal to minK, otherwise it leaves lastMin unchanged.
lastMax = (nums[i] == maxK) ? i : lastMax; : This statement updates lastMax to the current index i if nums[i] is equal to maxK, otherwise it leaves lastMax unchanged.
count += max(0, min(lastMin, lastMax) - lastInvalidElement); : This statement computes the number of valid subarrays that end at the current index i and adds it to the total count. The number of valid subarrays is equal to the number of subarrays whose minimum and maximum elements are both in the range [minK, maxK].
         */

        //Time O(N)
        //Space O(1)
        public long CountSubarrays(int[] nums, int minK, int maxK)
        {
            int n = nums.Length; 
            int lastInvalidElement = -1;
            int lastMinKIndex = -1;
            int lastMaxKIndex = -1;
            long count = 0;

            for (int i = 0; i < n; i++)
            {
                if (nums[i] >= minK && nums[i] <= maxK)//any value between the range of mink and maxk
                {
                    lastMinKIndex = (nums[i] == minK) ? i : lastMinKIndex; // if value match to min k else default value
                    lastMaxKIndex = (nums[i] == maxK) ? i : lastMaxKIndex; // if value match to max k else default value
                    count += Math.Max(0, Math.Min(lastMinKIndex, lastMaxKIndex) - lastInvalidElement); //increase count by considering lastInvalidElement, get max out of it 
                }
                else
                {
                    lastInvalidElement= i; // make i as invalid because here no bounded subarray possible 
                    lastMinKIndex = -1; // assign it -1 as this is no longer usefull
                    lastMaxKIndex = -1;// assign it -1 as this is no longer usefull
                }
            }

            return count;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] nums = { 1, 3, 5, 2, 7, 5 };
            int minK = 1, maxK = 5;
            Console.WriteLine(solution.CountSubarrays(nums,minK, maxK));
            Console.ReadLine();
        }
    }
}