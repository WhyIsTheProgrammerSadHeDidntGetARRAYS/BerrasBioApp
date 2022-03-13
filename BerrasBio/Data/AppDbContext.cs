using BerrasBio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie_Actor> Movies_Actors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie_Actor>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });
            modelBuilder.Entity<Movie_Actor>()
                .HasOne(am => am.Movie)
                .WithMany(am => am.MoviesActors)
                .HasForeignKey(am => am.MovieId);

            modelBuilder.Entity<Movie_Actor>()
                .HasOne(am => am.Actor)
                .WithMany(am => am.MoviesActors)
                .HasForeignKey(am => am.ActorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
