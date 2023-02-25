using System;

namespace CapacityToShipPackagesWithinDDays
{

    /* Question
     A conveyor belt has packages that must be shipped from one port to another within days days.

The ith package on the conveyor belt has a weight of weights[i]. Each day, we load the ship with packages on the conveyor belt (in the order given by weights). We may not load more weight than the maximum weight capacity of the ship.

Return the least weight capacity of the ship that will result in all the packages on the conveyor belt being shipped within days days.
     */
    public class Solution
    {
        //time: O(n* log(max(weights), sum(weights))
        //space: O(1)
        public int ShipWithinDays(int[] weights, int days)
        {
            int l = 0;
            int h = 0;
            foreach (var weight in weights)
            {
                //l = minimal capacity. Capacity must greater than the heaviest cargo.
                l = Math.Max(l, weight);
                //h= maximum capacity. Capacity no need to greater than the total weight of all cargos.
                h += weight;
            }
            while (l < h)
            {
                int mid = l+(h-l)/2;
                // if all cargos can be shipped within D days with capcity mid, then decrease the capactiy
                // otherwise, increase the capacity
                if (isCapacityFull(weights, mid, days))
                {
                    h = mid;
                }
                else
                {
                    l = mid + 1;
                }
            }
            return l;
        }

        //// can all the cargos can be shipped within D days
        private bool isCapacityFull(int[] weights, int capacityAsMidValue, int days)
        {
            int daysNeeded = 1;
            int weightSum = 0;
            foreach (var weight in weights)
            {
                //check for next item for the same day
                if(weightSum + weight > capacityAsMidValue)
                {
                    daysNeeded++;
                    weightSum = 0;
                }
                weightSum += weight;
                if(daysNeeded> days)
                {
                    return false;
                }
            }

            return true;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] weights = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var res = solution.ShipWithinDays(weights, 5);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
