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
                            Name = "Lin Shaye",
                            Bio = "This is the Bio of Lin Shaye"

                        },
                        new Actor()
                        {
                            Name = "Daniel Craig",
                            Bio = "This is the Bio of Daniel Craig"
                        },
                        new Actor()
                        {
                            Name = "Tom Hardy",
                            Bio = "This is the Bio of Tom Hardy"
                        },
                        new Actor()
                        {
                            Name = "Dwayne Johnson",
                            Bio = "This is the Bio of Dwayne Johnson"
                        },
                        new Actor()
                        {
                            Name = "Chris Pratt",
                            Bio = "This is the Bio of Chris Pratt",
                        },
                        new Actor()
                        {
                            Name = "Timothée Chalamet",
                            Bio = "This is the Bio of Timothée Chalamet",
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
                            ImageURL = "../Content/Images/p-1.jpg",
                            CinemaId = 1,
                            Genre = MovieCategory.Horror
                        },
                        new Movie()
                        {
                            Name = "James Bond",
                            Description = "This is the James Bond description",
                            Price = 150,
                            ImageURL = "../Content/Images/Post-6.jpg",
                            CinemaId = 1,
                            Genre = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Venom",
                            Description = "This is the Venom movie description",
                            Price = 150,
                            ImageURL = "../Content/Images/Post-1.jpg",
                            CinemaId = 1,
                            Genre = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Jungle Cruise",
                            Description = "This is the Jungle Cruise movie description",
                            Price = 150,
                            ImageURL = "../Content/Images/Post-3.jpg",
                            CinemaId = 1,
                            Genre = MovieCategory.Comedy
                        },
                        new Movie()
                        {
                            Name = "The Tomorrow War",
                            Description = "This is the The Tomorrow War movie description",
                            Price = 150,
                            ImageURL = "../Content/Images/Post-2.jpg",
                            CinemaId = 1,
                            Genre = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Dune",
                            Description = "This is the Dune movie description",
                            Price = 165,
                            ImageURL = "../Content/Images/post-4.jpg",
                            CinemaId = 1,
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
