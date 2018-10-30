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

        //2
        [Theory]
        [InlineData(1, 3.8)]
        [InlineData(2, 3.4)]
        [InlineData(3, 3.8)]
        [InlineData(4, 4)]
        public void AverageRateFromReviewer(int input, double result)
        {
            double averageRate = movieRR.GetAverageRateFromReviewers(input);
            Assert.Equal(result, averageRate);
        }

        //3
        [Theory]
        [InlineData(1, 3, 2)]
        [InlineData(2, 3, 3)]
        [InlineData(3, 5, 1)]
        [InlineData(4, 4, 3)]
        public void ReviewerGivenCertainGrade(int input1, int input2, int result)
        {
            int givenGrade = movieRR.GetGradesFromReviewer(input1, input2);
            Assert.Equal(result, givenGrade);
        }

    }
}
