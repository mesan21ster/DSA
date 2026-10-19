using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CSVparsing_SystmeDesing_Coding
{
    public class MovieCatalog : IMovieCatalog
    {
        private readonly List<Movie> _movies;
        private readonly Dictionary<string, List<Movie>> _genreIndex;
        private readonly SortedDictionary<string, List<Movie>> _titleIndex;
        public MovieCatalog(List<Movie> movies, Dictionary<string, List<Movie>> genreIndex, SortedDictionary<string, List<Movie>> titleIndex)
        {
            _movies = movies;
            _genreIndex = genreIndex;
            _titleIndex = titleIndex;
        }

        public IReadOnlyList<Movie> GetAll() => _movies;
        /// <summary>
        /// Retrieves a list of movies released within the specified year range and matching the given genre.
        /// </summary>
        /// <remarks>If the specified genre does not exist, is empty, or if the start year is greater than
        /// the end year, the method returns an empty list. The returned list is a snapshot and will not reflect
        /// subsequent changes to the underlying data.</remarks>
        /// <param name="startReleaseYear">The first year of the release date range. Only movies released on or after this year are included.</param>
        /// <param name="endReleaseYear">The last year of the release date range. Only movies released on or before this year are included.</param>
        /// <param name="genre">The genre to filter movies by. This value is case-sensitive and cannot be null, empty, or whitespace.</param>
        /// <returns>A read-only list of movies that match the specified genre and were released between the given years,
        /// inclusive. Returns an empty list if no movies match the criteria.</returns>
        public IReadOnlyList<Movie> GetMovie(int startReleaseYear, int endReleaseYear, string genre)
        {
            if(string.IsNullOrWhiteSpace(genre)) return Array.Empty<Movie>();
            if(startReleaseYear > endReleaseYear) return Array.Empty<Movie>();
            if(!_genreIndex.TryGetValue(genre, out var moviesInGenre) || moviesInGenre.Count == 0) return Array.Empty<Movie>();
            
            int left = LowerBoundByYear(moviesInGenre, startReleaseYear);
            int right = UpperBoundByYear(moviesInGenre, endReleaseYear);
            
            if(left >= right) return Array.Empty<Movie>();
            
            //return slice of moviesInGenre from left to right (exclusive)

            var result = new List<Movie>(right - left);// Pre-allocate the list with the expected size for better performance
            for (int i = left; i < right; i++)
            {
                result.Add(moviesInGenre[i]);
            }
            return result;
        }
        /// <summary>
        /// Retrieves a list of movies released within the specified year range that belong to all of the provided
        /// genres.
        /// </summary>
        /// <remarks>If any genre in the provided collection does not exist or has no associated movies,
        /// the result will be an empty list. The returned list is read-only and may be empty if no movies meet the
        /// criteria.</remarks>
        /// <param name="startReleaseYear">The inclusive lower bound of the release year range. Only movies released in or after this year are
        /// considered.</param>
        /// <param name="endReleaseYear">The inclusive upper bound of the release year range. Only movies released in or before this year are
        /// considered.</param>
        /// <param name="genres">A collection of genre names. Only movies that belong to all specified genres are included. Cannot be null.</param>
        /// <returns>A read-only list of movies that match all specified genres and fall within the given release year range.
        /// Returns an empty list if no movies match or if the genres parameter is null or contains genres with no
        /// movies.</returns>
        public IReadOnlyList<Movie> GetMovie(int startReleaseYear, int endReleaseYear, IEnumerable<string> genres)
        {
            if (genres == null) return Array.Empty<Movie>();

            List<Movie>? result = null;

            foreach(var gen in genres)
            {
                if (!_genreIndex.TryGetValue(gen, out var moviesForGenre) || moviesForGenre.Count == 0) return Array.Empty<Movie>(); //AND semantics, missing genre fails
                
                //Apply year filter using binary search
                int left = LowerBoundByYear(moviesForGenre, startReleaseYear);
                int right = UpperBoundByYear(moviesForGenre, endReleaseYear);

                var filtered = moviesForGenre.GetRange(left, right - left);//get filtered data from 
                if(result == null)
                {
                    result = filtered;
                }
                else
                {
                    result = result.Intersect(filtered).ToList();
                }
            }
            
            return result != null ? result : Array.Empty<Movie>();
        }
        public IReadOnlyList<Movie> GetMovies(int startReleaseYear, int endReleaseYear, IEnumerable<string> genres)
        {
            if (genres == null) return Array.Empty<Movie>();
            List<Movie> result = new List<Movie>();
            foreach(var genre in genres)
            {
                if (!_genreIndex.TryGetValue(genre, out var lstMovie) || lstMovie.Count == 0) continue; // OR semantics skip if missing 
                int left = LowerBoundByYear(lstMovie, startReleaseYear);
                int right = UpperBoundByYear(lstMovie, endReleaseYear);
                for(int i = left; i < right; i++)
                {
                    result.Add(lstMovie[i]);
                }
            }
            return result;
        }

        /// <summary>
        /// Retrieves a read-only list of movies whose titles begin with the specified prefix, using a case-insensitive
        /// comparison.
        /// </summary>
        /// <remarks>This method performs a case-insensitive search and returns results in order by title.
        /// The operation is optimized for prefix lookups and is efficient even with large collections.</remarks>
        /// <param name="prefix">The prefix to match at the start of movie titles. Comparison is case-insensitive. If null, empty, or
        /// whitespace, no movies are returned.</param>
        /// <returns>A read-only list of movies whose titles start with the specified prefix. The list is empty if no matching
        /// movies are found.</returns>
        public IReadOnlyList<Movie> GetByTitlePrefix(string prefix)
        {
            if (string.IsNullOrWhiteSpace(prefix))
                return Array.Empty<Movie>();

            string start = prefix;
            string end = prefix + Char.MaxValue;

            var result = new List<Movie>();
            foreach(var kvp in _titleIndex)
            {
                if (StringComparer.OrdinalIgnoreCase.Compare(kvp.Key, start) < 0)
                    continue;
                if (StringComparer.OrdinalIgnoreCase.Compare(kvp.Key, end) > 0)
                    break;

                result.AddRange(kvp.Value);
            }
            return result; //O(log N + K) //(tree seek + matches)
        }
        /// <summary>
        /// Retrieves a read-only list of movies released within the specified year range, matching the given genre and
        /// whose titles start with the specified prefix.
        /// </summary>
        /// <remarks>The search for the title prefix is case-insensitive. If no movies match the genre or
        /// year range, an empty list is returned regardless of the title prefix.</remarks>
        /// <param name="startReleaseYear">The first year in the release year range. Only movies released in or after this year are included.</param>
        /// <param name="endReleaseYear">The last year in the release year range. Only movies released in or before this year are included.</param>
        /// <param name="genre">The genre to filter movies by. Only movies matching this genre are included. Cannot be null or empty.</param>
        /// <param name="titlePrefix">The prefix to filter movie titles by. If null, empty, or whitespace, all movies matching the other criteria
        /// are returned.</param>
        /// <returns>A read-only list of movies that match the specified release year range, genre, and title prefix. The list is
        /// empty if no movies meet the criteria.</returns>
        public IReadOnlyList<Movie> GetMovie(int startReleaseYear, int endReleaseYear, string genre, string titlePrefix)
        {
            var byGenre = GetMovie(startReleaseYear, endReleaseYear, genre);
            if(byGenre.Count == 0)
            {
                return byGenre;
            }

            if (string.IsNullOrWhiteSpace(titlePrefix))
            {
                return byGenre;
            }
            return byGenre.Where(m => m.Title.StartsWith(titlePrefix, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        private int UpperBoundByYear(List<Movie> moviesInGenre, int endReleaseYear)
        {
            int lo = 0;
            int hi = moviesInGenre.Count;
            while(lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (moviesInGenre[mid].ReleaseYear <= endReleaseYear)// If the mid movie's release year is less than or equal to the end year, we need to search in the right half (including mid)
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid;// If the mid movie's release year is greater than the end year, we can search in the left half (including mid)
                }
            }
            return lo;
        }
        private int LowerBoundByYear(List<Movie> moviesInGenre, int startReleaseYear)
        {
            // Binary search to find the first index where movie's release year is >= startReleaseYear
            int lo = 0;
            int hi = moviesInGenre.Count;
            while(lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (moviesInGenre[mid].ReleaseYear < startReleaseYear) // If the mid movie's release year is less than the start year, we need to search in the right half
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid;// If the mid movie's release year is greater than or equal to the start year, we can search in the left half (including mid)
                }
            }
            return lo;
        }
    }
}
