using System;

namespace MovieRating.Core.Entities
{
    public class MovieRatings
    {
        public int Reviewer { get; set; }
        public int Movie { get; set; }
        public int Grade { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return string.Format("Reviewer: {0}\nMovie: {1}\nGrade: {2}\nDate: {3}\n", Reviewer, Movie, Grade, Date);
        }
    }
}
