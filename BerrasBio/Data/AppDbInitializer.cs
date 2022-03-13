using BerrasBio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Data
{
    public class AppDbInitializer
    {
        private readonly AppDbContext _context;

        public AppDbInitializer(AppDbContext context)
        {
            _context = context;
        }
        public static void Initialize(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Seeding database with data

                //Cinemas
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>
                    {
                        new Cinema
                        {
                            Name = "Berras Bio",
                            Description = "This is the description of the first cinema"
                        }
                    });
                    context.SaveChanges();
                }
                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            Name = "Actor 1",
                            Bio = "This is the Bio of the first actor"
                            //ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor()
                        {
                            Name = "Actor 2",
                            Bio = "This is the Bio of the second actor"
                            //ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                            Name = "Actor 3",
                            Bio = "This is the Bio of the third actor"
                            //ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            Name = "Actor 4",
                            Bio = "This is the Bio of the fourth actor"
                            //ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor()
                        {
                            Name = "Actor 5",
                            Bio = "This is the Bio of the fifth actor",
                            //ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Insidious",
                            Description = "This is the Insidious movie description",
                            Price = 150,
                            //ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            //StartDate = DateTime.Now.AddDays(-10),
                            //EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 1,
                            //ProducerId = 3,
                            Genre = MovieCategory.Horror
                        },
                        new Movie()
                        {
                            Name = "James Bond",
                            Description = "This is the James Bond description",
                            Price = 150,
                            //ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            //StartDate = DateTime.Now,
                            //EndDate = DateTime.Now.AddDays(3),
                            CinemaId = 1,
                            //ProducerId = 1,
                            Genre = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Venom",
                            Description = "This is the Venom movie description",
                            Price = 150,
                            //ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            //StartDate = DateTime.Now,
                            //EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 1,
                            //ProducerId = 4,
                            Genre = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Jungle Cruise",
                            Description = "This is the Jungle Cruise movie description",
                            Price = 150,
                            //ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            //StartDate = DateTime.Now.AddDays(-10),
                            //EndDate = DateTime.Now.AddDays(-5),
                            CinemaId = 1,
                            //ProducerId = 2,
                            Genre = MovieCategory.Comedy
                        },
                        new Movie()
                        {
                            Name = "The Tomorrow War",
                            Description = "This is the The Tomorrow War movie description",
                            Price = 150,
                            //ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            //StartDate = DateTime.Now.AddDays(3),
                            //EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            //ProducerId = 5,
                            Genre = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Dune",
                            Description = "This is the Dune movie description",
                            Price = 165,
                            ///*ImageURL*/ = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            //StartDate = DateTime.Now.AddDays(-10),
                            //EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            //ProducerId = 3,
                            Genre = MovieCategory.Fantasy
                        }
                    });
                    context.SaveChanges();
                }
                //Movies_Actors (Bridge table in sql)
                if (!context.Movies_Actors.Any())
                {
                    context.Movies_Actors.AddRange(new List<Movie_Actor>()
                    {
                        new Movie_Actor()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Movie_Actor()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },

                         new Movie_Actor()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                         new Movie_Actor()
                        {
                            ActorId = 4,
                            MovieId = 2
                        },

                        new Movie_Actor()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new Movie_Actor()
                        {
                            ActorId = 2,
                            MovieId = 3
                        },
                        new Movie_Actor()
                        {
                            ActorId = 5,
                            MovieId = 3
                        },


                        new Movie_Actor()
                        {
                            ActorId = 2,
                            MovieId = 4
                        },
                        new Movie_Actor()
                        {
                            ActorId = 3,
                            MovieId = 4
                        },
                        new Movie_Actor()
                        {
                            ActorId = 4,
                            MovieId = 4
                        },


                        new Movie_Actor()
                        {
                            ActorId = 2,
                            MovieId = 5
                        },
                        new Movie_Actor()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new Movie_Actor()
                        {
                            ActorId = 4,
                            MovieId = 5
                        },
                        new Movie_Actor()
                        {
                            ActorId = 5,
                            MovieId = 5
                        },


                        new Movie_Actor()
                        {
                            ActorId = 3,
                            MovieId = 6
                        },
                        new Movie_Actor()
                        {
                            ActorId = 4,
                            MovieId = 6
                        },
                        new Movie_Actor()
                        {
                            ActorId = 5,
                            MovieId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
