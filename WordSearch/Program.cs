
namespace WordSearch
{
    /*
     Given an m x n grid of characters board and a string word, return true if word exists in the grid.

The word can be constructed from letters of sequentially adjacent cells, where adjacent cells are horizontally or vertically neighboring. The same letter cell may not be used more than once.
     */
    //Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCCED"
    //Output: true
    public class Solution
    {
        public bool Exist(char[][] board, string word)
        {
            int[][] directions = { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
            int row = board.Length;
            int col = board[0].Length;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (board[i][j] == word[0])// start when first char matches
                    {
                        if (isExist(directions, board, i, j, 0, word, row, col))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool isExist(int[][] directions, char[][] board, int i, int j, int idx, string word, int row, int col)
        {
            if (idx == word.Length)
            {
                return true;
            }
            if (i < 0 || j < 0 || i >= row || j >= col || board[i][j] == '$')
            {
                return false;
            }

            if (board[i][j] != word[idx])
            {
                return false;
            }
            char tmp = board[i][j];
            board[i][j] = '$';

            foreach (int[] direction in directions)
            {
                int new_i = i + direction[0];
                int new_j = j + direction[1];

                if(isExist(directions,board,new_i,new_j,idx + 1, word, row, col))
                {
                    return true;
                }
            }

            board[i][j] = tmp;

            return false;
        }
    }
    public class Program
    {
        public static void Main(string[] args) {
            
            Solution solution = new Solution();
            char[][] board = [['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']];
            string word = "ABCCED";

            var res = solution.Exist(board, word);

            Console.WriteLine(res);
        }
    }
}