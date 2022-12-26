using FootbalApp.Models;
using FootbalApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootbalApp
{
    public static class _dbContext
    {
        
        public static List<Team> Teams = new List<Team>()
        {
            new Team()
            {
                Name = "Chelsea",
                City = "London",
                Stadium = "Stamford Bridge",
                Year = 1912,
                History = "Associazione Calcio Milan, commonly referred to as AC Milan or simply Milan, is a professional football club in Milan, Italy, founded in 1899. The club has spent its entire history, with the exception of the 1980–81 and 1982–83 seasons, in the top flight of Italian football, known as Serie A since 1929–30.",
                TeamPlayers = new List<Player>{ new Player(){FirstName = "Frank", LastName = "Lampard", BirthDate = new DateTime(1980, 12, 5), Value = 100000 },
                                                new Player(){FirstName = "Cristiano",LastName = "Ronaldo",BirthDate = new DateTime(1986, 12, 5), Value = 900000}
                }
            },

             new Team()
            {
                Name = "Real Madrid",
                City = "Madrid",
                Stadium = "Santiago Bernabeu",
                Year = 1922,
                History = "Associazione Calcio Milan, commonly referred to as AC Milan or simply Milan, is a professional football club in Milan, Italy, founded in 1899. The club has spent its entire history, with the exception of the 1980–81 and 1982–83 seasons, in the top flight of Italian football, known as Serie A since 1929–30.",
                TeamPlayers = new List<Player>{ new Player() { FirstName = "Lionel", LastName = "Messi", BirthDate = new DateTime(1987, 12, 5), Value = 800000 } }
            },

              new Team()
            {
                Name = "Milan",
                City = "Milano",
                Stadium = "San Siro",
                Year = 1912,
                History = "Associazione Calcio Milan, commonly referred to as AC Milan or simply Milan, is a professional football club in Milan, Italy, founded in 1899. The club has spent its entire history, with the exception of the 1980–81 and 1982–83 seasons, in the top flight of Italian football, known as Serie A since 1929–30.",
                TeamPlayers = new List<Player>{ new Player() { FirstName = "Lionel", LastName = "Messi", BirthDate = new DateTime(1985,2,5), Value = 800000 } }
            },
              new Team()
              {
                  Name = "Bayern Munich",
                  City = "Munich",
                  Stadium = "Alianz Arena",
                  Year = 1912,
                  History = "The best German Club",
                  TeamPlayers = new List<Player>{ new Player() { FirstName = "Lionel", LastName = "Messi",BirthDate = new DateTime(1986, 12, 5), Value = 800000 },
                                                  new Player(){FirstName = "Cristiano",LastName = "Ronaldo",BirthDate = new DateTime(1986, 12, 5), Value = 900000}
                  }
              }
        };


        public static List<Player> Players = new List<Player>()
        {
            new Player()
            {
                FirstName = "Frank",
                LastName = "Lampard",
                BirthDate = new DateTime(1987, 12, 5),
                Value = 100000
            },

            new Player()
            {
                FirstName = "Cristiano",
                LastName = "Ronaldo",
               BirthDate = new DateTime(1987, 12, 5),
                Value = 900000
            },

            new Player()
            {
                FirstName = "Lionel",
                LastName = "Messi",
                BirthDate = new DateTime(1987, 12, 5),
                Value = 800000
            },
        };
    }
}
