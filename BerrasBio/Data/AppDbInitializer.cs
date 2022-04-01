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
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
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
                            Description = "In 1953, Elise Rainier lives in Five Keys, New Mexico with her parents Audrey and Gerald and younger brother Christian. One night, Elise encounters a ghost in hers and Christian's bedroom. Frightened, Christian looks for a whistle their mother gave him to call for help, but cannot find it. Gerald, furious, beats Elise and locks her in the basement. There, Elise opens a mysterious red doorway and is briefly possessed by a demonic spirit. When Audrey comes to investigate, she is killed by the demon..",
                            Price = 150,
                            ImageLink = "/Content/Images/p-1.jpg",
                            CinemaId = 1,
                            Genre = MovieCategory.Horror
                        },
                        new Movie()
                        {
                            Name = "James Bond",
                            Description = "James Bond has left active service. His peace is short-lived when Felix Leiter, an old friend from the CIA, turns up asking for help, leading Bond onto the trail of a mysterious villain armed with dangerous new technology.",
                            Price = 175,
                            ImageLink = "/Content/Images/Post-6.jpg",
                            CinemaId = 1,
                            Genre = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Venom",
                            Description = "Eddie Brock attempts to reignite his career by interviewing serial killer Cletus Kasady, who becomes the host of the symbiote Carnage and escapes prison after a failed execution.",
                            Price = 145,
                            ImageLink = "/Content/Images/Post-1.jpg",
                            CinemaId = 1,
                            Genre = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Jungle Cruise",
                            Description = "Based on Disneyland's theme park ride where a small riverboat takes a group of travelers through a jungle filled with dangerous animals and reptiles but with a supernatural element.",
                            Price = 130,
                            ImageLink = "/Content/Images/Post-3.jpg",
                            CinemaId = 1,
                            Genre = MovieCategory.Comedy
                        },
                        new Movie()
                        {
                            Name = "The Tomorrow War",
                            Description = "A family man is drafted to fight in a future war where the fate of humanity relies on his ability to confront the past.",
                            Price = 125,
                            ImageLink = "/Content/Images/Post-2.jpg",
                            CinemaId = 1,
                            Genre = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Dune",
                            Description = "Feature adaptation of Frank Herbert's science fiction novel about the son of a noble family entrusted with the protection of the most valuable asset and most vital element in the galaxy.",
                            Price = 165,
                            ImageLink = "/Content/Images/post-4.jpg",
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
                            ActorId = 2,
                            MovieId = 2
                        },

                        new Movie_Actor()
                        {
                            ActorId = 3,
                            MovieId = 3
                        },
                        new Movie_Actor()
                        {
                            ActorId = 4,
                            MovieId = 4
                        },

                        new Movie_Actor()
                        {
                            ActorId = 5,
                            MovieId = 5
                        },
                        new Movie_Actor()
                        {
                            ActorId = 6,
                            MovieId = 6
                        },
                        
                    });
                    context.SaveChanges();
                }
                
                //Salon
                if (!context.Salons.Any())
                {
                    context.Salons.AddRange(new List<Salon>
                    {
                        new Salon
                        {
                            SalonName = "Salon 1",
                            TotalSeats = 50,
                            CinemaId = 1
                        },
                        new Salon
                        {
                            SalonName = "Salon 2",
                            TotalSeats = 100,
                            CinemaId = 1
                        }
                    });
                    context.SaveChanges();
                }
                // Session (what time and place a certain movie is shown)
                //if (!context.Sessions.Any())
                //{
                //    context.Sessions.AddRange(new List<Session>
                //    {
                //        new Session //minst 6 visningar
                //        {
                //            StartDate = DateTime.Now,
                //            AvailableSeats = 50,
                //            MovieId = 1,
                //            CinemaId = 1,
                //            SalonId = 1
                //        },
                //        new Session
                //        {
                //            StartDate = DateTime.Now,
                //            AvailableSeats = 50,
                //            MovieId = 2,
                //            CinemaId = 1,
                //            SalonId = 1
                //        },
                //        new Session
                //        {
                //            StartDate = DateTime.Now,
                //            AvailableSeats = 50,
                //            MovieId = 3,
                //            CinemaId = 1,
                //            SalonId = 1
                //        },
                //        new Session
                //        {
                //            StartDate = DateTime.Now,
                //            AvailableSeats = 50,
                //            MovieId = 4,
                //            CinemaId = 1,
                //            SalonId = 1
                //        },
                //        new Session
                //        {
                //            StartDate = DateTime.Now,
                //            AvailableSeats = 50,
                //            MovieId = 5,
                //            CinemaId = 1,
                //            SalonId = 1
                //        },
                //        new Session
                //        {
                //            StartDate = DateTime.Now,
                //            AvailableSeats = 50,
                //            MovieId = 6,
                //            CinemaId = 1,
                //            SalonId = 1
                //        }
                //    });
                //    context.SaveChanges();
                //}
                //Bookings
                //if (!context.Bookings.Any())
                //{
                //    context.Bookings.AddRange(new List<Booking>
                //    {
                //        new Booking
                //        {
                //            AmountOfTickets = 1,
                //            SessionId = 1,
                //            MovieId = 1 //behöver nog inte ett movieid, eftersom movie kommer fram i sessions
                //        },
                //        new Booking
                //        {
                //            AmountOfTickets = 1,
                //            SessionId = 2,
                //            MovieId = 2
                //        }
                //    });
                //    context.SaveChanges();
                //}
            }
        }
    }
}
