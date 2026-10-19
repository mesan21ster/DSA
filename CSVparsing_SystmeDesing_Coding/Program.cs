using CSVparsing_SystmeDesing_Coding;

public static class Program
{
    public static void Main()
    {
        // Example usage:


        var csv = @"MovieId,Title,ReleaseYear,Genre
101,The Matrix,1999,Action|Sci-Fi
102,""Toy Story, Special Edition"",1995,Adventure|Animation|Comedy
103,Inception,2010,Action|Sci-Fi|Thriller
";

        var loader = new CsvMovieCatalogLoader();
//        using var stream = File.OpenRead("movies.csv");
        using var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(csv));
        var catalog = loader.Load(stream);
        var movies = catalog.GetMovie(1990, 2020,new string[] { "Sci-Fi", "Thriller" });
        foreach (var movie in movies)
        {
            Console.WriteLine(movie);
        }
    }
}