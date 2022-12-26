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
        private FootballDbContext _dbContext;
        public TeamController(FootballDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var teams = _dbContext.Teams.ToList();
             return View(teams);
        }

        public IActionResult TeamDetails(string name)
        {
            //ViewModel myModel = new ViewModel();
            //myModel.Teams = _dbContext.Teams.ToList();
            //myModel.Players = _dbContext.Players.ToList();
            //myModel.Team = myModel.Teams.FirstOrDefault(t => t.Name == team.Name);

            //var teamD = _dbContext.Teams.FirstOrDefault(t => t.Name == team.Name);
            var team = _dbContext.Teams.FirstOrDefault(t=>t.Name.Equals(name));
            return View(team);
        }

        public IActionResult Create()
        {
             return View();
        }
        [HttpPost]
        public IActionResult Create(Team team)
        {
            
          //  team.TeamPlayers = new List<Player>();
            _dbContext.Teams.Add(team);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string name)
        {
            var team = _dbContext.Teams.FirstOrDefault(t => t.Name.Equals(name));
            return View(team);
        }
        [HttpPost]
        public IActionResult DeleteTeam(string name)
        {
            var team = _dbContext.Teams.FirstOrDefault(t => t.Name.Equals(name));
            _dbContext.Teams.Remove(team);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Update(Team team)
        {
            var team1 = _dbContext.Teams.FirstOrDefault(t => t.Name.Equals(team.Name));
            return View(team1);
        }
        [HttpPost]
        public ActionResult UpdateTeam(Team team)
        {
            //var team1 = _dbContext.Teams.FirstOrDefault(t=>t.Name.Equals(team.Name));  
            _dbContext.Teams.Update(team);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
           
            /*
             * var team1 = _dbContext.Teams.FirstOrDefault(t => t.Name == team.Name);
            var indexOf = FootbalApp._dbContext.Teams.IndexOf(team1);
            team.TeamPlayers = team1.TeamPlayers;
            FootbalApp._dbContext.Teams[indexOf] = team;
            return RedirectToAction("Index");
            */

        }
      
        [HttpPost]
        public IActionResult CreatePlayer(Player player, string name)
        {
            var team = _dbContext.Teams.FirstOrDefault(t => t.Name == name);
            team.TeamPlayers.Add(player);
            return RedirectToAction("TeamDetails", new {name =team.Name });
        }
    }
}
