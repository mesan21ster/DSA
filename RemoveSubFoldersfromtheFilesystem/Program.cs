namespace RemoveSubFoldersfromtheFilesystem
{
    public class Solution
    {
        public IList<string> RemoveSubfolders(string[] folder)
        {
            HashSet<string> result = [.. folder];
            List<string> list = new List<string>();

            foreach (string subfolder in folder)
            {
                bool find = false;
                string sfolder = subfolder;
                while (!string.IsNullOrEmpty(sfolder))
                {
                    
                    int lastindexofslash = sfolder.LastIndexOf('/');
                    sfolder = sfolder.Substring(0, lastindexofslash);

                    if (result.Contains(sfolder))
                    {
                        find = true;
                        break;
                    }
                }
                if (!find)
                {
                    list.Add(subfolder);
                }
            }
            return list;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            string[] folder = { "/a", "/a/b/c", "/a/b/d" };//{ "/a", "/a/b", "/c/d", "/c/d/e", "/c/f" };
            Solution solution = new Solution();

            var res = solution.RemoveSubfolders(folder);
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}