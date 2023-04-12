namespace SimplifyPath
{
    public class Solution
    {
        //Time O(N)
        //space O(N)
        public string SimplifyPath(string path)
        {
            Stack<string> stack = new Stack<string>();
            string[] paths = path.Split('/',StringSplitOptions.RemoveEmptyEntries);
            foreach (var p in paths)
            {
                if(p == "/" || p== ".")
                {
                    continue;
                }
                else if(p == "..")
                {
                    if (stack.Any())
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    stack.Push(p);
                }
            }
            string[] arr = stack.ToArray();
            Array.Reverse(arr);
            return "/" + string.Join("/", arr);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            string path = "/home/";
            Console.WriteLine(solution.SimplifyPath(path));
            Console.ReadLine();
        }
    }
}