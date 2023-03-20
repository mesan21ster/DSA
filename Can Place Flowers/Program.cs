namespace CanPlaceFlowers
{
    public class Solution
    {
        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            for (int i = 0; i < flowerbed.Length; i++)
            {

                if (isValidPlace(flowerbed, i))
                {
                    flowerbed[i] = 1;
                    n--;
                    if (n == 0)
                    {
                        return true;
                    }
                }

            }
            
            return false;
        }

        private bool isValidPlace(int[] flowerbed, int index)
        {
            bool left = flowerbed[index] == 0 && ((index == 0) || flowerbed[index - 1] == 0);
            bool right = (index == flowerbed.Length - 1) || flowerbed[index + 1] == 0;
            if (left && right)
            {

                return true;
            }

            return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] flowerbed = { 0, 0, 1, 0, 0 };
            int n = 2;
            Console.WriteLine(solution.CanPlaceFlowers(flowerbed, n));
            Console.ReadLine();
        }
    }
}