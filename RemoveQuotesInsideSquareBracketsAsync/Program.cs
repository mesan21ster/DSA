namespace RemoveQuotesInsideSquareBracketsAsync
{
    using System;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    class Program
    {
        static async Task Main()
        {
            string input = "EVALUATE CALCULATETABLE ( SELECTCOLUMNS ( Employee, \"EmployeeName\", Employee[\"Full Name\"], \"CostCenter\", Employee[\"Company Code\"] ), Employee[Email] = \"ajrai\" )";
            string output = await RemoveQuotesInsideSquareBracketsAsync(input);
            Console.WriteLine(output);
        }

        static async Task<string> RemoveQuotesInsideSquareBracketsAsync(string input)
        {
            return await Task.Run(() =>
            {
                string pattern = @"\[([^\]]*)\]";
                MatchCollection matches = Regex.Matches(input, pattern);

                foreach (Match match in matches)
                {
                    string insideBrackets = match.Groups[1].Value;
                    string replacedInsideBrackets = insideBrackets.Replace("\"", string.Empty);
                    string replacedBrackets = $"[{replacedInsideBrackets}]";
                    input = input.Replace(match.Value, replacedBrackets);
                }

                return input;
            });
        }
    }

}