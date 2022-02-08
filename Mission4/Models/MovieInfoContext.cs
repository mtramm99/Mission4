using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class MovieInfoContext : DbContext
    {
        //Constructor
        public MovieInfoContext (DbContextOptions<MovieInfoContext> options) : base (options)
        {
            //Leave blank for now
        }

        public DbSet<MovieResponse> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieResponse>().HasData(

                new MovieResponse
                {
                    MovieId = 1,
                    Category = "Action/Adventure",
                    Title = "Kick-@$$",
                    Year = 2010,
                    Director = "Matthew Vaughn",
                    Rating = "R",
                    Edited = true,
                },
                new MovieResponse
                {
                    MovieId = 2,
                    Category = "Family",
                    Title = "Ratatouille",
                    Year = 2007,
                    Director = "Brad Bird, Jan Pinkava",
                    Rating = "G",
                    Edited = false,
                }, 
                new MovieResponse
                {
                    MovieId = 3,
                    Category = "Family",
                    Title = "Saturday's Warrior",
                    Year = 1989,
                    Director = "Bob Williams",
                    Rating = "G",
                    Edited = false,
                }
                );
        }
    }
}
