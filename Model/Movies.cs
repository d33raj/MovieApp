using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Model
{
    [Serializable]
    internal class Movies
    {
        
        public int MovieID { get; set; }
        public string MovieTitle { get; set; }
        public string MovieGenre { get; set; }
        public int MovieYear { get; set; }
        public Movies() { }

        public Movies( int movieId, string movieTitle , string movieGenre, int movieYear)
        {
            MovieID = movieId;
            MovieTitle = movieTitle;
            MovieGenre = movieGenre;
            MovieYear = movieYear;

        }

        public override string ToString()
        {
            return $">>>>>>>>>>>>>>>Movie Details<<<<<<<<<<<<<<<\n" +
                   $"Movie ID is: {MovieID}\n" +
                   $"Movie Name is: {MovieTitle}\n" +
                   $"Movie Genre is: {MovieGenre}\n" +
                   $"Movie Released Year is: {MovieYear}\n";
        }
    }
}
