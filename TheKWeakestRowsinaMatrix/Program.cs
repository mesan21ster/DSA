using System;
using System.Linq;

namespace TheKWeakestRowsinaMatrix
{
    public class Solution
    {
        public int[] KWeakestRows(int[][] mat, int k)
        {
            int m = mat.Length;
            int n = mat[0].Length;
            Dictionary<int, int> countOnes = new Dictionary<int, int>();
            for (int row = 0; row < m; row++)
            {
                int count_ofOnes = binarySearch(mat[row], 0, n - 1);
                if (!countOnes.ContainsKey(row))
                {
                    countOnes.Add(row, count_ofOnes);
                }
                else
                {
                    int val  = countOnes[row];
                    countOnes[row] = Math.Min(val, row);
                    
                }
            }

            Dictionary<int, int> sortedDic = countOnes.OrderBy(x => x.Value)
             .ToDictionary(x => x.Key, x => x.Value);

            int[] kList = new int[k];
            int c = 0;
            foreach (var item in sortedDic)
            {
                if (c >= k) break;

                kList[c++] = item.Key;
            }
            return kList;


        }
        private int binarySearch(int[] mat, int l, int r)
        {
            int result = -1;

            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (mat[mid] == 1)
                {
                    result = mid;
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }
            return result + 1;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[][] mat =
             {
                new int[] { 1, 1, 0, 0, 0 },
                new int[] { 1, 1, 1, 1, 0 },
                new int[] { 1, 0, 0, 0, 0 },
                new int[] { 1, 1, 0, 0, 0 },
                new int[] { 1, 1, 1, 1, 1 }
            };
            int k = 3;

            var res = solution.KWeakestRows(mat, k);

            for (int i = 0; i < res.Length; i++)
            {
                Console.WriteLine(res[i]);
            }
            Console.ReadLine();
        }
    }

}