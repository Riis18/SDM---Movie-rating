﻿using MovieRating.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        private const string FILE_NAME = "ratings.json";  // Change the path

        static void Main(string[] args)
        {
            List<MovieRatings> ratings = new List<MovieRatings>();

            Console.Write("Converting Json file to objects... ");

            Stopwatch sw = Stopwatch.StartNew();

            using (StreamReader streamReader = new StreamReader(FILE_NAME))
            using (JsonTextReader reader = new JsonTextReader(streamReader))
            {
                var serializer = new JsonSerializer();
                try
                {
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonToken.StartObject)
                        {
                            MovieRatings mr = ReadOneMovieRating(reader);
                            ratings.Add(mr);
                        }
                    }
                }
                catch (JsonReaderException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            sw.Stop();
            Console.WriteLine("Done. Time = {0:f4} sec.", sw.ElapsedMilliseconds / 1000d);

            Dictionary<int, List<MovieRatings>> Reviewers = new Dictionary<int, List<MovieRatings>>();
            Dictionary<int, List<MovieRatings>> Movies = new Dictionary<int, List<MovieRatings>>();

            Console.Write("Indexing MovieRatingss... ");
            sw.Restart();
            foreach (MovieRatings m in ratings)
            {
                if (!Reviewers.ContainsKey(m.Reviewer))
                    Reviewers[m.Reviewer] = new List<MovieRatings>();
                Reviewers[m.Reviewer].Add(m);

                if (!Movies.ContainsKey(m.Movie))
                    Movies[m.Movie] = new List<MovieRatings>();
                Movies[m.Movie].Add(m);
            }
            sw.Stop();
            Console.WriteLine("Done. Time = {0:f4} sec.", sw.ElapsedMilliseconds / 1000d);

            foreach (KeyValuePair<int, List<MovieRatings>> kv in Reviewers)
            {
                Console.WriteLine("Reviewer: {0,4} has reviewed {1,6} movies.", kv.Key, kv.Value.Count);
            }
        }

        private static MovieRatings ReadOneMovieRating(JsonTextReader reader)
        {
            MovieRatings m = new MovieRatings();
            for (int i = 0; i < 4; i++)
            {
                reader.Read();
                switch (reader.Value)
                {
                    case "Reviewer": m.Reviewer = (int)reader.ReadAsInt32(); break;
                    case "Movie": m.Movie = (int)reader.ReadAsInt32(); break;
                    case "Grade": m.Grade = (int)reader.ReadAsInt32(); break;
                    case "Date": m.Date = (DateTime)reader.ReadAsDateTime(); break;
                    default: throw new InvalidDataException("no such token: " + reader.Value);
                }
            }
            return m;
        }
    }
}
