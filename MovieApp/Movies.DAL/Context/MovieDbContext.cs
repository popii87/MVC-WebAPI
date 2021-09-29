using Microsoft.EntityFrameworkCore;
using Movies.DAL.Models.Data;
using Movies.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.DAL.Context
{
    public class MovieDbContext: DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                        .HasOne(x => x.User)
                        .WithMany(x => x.Movies)
                        .HasForeignKey(x => x.UserId)
                        .HasConstraintName("MyFKConstraint");


            //seeding the database with data
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    Username = "rdimov",
                    Password = "123",
                    FirstName = "Robert",
                    LastName = "Dimov",
                    FavoriteGenre = Genre.Adventure,
                    
                },
              new User()
              {
                  Id = 2,
                  Username = "vjakovlev",
                  Password = "456",
                  FirstName = "Viktor",
                  LastName = "Jakovlev",
                  FavoriteGenre = Genre.Action,
                  

              },
               new User()
               {
                   Id = 3,
                   Username = "bboski",
                   Password = "789",
                   FirstName = "Bob",
                   LastName = "Bobski",
                   FavoriteGenre = Genre.Comedy,
                   
               },
               new User()
               {
                   Id = 4,
                   Username = "bencb",
                   Password = "889",
                   FirstName = "Ben",
                   LastName = "Solski",
                   FavoriteGenre = Genre.Drama,
                   

               }
                );

            modelBuilder.Entity<Movie>().HasData(
                 new Movie()
                 {
                     Id = 1,
                     Title = "Rambo",
                     Description = "dasda",
                     Year = 1996,
                     Genre = Genre.Action,
                     UserId = 1
                 },
            new Movie()
            {
                Id = 2,
                Title = " The Lord Of The Rings",
                Description = "Group of heroes save the world from evil",
                Year = 2000,
                Genre = Genre.Adventure,
                UserId = 1

            },
            new Movie()
            {
                Id = 3,
                Title = " Avengers",
                Description = "Superheroes against the evil",
                Year = 2002,
                Genre = Genre.Comedy,
                UserId = 1

            },
            new Movie()
            {
                Id = 4,
                Title = " Avengers2",
                Description = "Superheroes against the evil",
                Year = 2002,
                Genre = Genre.Comedy,
                UserId = 1

            },
            new Movie()
            {
                Id = 5,
                Title = "Vratice se rode",
                Description = "Superheroes against the evil",
                Year = 2000,
                Genre = Genre.Drama,
                UserId = 1

            },
            new Movie()
            {
                Id = 6,
                Title = "Interstellar",
                Description = "Superheroes against the evil",
                Year = 2010,
                Genre = Genre.SciFi,
                UserId = 1

            },
            new Movie()
            {
                Id = 7,
                Title = "Money Heist",
                Description = "Superheroes against the evil",
                Year = 2010,
                Genre = Genre.Thriller,
                UserId = 1

            }



         );
        }
    }
}
