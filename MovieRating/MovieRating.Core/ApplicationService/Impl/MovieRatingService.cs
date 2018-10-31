using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieRating.Core.Entities;
using MovieRating.Infrastructure.Data;

namespace MovieRating.Core.ApplicationService.Impl
{
    public class MovieRatingService : IMovieRatingService
    {
        
        private JsonRead _jsonReader;

        public MovieRatingService(JsonRead jsonReader)
        {
            _jsonReader = jsonReader;
        }
        
        //1
        public int GetReviewsFromReviewer(int input)
        {
            return _jsonReader.ratings.Count(r => r.Reviewer == input);
        }

        //2
        public double GetAverageRateFromReviewers(int input)
        {
            return _jsonReader.ratings.Where(r => r.Reviewer == input).Average(r => r.Grade);
        }

        //3
        public int GetGradesFromReviewer(int input1, int input2)
        {
            return _jsonReader.ratings.Count(r => r.Reviewer == input1 && r.Grade == input2);
        }

        //4
        public int GetMovieReviewNumbers(int input)
        {
            return _jsonReader.ratings.Count(m => m.Movie == input);
        }

        //5
        public double GetAverageMovieGrade(int input)
        {
            return _jsonReader.ratings.Where(m => m.Movie == input).Average(m => m.Grade);
        }

        //6
        public int GetGradeFromMovie(int input1, int input2)
        {
            return _jsonReader.ratings.Count(m => m.Movie == input1 && m.Grade == input2);
        }

        //7
        public List<int> GetMovieWithHighestRate()
        {
            var maxValue = _jsonReader.ratings.Where(m => m.Grade == 5).GroupBy(m => m.Movie).Max(r => r.Count());
            return _jsonReader.ratings.Where(m => m.Grade == 5).GroupBy(m => m.Movie).Where(r => r.Count() == maxValue)
                .Select(k => k.Key).ToList();
        }

        //8
        public List<int> GetReviewerWithMostReviews()
        {
            var maxValue = _jsonReader.ratings.GroupBy(r => r.Reviewer).Max(r => r.Count());
            return _jsonReader.ratings.GroupBy(r => r.Reviewer).Where(r => r.Count() == maxValue).Select(k => k.Key)
                .ToList();
        }

        //9
        public List<int> GetMovieByRatedScore(int input)
        {
            return _jsonReader.ratings.GroupBy(m => m.Movie).OrderByDescending(d => d.Average(r => r.Grade)).Take(input)
                .Select(d => d.Key).ToList();
        }

        //10
        public List<MovieRatings> GetMoviesReviewedByReviewer(int input)
        {
            return _jsonReader.ratings.Where(r => r.Reviewer == input).OrderByDescending(m => m.Grade)
                .ThenByDescending(m => m.Date).ToList();
        }

        //11
        public List<MovieRatings> GetReviewersForMovie(int input)
        {
            return _jsonReader.ratings.Where(m => m.Movie == input).OrderByDescending(r => r.Grade)
                .ThenByDescending(r => r.Date).ToList();
        }
    }
}
