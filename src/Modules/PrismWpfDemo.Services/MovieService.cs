using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using PrismWpfDemo.Business.Interfaces;
using PrismWpfDemo.Domain;

namespace PrismWpfDemo.Services
{
    public class MovieService : IMovieService
    {
        public void SaveMovie(Movie movie)
        {
            movie.LastUpdated = DateTime.Now;
#if DEBUG
            Console.WriteLine("Movie saved by MovieService...");
#endif
        }

        public IEnumerable<Movie> LoadMovies()
        {
#if DEBUG
            return new List<Movie>()
            {
                new Movie()
                {
                    Name = "The Great Wall",
                    Description = "Chinese/American Adventure",
                    Rating = 7,
                    Actors = new ObservableCollection<Actor>()
                    {
                        new Actor() { Name = "Andy Liu", Age = 55, Gender = "Male" },
                        new Actor() { Name = "Jin Tian", Age = 26, Gender = "Female" }
                    }
                },
                new Movie()
                {
                    Name = "Tom And Jerry",
                    Description = "American Cartoon",
                    Rating = 9,
                    Actors = new ObservableCollection<Actor>()
                    {
                        new Actor() { Name = "Tom", Age = 12, Gender = "Male" },
                        new Actor() { Name = "Jerry", Age = 8, Gender = "Male" }
                    }
                },
                new Movie()
                {
                    Name = "Hunting",
                    Description = "American Action",
                    Rating = 8,
                    Actors = new ObservableCollection<Actor>()
                    {
                        new Actor() { Name = "David", Age = 45, Gender = "Male" },
                        new Actor() { Name = "Julia", Age = 30, Gender = "Female" }
                    }
                },
                new Movie()
                {
                    Name = "Lord Of Ring",
                    Description = "American Adventure",
                    Rating = 10,
                    Actors = new ObservableCollection<Actor>()
                    {
                        new Actor() { Name = "Howard", Age = 31, Gender = "Male" },
                        new Actor() { Name = "Cristina", Age = 28, Gender = "Female" },
                        new Actor() { Name = "Sherry", Age = 34, Gender = "Female" }
                    }
                },
                new Movie()
                {
                    Name = "Avatar",
                    Description = "American Sci-Fi",
                    Rating = 9,
                    Actors = new ObservableCollection<Actor>()
                    {
                        new Actor() { Name = "Jack", Age = 32, Gender = "Male" },
                        new Actor() { Name = "An", Age = 26, Gender = "Female" }
                    }
                }

            };
#endif

        }

        public Task<IEnumerable<Movie>> LoadMoviesAsync()
        {
            var task = new Task<IEnumerable<Movie>>(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));
                return LoadMovies();
            });
            task.Start();
            return task;
        }
    }
}
