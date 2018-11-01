using MovieRating.Core.ApplicationService;
using MovieRating.Core.ApplicationService.Impl;
using MovieRating.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace MovieRatingTest
{
    public class PerformanceTest
    {
        private IMovieRatingService movieRR;
        int maxTime = 4000;
        Boolean time = false;

        public PerformanceTest()
        {
            movieRR = new MovieRatingService(new JsonRead("ratings.json"));
        }

        //1
        [Fact]
        public void PerfNumberReviewsFromReviewer()
        {
            
            Stopwatch sw = Stopwatch.StartNew();
            int reviewer = 10;
            movieRR.GetReviewsFromReviewer(reviewer);
            sw.Stop();
            if (sw.ElapsedMilliseconds < maxTime)
            {
                time = true;
            }
            Assert.True(time);
        }

        //2
        [Fact]
        public void PerfAverageRateFromReviewer()
        {
            Stopwatch sw = Stopwatch.StartNew();
            int reviewer = 10;
            movieRR.GetAverageRateFromReviewers(reviewer);
            sw.Stop();
            if (sw.ElapsedMilliseconds < maxTime)
            {
                time = true;
            }
            Assert.True(time);
        }

        //3
        [Fact]
        public void PerfReviewerGivenCertainGrade()
        {
            Stopwatch sw = Stopwatch.StartNew();
            int reviewer = 10;
            int grade = 3;
            movieRR.GetGradesFromReviewer(reviewer, grade);
            sw.Stop();
            if (sw.ElapsedMilliseconds < maxTime)
            {
                time = true;
            }
            Assert.True(time);
        }

        //4
        [Fact]
        public void PerfNumberMovieReviewed()
        {
            Stopwatch sw = Stopwatch.StartNew();
            int movie = 10;
            movieRR.GetMovieReviewNumbers(movie);
            sw.Stop();
            if (sw.ElapsedMilliseconds < maxTime)
            {
                time = true;
            }
            Assert.True(time);
        }

        //5
        [Fact]
        public void PerfAverageGradeFromMovie()
        {
            Stopwatch sw = Stopwatch.StartNew();
            int movie = 10;
            movieRR.GetAverageMovieGrade(movie);
            sw.Stop();
            if (sw.ElapsedMilliseconds < maxTime)
            {
                time = true;
            }
            Assert.True(time);
        }

        //6
        [Fact]
        public void PerfMovieGivenCertainGrade()
        {
            Stopwatch sw = Stopwatch.StartNew();
            int movie = 10;
            int grade = 3;
            movieRR.GetGradeFromMovie(movie, grade);
            sw.Stop();
            if (sw.ElapsedMilliseconds < maxTime)
            {
                time = true;
            }
            Assert.True(time);
        }

        //7
        [Fact]
        public void PerfMovieIdByHighestRate()
        {
            Stopwatch sw = Stopwatch.StartNew();
            movieRR.GetMovieWithHighestRate();
            sw.Stop();
            if (sw.ElapsedMilliseconds < maxTime)
            {
                time = true;
            }
            Assert.True(time);
        }

        //8
        [Fact]
        public void PerfReviewerWithMostReviews()
        {
            Stopwatch sw = Stopwatch.StartNew();
            movieRR.GetReviewerWithMostReviews();
            sw.Stop();
            if (sw.ElapsedMilliseconds < maxTime)
            {
                time = true;
            }
            Assert.True(time);
        }

        //9
        [Fact]
        public void PerfTopMoviesWithScore()
        {
            Stopwatch sw = Stopwatch.StartNew();
            int topList = 10;
            movieRR.GetMovieByRatedScore(topList);
            sw.Stop();
            if (sw.ElapsedMilliseconds < maxTime)
            {
                time = true;
            }
            Assert.True(time);
        }

        //10
        [Fact]
        public void PerfMovieReviewedByReviewer()
        {
            Stopwatch sw = Stopwatch.StartNew();
            int reviewer = 10;
            movieRR.GetMoviesReviewedByReviewer(reviewer);
            sw.Stop();
            if (sw.ElapsedMilliseconds < maxTime)
            {
                time = true;
            }
            Assert.True(time);
        }

        //11
        [Fact]
        public void PerfReviewersForMovie()
        {
            Stopwatch sw = Stopwatch.StartNew();
            int movie = 10;
            movieRR.GetReviewersForMovie(movie);
            sw.Stop();
            if (sw.ElapsedMilliseconds < maxTime)
            {
                time = true;
            }
            Assert.True(time);
        }
    }
}
