using System.Text;

namespace ShiftingLettersII
{
    /*
     You are given a string s of lowercase English letters and a 2D integer array shifts where shifts[i] = [starti, endi, directioni]. For every i, shift the characters in s from the index starti to the index endi (inclusive) forward if directioni = 1, or shift the characters backward if directioni = 0.

Shifting a character forward means replacing it with the next letter in the alphabet (wrapping around so that 'z' becomes 'a'). Similarly, shifting a character backward means replacing it with the previous letter in the alphabet (wrapping around so that 'a' becomes 'z').

Return the final string after all such shifts to s are applied.

 

Example 1:

Input: s = "abc", shifts = [[0,1,0],[1,2,1],[0,2,1]]
Output: "ace"
Explanation: Firstly, shift the characters from index 0 to index 1 backward. Now s = "zac".
Secondly, shift the characters from index 1 to index 2 forward. Now s = "zbd".
Finally, shift the characters from index 0 to index 2 forward. Now s = "ace".
Example 2:

Input: s = "dztz", shifts = [[0,0,0],[1,1,1]]
Output: "catz"
Explanation: Firstly, shift the characters from index 0 to index 0 backward. Now s = "cztz".
Finally, shift the characters from index 1 to index 1 forward. Now s = "catz".
     */
    public class Solution
    {
        public string ShiftingLetters(string s, int[][] shifts)
        {
            int n = s.Length;
            int[] diff = new int[n];
            StringBuilder res = new StringBuilder();
            //build diff array

            foreach (var query in shifts) {
                int left = query[0];
                int right = query[1];
                int dir = query[2] == 1 ? 1 : -1;

                diff[left] += dir;

                if (right + 1 < n) {
                    diff[right + 1] -= dir;
                }
            }
            //make cummulative sum

            for(int i = 1; i < n; i++)
            {
                diff[i] += diff[i - 1];
            }

            //apply shifts/changes

            for(int i = 0; i < n; i++)
            {
                int shift = diff[i] % 26;//wrap around
                if(shift < 0)
                {
                    shift += 26;//wrap around
                }

                char ch = Convert.ToChar((((s[i] - 'a') + shift) % 26) +'a');
                res.Append(ch);
            }
            
            return res.ToString();
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();

            string s = "abc";
            int[][] shifts = [[0, 1, 0], [1, 2, 1], [0, 2, 1]];

            var res = solution.ShiftingLetters(s, shifts);
            Console.WriteLine(res);
        }
    }
}