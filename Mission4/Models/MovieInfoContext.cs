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
        public DbSet<Category> Categories { get; set; }
       
        //Seed data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId= 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
            );

            mb.Entity<MovieResponse>().HasData(

                new MovieResponse
                {
                    MovieId = 1,
                    CategoryId = 1,
                    Title = "Kick-@$$",
                    Year = 2010,
                    Director = "Matthew Vaughn",
                    Rating = "R",
                    Edited = true,
                },
                new MovieResponse
                {
                    MovieId = 2,
                    CategoryId = 3,
                    Title = "Ratatouille",
                    Year = 2007,
                    Director = "Brad Bird, Jan Pinkava",
                    Rating = "G",
                    Edited = false,
                }, 
                new MovieResponse
                {
                    MovieId = 3,
                    CategoryId = 3,
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
