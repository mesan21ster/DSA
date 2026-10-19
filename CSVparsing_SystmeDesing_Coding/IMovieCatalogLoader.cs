using System;
using System.Collections.Generic;
using System.Text;

namespace CSVparsing_SystmeDesing_Coding
{
    public interface IMovieCatalogLoader
    {
        IMovieCatalog Load(Stream csvStream);
    }
    public interface IMovieCatalog
    {
        IReadOnlyList<Movie> GetMovie(int startReleaseYear, int endReleaseYear, string genre);
        IReadOnlyList<Movie> GetMovie(int startReleaseYear, int endReleaseYear, string genre,string titlePrefix);
        IReadOnlyList<Movie> GetMovie(int startReleaseYear, int endReleaseYear, IEnumerable<string> genres);//for AND semantic
        IReadOnlyList<Movie> GetMovies(int startReleaseYear, int endReleaseYear, IEnumerable<string> genres); // for OR semantic
        IReadOnlyList<Movie> GetAll();//optional for debuging / test, this is not a requirement 
        IReadOnlyList<Movie> GetByTitlePrefix(string prefix);
    }

}
