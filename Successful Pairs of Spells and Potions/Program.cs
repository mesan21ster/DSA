namespace SuccessfulPairsofSpellsandPotions
{
    public class Solution
    {
        //Time O(nlongm)
        //Space O(1)
        public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
        {
            int[] ans = new int[spells.Length];
            Array.Sort(potions);

            for (int i = 0; i < spells.Length; i++) // spells are fixed and loop to all
            {
                int low = 0;
                int high = potions.Length - 1;
                int successIndex = potions.Length;
                while (low <= high) // for potions we can use binary search
                {
                    int mid = (low + high) / 2;
                    long curr = spells[i] * potions[mid];

                    if (curr >= success)
                    {
                        successIndex = mid; // get the success index , from this index to right all element would be success so we need to validate only left side so set high = mid - 1
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1; // else find success towards right
                    }
                }
                ans[i] = (potions.Length - successIndex); // all the element will be pair from success index
            }
            return ans;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] spells = { 5, 1, 3 }, potions = { 1, 2, 3, 4, 5 };
            int success = 7;
            var res = s.SuccessfulPairs(spells,potions,success);

            foreach (int i in res)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }
}