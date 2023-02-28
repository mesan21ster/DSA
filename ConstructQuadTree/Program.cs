using System.Xml.Linq;

namespace ConstructQuadTree
{
    /*
     Approach for this Problem:
Define a recursive function build that takes in the current grid as well as the indices row_start, row_end, col_start, col_end.
Check if the current grid is a leaf node. If yes, create a new node and set its isLeaf and val attributes to true or false based on the value of the current grid.
Otherwise, create a new node and set its isLeaf attribute to false and val attribute to true (since it does not matter).
Divide the current grid into four sub-grids by calculating the midpoints of the current row and column ranges: mid_row = (row_start + row_end) / 2 and mid_col = (col_start + col_end) / 2.
Recursively build each of the four sub-grids and set the corresponding child node of the current node to the result.
Return the current node.
Call the build function with the entire grid and return the root node.
     */

    /*
     Time Complexity and Space Complexity:
Time complexity: O(n^2logn)
The reason is that the code iterates through all the elements in each quadrant to check if they are the same. This takes O(N^2) time. 
    Since the grid is divided into four quadrants in each recursive call, the total number of recursive calls is O(log N). 
    Therefore, the overall time complexity of the algorithm is O(N^2 log N).

Space complexity: O(N^2) because it constructs a quadtree with nodes for each quadrant of the input grid. 
    Since the input grid is N x N, the maximum number of nodes in the quadtree is also N^2. 
    This means that the space required to store the quadtree is O(N^2). Additionally, 
    the recursive calls on the stack require O(log N) space due to the maximum depth of the recursion. Therefore,
    the overall space complexity of the algorithm is O(N^2 + log N) which can be simplified to O(N^2) since N^2 dominates log N.
     */
    public class Node
    {
        public bool val;
        public bool isLeaf;
        public Node topLeft;
        public Node topRight;
        public Node bottomLeft;
        public Node bottomRight;

        public Node()
        {
            val = false;
            isLeaf = false;
            topLeft = null;
            topRight = null;
            bottomLeft = null;
            bottomRight = null;
        }

        public Node(bool _val, bool _isLeaf)
        {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = null;
            topRight = null;
            bottomLeft = null;
            bottomRight = null;
        }

        public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
        {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = _topLeft;
            topRight = _topRight;
            bottomLeft = _bottomLeft;
            bottomRight = _bottomRight;
        }
    }
    public class Solution
    {
        public Node Construct(int[][] grid)
        {
            return NodeConstruct(grid, 0, 0, grid.Length - 1, grid[0].Length - 1);
        }
        private Node? NodeConstruct(int[][] grid, int rowStart, int colStart, int rowEnd, int colEnd)
        {
            if (rowStart > rowEnd || colStart > colEnd)
            {
                return null;
            }
            bool isLeaf = true;
            int val = grid[rowStart][colStart];
            for (int i = rowStart; i <= rowEnd; i++)
            {
                for (int j = colStart; j <= colEnd; j++)
                {
                    if (grid[i][j] != val)
                    {
                        isLeaf = false;
                        break;
                    }
                }
            }
            if (isLeaf)
            {
                return new Node(val == 1, true);
            }
            int rowMid = (rowStart + rowEnd) / 2;
            int colMid = (colStart + colEnd) / 2;
            Node topLeft = NodeConstruct(grid, rowStart, colStart, rowMid, colMid);
            Node topRight = NodeConstruct(grid, rowStart, colMid + 1, rowMid, colEnd);
            Node bottomLeft = NodeConstruct(grid, rowMid + 1, colStart, rowEnd, colMid);
            Node bottomRight = NodeConstruct(grid, rowMid + 1, colMid + 1, rowEnd, colEnd);
            return new Node(false, false, topLeft, topRight, bottomLeft, bottomRight);
        }

       
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[][] grid =
            {
                new int[]{ 1, 1, 1, 1, 0, 0, 0, 0},
                new int[]{ 1, 1, 1, 1, 0, 0, 0, 0},
                new int[]{ 1, 1, 1, 1, 1, 1, 1, 1},
                new int[]{ 1, 1, 1, 1, 1, 1, 1, 1},
                new int[]{1,1,1,1,0,0,0,0},
                new int[]{1,1,1,1,0,0,0,0},
                new int[]{1,1,1,1,0,0,0,0},
                 new int[]{1,1,1,1,0,0,0,0},
            };

            var res = solution.Construct(grid);
            Console.ReadLine();
        }
    }
}
