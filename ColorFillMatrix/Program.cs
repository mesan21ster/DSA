namespace colorFillMatrix
{
//    Time: O(R* C) in worst case (if whole grid same color)
//Space: O(R* C) worst case recursion depth(stack) for a large connected region
    public class Solution
    {
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            if(image == null || image.Length == 0 || image[0].Length == 0)
            {
                return image;
            }
            int oldColor = image[sr][sc];
            if (oldColor == newColor)
            {
                return image;
            }
            DFS(image, sr, sc, oldColor, newColor);
            return image;
        }
        private void DFS(int[][] image, int row, int col, int oldColor, int newColor)
        {
            if (row < 0 || row >= image.Length || col < 0 || col >= image[0].Length || image[row][col] != oldColor)
            {
                return;
            }
            image[row][col] = newColor;
            DFS(image, row - 1, col, oldColor, newColor); // Up
            DFS(image, row + 1, col, oldColor, newColor); // Down
            DFS(image, row, col - 1, oldColor, newColor); // Left
            DFS(image, row, col + 1, oldColor, newColor); // Right
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            int[][] image = {
                new int[] { 0, 0, 1,100,100,100 },
                new int[] { 0, 100, 1,100,100,100 },
                new int[] { 1, 1, 1,100,3,3 },
                new int[] { 1, 100, 100,100,3,3 },
                new int[] { 1, 100, 100,100,3,3 }
            };
            int sr = 2;
            int sc = 3;
            int newColor = 999;
            int[][] result = sol.FloodFill(image, sr, sc, newColor);
            // Print the modified image
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(string.Join(", ", result[i]));
            }
        }
    }
}