using System;
using System.Collections.Generic;
using System.Text;

namespace CSVparsing_SystmeDesing_Coding
{
    /// <summary>
    /// Represents a movie with an identifier, title, release year, and associated genres.
    /// </summary>
    /// <remarks>Instances of this class are immutable after creation. All properties can only be set during
    /// object initialization and cannot be modified afterward. This makes the type suitable for use as a data transfer
    /// object or in scenarios where immutability is required.</remarks>
    public sealed class Movie
    {
        public int MovieId { get; init; }//only when creating the object we can set the value of MovieId, after that it becomes immutable
        public string Title { get; init; } = "";//same as above, we can set the value of Title only when creating the object, after that it becomes immutable
        public int ReleaseYear { get; init; }//same as above, we can set the value of ReleaseYear only when creating the object, after that it becomes immutable
        public HashSet<string> Genres { get; init; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);//same as above, we can set the value of Genres only when creating the object, after that it becomes immutable
        public override string ToString()
        {
            return $"MovieId: {MovieId}, Title: {Title}, ReleaseYear: {ReleaseYear}, Genres: {string.Join("|", Genres)}";
        }
    }
}
