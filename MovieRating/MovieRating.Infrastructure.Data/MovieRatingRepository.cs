using System;
using System.Linq;

namespace MovieRating.Infrastructure.Data
{
    public class MovieRatingRepository
    {
        private JsonRead _jsonReader;

        public MovieRatingRepository(JsonRead jsonReader)
        {
            _jsonReader = jsonReader;
        }

        //1
        public int GetReviewsFromReviewer(int input)
        {
            return _jsonReader.ratings.Where(r => r.Reviewer == input).Count();
        }

        //2
        public double GetAverageRateFromReviewers(int input)
        {
            return _jsonReader.ratings.Where(r => r.Reviewer == input).Average(r => r.Grade);
        }

        //3
        public int GetGradesFromReviewer(int input1, int input2)
        {
            return _jsonReader.ratings.Where(r => r.Reviewer == input1 && r.Grade == input2).Count();
        }
    }
}
