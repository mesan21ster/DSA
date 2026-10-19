using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace CSVparsing_SystmeDesing_Coding
{
    public class CsvMovieCatalogLoader : IMovieCatalogLoader
    {
        /// <summary>
        /// Loads a movie catalog from a CSV stream containing movie data.
        /// </summary>
        /// <remarks>The CSV stream is expected to have a header row followed by rows representing movies.
        /// Each row should include at least the movie ID, title, release year, and genres. The method does not close
        /// the provided stream.</remarks>
        /// <param name="csvStream">The stream containing CSV-formatted movie data. The stream must be readable and positioned at the start of
        /// the CSV content.</param>
        /// <returns>An <see cref="IMovieCatalog"/> instance containing the movies parsed from the CSV stream.</returns>
        public IMovieCatalog Load(Stream csvStream)
        {
            List<Movie> movies = new List<Movie>();
            using var reader = new StreamReader(csvStream, Encoding.UTF8, leaveOpen:true);
            using var parser = new TextFieldParser(reader)
            {
                TextFieldType = FieldType.Delimited,
                Delimiters = new[] { "," },
                HasFieldsEnclosedInQuotes = true,
                TrimWhiteSpace = true
            };
            //skip header
            if (!parser.EndOfData)
            {
                parser.ReadFields();
            }

            //TODO: implement parsing logic to read movies from the CSV and return an IMovieCatalog instance
            while (!parser.EndOfData)
            {
                var fields = parser.ReadFields();
                // Example of expected fields: MovieId, Title, ReleaseYear, Genre, Director, etc.
                // You would need to parse these fields and create Movie objects, then add them to a collection that implements IMovieCatalog
                if (fields == null || fields.Length < 4) continue;
                if (!int.TryParse(fields[0], out int id)) continue;
                string title = (fields[1] ?? "").Trim();
                if (!int.TryParse(fields[2], out int year)) continue;

                var genres = ParseGenres(fields[3]);
                movies.Add(new Movie
                {
                    MovieId = id,
                    Title = title,
                    ReleaseYear = year,
                    Genres = genres
                });
            }
            var genreIndex = BuildGenreIndex(movies);
            var titleIndex = BuildTitleIndex(movies);
            return new MovieCatalog(movies, genreIndex,titleIndex);
        }
        /// <summary>
        /// This is a | seperated field 
        /// </summary>
        /// <param name="genreField"></param>
        /// <returns></returns>
        private HashSet<string> ParseGenres(string genreField)
        {
            HashSet<string> set = new HashSet<string>(StringComparer.OrdinalIgnoreCase);//enforce case rules to ignore so that onely one item will be there for duplicate case sentitive genre
            if (string.IsNullOrWhiteSpace(genreField)) return set;

            foreach(var item in genreField.Split('|', StringSplitOptions.RemoveEmptyEntries))
            {
                var cleaned = item.Trim();
                if(cleaned.Length > 0)
                {
                    set.Add(cleaned);
                }
            }
            return set;
        }
        
        /// <summary>
        /// build index of moview 
        /// </summary>
        /// <param name="movies"></param>
        /// <returns></returns>
        private Dictionary<string,List<Movie>> BuildGenreIndex(List<Movie> movies)
        {
            Dictionary<string, List<Movie>> index = new Dictionary<string, List<Movie>>(StringComparer.OrdinalIgnoreCase);
            foreach(var movie in movies)
            {
                foreach(var genre in movie.Genres)
                {
                    if(!index.TryGetValue(genre,out var list))
                    {
                        list = new List<Movie>();
                        index[genre] = list;
                    }
                    list.Add(movie);
                }
            }
            //sort for binary search by year

            foreach(var kvp in index)
            {
                kvp.Value.Sort((a, b) =>
                {
                    int c = a.ReleaseYear.CompareTo(b.ReleaseYear);
                    if (c != 0) return c;
                    c = StringComparer.Ordinal.Compare(a.Title, b.Title);
                    if (c != 0) return c;
                    return a.MovieId.CompareTo(b.MovieId);
                });
            }
            return index;
        }

        private SortedDictionary<string, List<Movie>> BuildTitleIndex(List<Movie> movies)
        {
            var index = new SortedDictionary<string, List<Movie>>(StringComparer.OrdinalIgnoreCase);

            foreach(var movie in movies)
            {
                if(!index.TryGetValue(movie.Title,out var lst))
                {
                    lst = new List<Movie>();
                    index[movie.Title] = lst;
                }
                lst.Add(movie);
            }
            return index;
        }
    }
}
