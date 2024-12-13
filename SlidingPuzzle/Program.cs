using System.Text;

namespace SlidingPuzzle
{
    /*
     * 
     * 773. Sliding Puzzle
     * 
     On an 2 x 3 board, there are five tiles labeled from 1 to 5, and an empty square represented by 0. A move consists of choosing 0 and a 4-directionally adjacent number and swapping it.

The state of the board is solved if and only if the board is [[1,2,3],[4,5,0]].

Given the puzzle board board, return the least number of moves required so that the state of the board is solved. If it is impossible for the state of the board to be solved, return -1.
     
Input: board = [[1,2,3],[4,0,5]]
Output: 1
Explanation: Swap the 0 and the 5 in one move.


    Input: board = [[1,2,3],[5,4,0]]
Output: -1
Explanation: No number of moves will make the board solved.

    Input: board = [[4,1,2],[5,0,3]]
Output: 5
Explanation: 5 is the smallest number of moves that solves the board.
An example path:
After move 0: [[4,1,2],[5,0,3]]
After move 1: [[4,1,2],[0,5,3]]
After move 2: [[0,1,2],[4,5,3]]
After move 3: [[1,0,2],[4,5,3]]
After move 4: [[1,2,0],[4,5,3]]
After move 5: [[1,2,3],[4,5,0]]


     */
    public class Solution
    {
        public int SlidingPuzzle(int[][] board)
        {
            /*
             * step 1 = make sring form of matrix value
             * step 2 = take queue and perform BFS
             * step 3 =  take a set to check visited state
             * step 4 =  save all states of zero in map
             * check state and target if matched return lavel
             */

            StringBuilder stringstateofmatrix = new StringBuilder();
            //step 1
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    stringstateofmatrix.Append(Convert.ToString(board[i][j]));
                }
            }

            string targetstring = "123450";

            //step 2
            Queue<string> queue = new Queue<string>();

            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();

            //step 3
            HashSet<string> visited = new HashSet<string>();
            visited.Add(stringstateofmatrix.ToString());

            //step 4
            map[0] = new List<int> { 1, 3 };
            map[1] = new List<int> { 0, 2, 4 };
            map[2] = new List<int> { 1, 5 };
            map[3] = new List<int> { 0, 4 };
            map[4] = new List<int> { 1, 3, 5 };
            map[5] = new List<int> { 2, 4 };

            queue.Enqueue(stringstateofmatrix.ToString());
            int level = 0; // moves
            while (queue.Count > 0)
            {
                int n = queue.Count;
                while (n > 0)
                {
                    string curr = queue.Dequeue();

                    if (curr == targetstring)
                    {
                        return level;
                    }
                    int indexOfZero = curr.IndexOf('0');

                    foreach (var swapIdx in map[indexOfZero])
                    {
                        char[] newState = curr.ToCharArray();
                        newState[indexOfZero] = newState[swapIdx];
                        newState[swapIdx] = '0';

                        string newSwapIndexState = new string(newState);

                        if (!visited.Contains(newSwapIndexState))
                        {
                            visited.Add(newSwapIndexState);
                            queue.Enqueue(newSwapIndexState);
                        }
                    }
                    n--;
                }
                level++;
            }

            return -1;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[][] board =
            {
                new int[]{1,2,3 },
                new int[]{4,0,5}
            };

            var res = solution.SlidingPuzzle(board);

            Console.WriteLine(res);
        }
    }

}