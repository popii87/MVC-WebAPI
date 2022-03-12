using FootbalApp.Models;
using FootbalApp.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace FootbalApp.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            var teams = Db.Teams;


            return View(teams);
        }

        public IActionResult TeamDetails(string name)
        {
            ViewModel myModel = new ViewModel();
            myModel.Teams = Db.Teams;
            myModel.Players = Db.Players;
            myModel.Team = myModel.Teams.FirstOrDefault(t => t.Name == name);
            
            
            return View(myModel);
        }

        public IActionResult Create()
        {
             return View();
        }
        [HttpPost]
        public IActionResult Create(Team team)
        {
            
            team.TeamPlayers = new List<Player>() { new Player() { FirstName = "Zlatan", LastName = "Ibrahimovic", BirthDate = new DateTime(1987, 12, 5), Value = 250000 } };
            Db.Teams.Add(team);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string name)
        {
            var team = Db.Teams.FirstOrDefault(t=>t.Name == name);
            return View(team);
        }
        [HttpPost]
        public IActionResult DeleteTeam(string name)
        {
            var team = Db.Teams.FirstOrDefault(t => t.Name == name);
            Db.Teams.Remove(team);
            return RedirectToAction("Index");
        }

        public IActionResult Update(string name)
        {
            var team = Db.Teams.FirstOrDefault(t => t.Name == name);
            return View(team);
        }
        [HttpPost]
        public IActionResult UpdateTeam(Team team)
        {
            var team1 = Db.Teams.FirstOrDefault(t => t.Name == team.Name);
            var indexOf = Db.Teams.IndexOf(team1);
            team.TeamPlayers = team1.TeamPlayers;
            Db.Teams[indexOf] = team;
            return RedirectToAction("Index");

        }
      
        [HttpPost]
        public IActionResult CreatePlayer(Player player, string name)
        {
            var team = Db.Teams.FirstOrDefault(t => t.Name == name);
            team.TeamPlayers.Add(player);
            return RedirectToAction("TeamDetails", new {name =team.Name });
        }
    }
}
