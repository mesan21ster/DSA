namespace DefusetheBomb
{
    /*
     * 1652. Defuse the Bomb
     * 
     You have a bomb to defuse, and your time is running out! Your informer will provide you with a circular array code of length of n and a key k.

To decrypt the code, you must replace every number. All the numbers are replaced simultaneously.

If k > 0, replace the ith number with the sum of the next k numbers.
If k < 0, replace the ith number with the sum of the previous k numbers.
If k == 0, replace the ith number with 0.
As code is circular, the next element of code[n-1] is code[0], and the previous element of code[0] is code[n-1].

Given the circular array code and an integer key k, return the decrypted code to defuse the bomb!

 

Example 1:

Input: code = [5,7,1,4], k = 3
Output: [12,10,16,13]
Explanation: Each number is replaced by the sum of the next 3 numbers. The decrypted code is [7+1+4, 1+4+5, 4+5+7, 5+7+1]. Notice that the numbers wrap around.
Example 2:

Input: code = [1,2,3,4], k = 0
Output: [0,0,0,0]
Explanation: When k is zero, the numbers are replaced by 0. 
Example 3:

Input: code = [2,4,9,3], k = -2
Output: [12,5,6,13]
Explanation: The decrypted code is [3+9, 2+3, 4+2, 9+4]. Notice that the numbers wrap around again. If k is negative, the sum is of the previous numbers.
     */

    public class Solution
    {
        //TC: O(n*k) where n is the length of the code array and k is the key. In the worst case, when k is equal to n-1, we need to sum up n-1 elements for each of the n elements in the code array, resulting in O(n*(n-1)) which simplifies to O(n^2).
        //SC: O(n) for the newCode array that stores the decrypted code. The space complexity is linear with respect to the length of the input code array.

        //public int[] Decrypt(int[] code, int k)
        //{
        //    int n = code.Length;
        //    int[] newCode = new int[n];

        //    if (k == 0)
        //    {
        //        return newCode;
        //    }
        //    for (int i = 0; i < n; i++)
        //    {
        //        if (k < 0)
        //        {
        //            for (int j = i - Math.Abs(k); j < i; j++)
        //            {
        //                newCode[i] += code[(j + n) % n];
        //            }
        //        }
        //        else
        //        {
        //            for (int j = i + 1; j <= i + k; j++)
        //            {
        //                newCode[i] += code[j % n];
        //            }
        //        }
        //    }
        //    return newCode;
        //}

        //Optimized with sliding window
        //TC: O(n) where n is the length of the code array. We iterate through the code array once to calculate the decrypted values using a sliding window approach, resulting in linear time complexity.
        //SC: O(n) for the newCode array that stores the decrypted code. The space complexity is linear with respect to the length of the input code array.
        public int[] Decrypt(int[] code, int k)
        {
            int n = code.Length;
            int[] newCode = new int[n];

            if (k == 0)
            {
                return newCode;
            }

            int i = -1;//start index
            int j = -1; //end index

            if (k > 0)
            {
                i = 1;
                j = k;//this is for first window
            }
            else
            {
                i = n - Math.Abs(k);//this is for first window
                j = n - 1;//this is for first window
            }

            int zeroindexval = 0;//this is for first window

            for(int pointer = i; pointer <= j; pointer++)
            {
                zeroindexval += code[pointer];//calculate the sum of first window
            }

            for (int p = 0; p < n; p++)
            {
                newCode[p] = zeroindexval;//assign the sum of current window to the decrypted code at index p

                zeroindexval -= code[i %n];//remove the first element of the current window
                i++;

                zeroindexval += code[(j + 1) % n];//add the next element of the current window
                j++;
            }
            return newCode;
        }

    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] code = { 5, 7, 1, 4 };
            int k = 3;
            var res = s.Decrypt(code, k);
            for (int i = 0; i < res.Length; i++)
            {
                Console.WriteLine(res[i]);
            }
        }
    }
}