using MovieRating.Infrastructure.Data;
using System;
using Xunit;

namespace MovieRatingTest
{
    public class MovieRatingServiceTest
    {
        private MovieRatingRepository movieRR = new MovieRatingRepository(new JsonRead("TestRatings.json"));

        //1
        [Theory]
        [InlineData(1, 5)]
        [InlineData(2, 5)]
        [InlineData(3, 5)]
        [InlineData(4, 5)]
        public void NumberReviewsFromReviewer(int input, int result)
        {
            int reviewsFromReviewer = movieRR.GetReviewsFromReviewer(input);
            Assert.Equal(result, reviewsFromReviewer);
        }
    }
}
