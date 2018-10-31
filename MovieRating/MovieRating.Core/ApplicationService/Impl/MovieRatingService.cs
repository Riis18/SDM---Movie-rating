using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        //4
        public int GetMovieReviewNumbers(int input)
        {
            return _jsonReader.ratings.Where(m => m.Movie == input).Count();
        }

        //5
        public double GetAverageMovieGrade(int input)
        {
            return _jsonReader.ratings.Where(m => m.Movie == input).Average(m => m.Grade);
        }

        //6
        public int GetGradeFromMovie(int input1, int input2)
        {
            return _jsonReader.ratings.Where(m => m.Movie == input1 && m.Grade == input2).Count();
        }

        //7
        public List<int> GetMovieWithHighestRate()
        {
            var maxValue = _jsonReader.ratings.Where(m => m.Grade == 5).GroupBy(m => m.Movie).Max(r => r.Count());
            return _jsonReader.ratings.Where(m => m.Grade == 5).GroupBy(m => m.Movie).Where(r => r.Count() == maxValue)
                .Select(k => k.Key).ToList();
        }
    }
}
