using MovieRating.Infrastructure.Data;
using System;
using System.Collections.Generic;
using MovieRating.Core.ApplicationService;
using MovieRating.Core.ApplicationService.Impl;
using Xunit;

namespace MovieRatingTest
{
    public class MovieRatingServiceTest
    {
        private IMovieRatingService movieRR = new MovieRatingService(new JsonRead("TestRatings.json"));

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

        //4
        [Theory]
        [InlineData(10, 2)]
        [InlineData(12, 3)]
        [InlineData(8, 2)]
        [InlineData(3, 1)]
        public void NumberMovieReviewed(int input, int result)
        {
            int movieReviewed = movieRR.GetMovieReviewNumbers(input);
            Assert.Equal(result, movieReviewed);
        }

        //5
        [Theory]
        [InlineData(10, 3)]
        [InlineData(12, 4)]
        [InlineData(11, 4)]
        [InlineData(7, 3.5)]
        public void AverageGradeFromMovie(int input, double result)
        {
            double averageMovieGrade = movieRR.GetAverageMovieGrade(input);
            Assert.Equal(result, averageMovieGrade);
        }

        //6
        [Theory]
        [InlineData(10, 3, 2)]
        [InlineData(12, 4, 3)]
        [InlineData(7, 4, 1)]
        [InlineData(6, 5, 0)]
        public void MovieGivenCertainGrade(int input1, int input2, int result)
        {
            int movieGrade = movieRR.GetGradeFromMovie(input1, input2);
            Assert.Equal(result, movieGrade);
        }

        //7
        [Fact]
        //[InlineData(16)]
        //[InlineData(49)]
        public void MovieIdByHighestRate()
        {
            List<int> result = new List<int>()
            {
                16,
                49
            };
            List<int> highestRate = movieRR.GetMovieWithHighestRate();
            Assert.Equal(result, highestRate);
        }
    }
}
