namespace RotatingtheBox
{

    /*
     You are given an m x n matrix of characters box representing a side-view of a box. Each cell of the box is one of the following:

A stone '#'
A stationary obstacle '*'
Empty '.'
The box is rotated 90 degrees clockwise, causing some of the stones to fall due to gravity. Each stone falls down until it lands on an obstacle, another stone, or the bottom of the box. Gravity does not affect the obstacles' positions, and the inertia from the box's rotation does not affect the stones' horizontal positions.

It is guaranteed that each stone in box rests on an obstacle, another stone, or the bottom of the box.

Return an n x m matrix representing the box after the rotation described above.

    Input: box = [["#",".","#"]]
Output: [["."],
         ["#"],
         ["#"]]

    Input: box = [["#",".","*","."],
              ["#","#","*","."]]
Output: [["#","."],
         ["#","#"],
         ["*","*"],
         [".","."]]


    Input: box = [["#","#","*",".","*","."],
              ["#","#","#","*",".","."],
              ["#","#","#",".","#","."]]
Output: [[".","#","#"],
         [".","#","#"],
         ["#","#","*"],
         ["#","*","."],
         ["#",".","*"],
         ["#",".","."]]
     */
    public class Solution
    {
        public char[][] RotateTheBox(char[][] box)
        {
            int boxn = box.Length;
            int boxm = box[0].Length;
            //write code to transpose  -  rows to columns

            Console.WriteLine("-----print box array-----------");
            for (int i = 0; i < box.Length; i++)
            {
                for (int j = 0; j < box[0].Length; j++)
                {
                    Console.Write(box[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-----END print box array-----------");

            char[,] transposebox = new char[boxm, boxn]; // initialize with col, row because in transpose rows will convert to cols

            for (int i = 0; i < boxn; i++)
            {
                for (int j = 0; j < boxm; j++)
                {
                    transposebox[j, i] = box[i][j];
                }
            }

            int transrows = transposebox.GetLength(0);
            int transcols = transposebox.GetLength(1);


            Console.WriteLine("-----print transpose array-----------");
            for (int i = 0; i < transrows; i++)
            {
                for (int j = 0; j < transcols; j++)
                {
                    Console.Write(transposebox[i,j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("-----END print transpose array-----------");

            //rotate 90 degree of transposed array

            //char[,] rotatetransposed = new char[transrows, transcols];

            //for (int i = 0; i < transrows; i++)
            //{
            //    for (int j = 0; j < transcols; j++)
            //    {
            //        rotatetransposed[i, j] = transposebox[i, transcols - j - 1];
            //    }
            //}

            char[][] rotatetransposed = new char[transrows][];
            for (int i = 0; i < transrows; i++)
            {
                rotatetransposed[i] = new char[transcols];
            }

            for (int i = 0; i < transrows; i++)
            {
                for (int j = 0; j < transcols; j++)
                {
                    rotatetransposed[i][j] = transposebox[i, transcols - j - 1];
                }
            }

            int row = rotatetransposed.Length;
            int col = rotatetransposed[0].Length;


            Console.WriteLine("-----print 90 degree rotated transpose array-----------");
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(rotatetransposed[i][j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("-----END print 90 degree rotated transpose array-----------");


            //implement gravity

  
            for (int j = 0; j < col; j++)
            {
                for (int i = row - 1; i >= 0; i--)
                {

                    //if space found then check stone 
                    if (rotatetransposed[i][j] == '.')
                    {
                        //lets find stone 
                        int stonerow = -1;
                        for (int k = i - 1; k >= 0; k--)
                        {
                            if (rotatetransposed[k][j] == '*')
                            {
                                break;
                            }
                            else if (rotatetransposed[k][j] == '#')
                            {
                                stonerow = k;
                                break;
                            }
                        }

                        if (stonerow != -1)
                        {
                            rotatetransposed[i][j] = '#';
                            rotatetransposed[stonerow][j] = '.';
                        }

                    }
                }
            }

            return rotatetransposed;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Solution s = new Solution();
            char[][] box =
            {
                new char[] {'#','#','*','.','*','.' },
                new char[] {'#','#','#','*','.','.' },
                new char[] {'#','#','#','.','#','.' }
            };

            //            char[][] box =
            //{
            //                new char[] {'1','2','3' },
            //                new char[] {'4','5','6'},
            //                new char[] {'7','8','9' }
            //            };

            var res = s.RotateTheBox(box);

            for (int i = 0; i < res.Length; i++)
            {
                for (int j = 0; j < res[0].Length; j++)
                {
                    Console.Write(res[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}