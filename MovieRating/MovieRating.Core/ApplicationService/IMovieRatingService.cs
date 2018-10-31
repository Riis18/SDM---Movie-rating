using System.Collections.Generic;
using MovieRating.Core.Entities;

namespace MovieRating.Core.ApplicationService
{
    public interface IMovieRatingService
    {
        //1
        int GetReviewsFromReviewer(int input);

        //2
        double GetAverageRateFromReviewers(int input);

        //3
        int GetGradesFromReviewer(int input1, int input2);

        //4
        int GetMovieReviewNumbers(int input);

        //5
        double GetAverageMovieGrade(int input);

        //6
        int GetGradeFromMovie(int input1, int input2);

        //7
        List<int> GetMovieWithHighestRate();
        
        //8
        List<int> GetReviewerWithMostReviews();
        
        //9
        List<int> GetMovieByRatedScore(int input);
        
        //10
        List<MovieRatings> GetMoviesReviewedByReviewer(int input);
        
        //11
        List<MovieRatings> GetReviewersForMovie(int input);

    }
}