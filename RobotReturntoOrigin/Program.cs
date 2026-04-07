namespace RobotReturntoOrigin
{
    //657. Robot Return to Origin
    /*
     There is a robot starting at the position (0, 0), the origin, on a 2D plane. Given a sequence of its moves, judge if this robot ends up at (0, 0) after it completes its moves.
    The move sequence is represented by a string, and the character moves[i] represents its ith move. Valid moves are R (right), L (left), U (up), and D (down). If the robot returns to the origin after it finishes all of its moves, return true. Otherwise, return false.
    T: O(n)
     */

    public class Solution
    {
        public bool JudgeCircle(string moves)
        {
            if (moves.Length <= 0)
            {
                return false;
            }

            int countU = 0;
            int countD = 0;
            int countL = 0;
            int countR = 0;

            for (int i = 0; i < moves.Length; i++)
            {
                if(moves[i] == 'U') countU++;
                else if (moves[i] == 'D') countD++;
                else if (moves[i] == 'L') countL++;
                else if (moves[i] == 'R') countR++;
            }

            if((countU == countD) && (countL == countR))
            {
                return true;
            }
        
            return false;
        }
}

    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();
            string moves = "UDLR";
            bool result = solution.JudgeCircle(moves);
            Console.WriteLine(result); // Output: true
        }
    }
}