namespace CheckifThereisaValidPathinaGrid
{
    //time: O(m*n) where m and n are the dimensions of the grid
    //space: O(m*n) for the visited array and the recursion stack
    public class Solution
    {
        public bool HasValidPath(int[][] grid)
        {
            Dictionary<int, List<(int, int)>> map = new Dictionary<int, List<(int, int)>>();
            map.Add(1, new List<(int, int)>() { (0, -1), (0, 1) });//left and right
            map.Add(2, new List<(int, int)>() { (-1, 0), (1, 0) });//up and down
            map.Add(3, new List<(int, int)>() { (0, -1), (1, 0) });//left and down
            map.Add(4, new List<(int, int)>() { (0, 1), (1, 0) });//right and down
            map.Add(5, new List<(int, int)>() { (0, -1), (-1, 0) });//left and up
            map.Add(6, new List<(int, int)>() { (-1, 0), (0, 1) });//up and right
            int m = grid.Length;
            int n = grid[0].Length;
            bool[,] visited = new bool[m, n];//to keep track of visited cells
            return solve(grid, 0, 0, m, n, visited, map);//start from the top-left corner
        }
        private bool solve(int[][] grid, int i, int j, int m, int n, bool[,] visited, Dictionary<int, List<(int, int)>> map)
        {
            if (i < 0 || i >= m || j < 0 || j >= n || visited[i, j]) return false;//check for out of bounds and visited cells

            if (i == m - 1 && j == n - 1) return true;//check if reached the bottom-right corner

            visited[i, j] = true;//mark the current cell as visited

            foreach (var dir in map[grid[i][j]])//iterate through the possible directions based on the current cell's value
            {
                int newI = i + dir.Item1;//calculate the new row index
                int newJ = j + dir.Item2;//calculate the new column index
                if (newI < 0 || newI >= m || newJ < 0 || newJ >= n || visited[newI, newJ])
                {
                    continue;
                }


                foreach(var backDir in map[grid[newI][newJ]])//iterate through the possible directions of the new cell to check if it can connect back to the current cell
                {
                    if(newI + backDir.Item1 == i && newJ + backDir.Item2 == j)//check if the new cell can connect back to the current cell
                    {
                        if (solve(grid, newI, newJ, m, n, visited, map))//recursively call the solve function for the new cell
                        {
                            return true;//if a valid path is found, return true
                        }
                    }
                }

            
            }
           // visited[i, j] = false;//backtrack: unmark the current cell as visited for other paths

            return false;//if no valid path is found, return false
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[][] grid = new int[][]
            {
                new int[] { 1, 1, 2 }//,
                //new int[] { 6, 5, 2 }
            };
            var res = solution.HasValidPath(grid);//check if there is a valid path in the grid
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}