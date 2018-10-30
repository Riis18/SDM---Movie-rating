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
    }
}
