using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FilesAndObjects
{
    class Program
    {

        class Movie
        {
            public string title;
            public string rating;
            public string year;

            public Movie(string _title, string _rating, string _year)
            {
                title = _title;
                rating = _title;
                year = _year;
            }
        }

        static void Main(string[] args)
        {
            string filePath = @"C:\Users\opilane\Samples";
            string fileName = @"C:\Users\opilane\Samples\imdb.txt";
            List<string> movieList = File.ReadAllLines(Path.Combine(filePath, fileName)).ToList();
            List<Movie> listOfMovie = new List<Movie>();

            foreach (string movieItem in movieList)
            {
                string[] Temparray = movieItem.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                Movie newMovie = new Movie(Temparray[0], Temparray[1], Temparray[2]);

                listOfMovie.Add(newMovie);
                
            }

            foreach (Movie movie in listOfMovie)
            {
                Console.WriteLine($"Title: {movie.title}");
                Console.WriteLine($"Rating: {movie.rating}");
                Console.WriteLine($"Year: {movie.year}");
            }

            Console.WriteLine("What's your favorite movie? Enter the title: ");
            string favMovieTitle = Console.ReadLine();
            Console.WriteLine("Enter your favorite movie rating: ");
            string favMovieRating = Console.ReadLine();
            Console.WriteLine("Enter your favorite movie year: ");
            string favMovieYear = Console.ReadLine();

            Movie favMovie = new Movie(favMovieTitle, favMovieRating, favMovieYear);
            string favMovieLine = $"{favMovie.title};{favMovie.rating};{favMovieYear}";

            movieList.Add(favMovieLine);
            File.WriteAllLines(Path.Combine(filePath, fileName), movieList);
        }
    }
}
