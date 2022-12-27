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

        public IActionResult TeamDetails(int id)
        {
            //ViewModel myModel = new ViewModel();
            //myModel.Teams = _dbContext.Teams.ToList();
            //myModel.Players = _dbContext.Players.ToList();
            //myModel.Team = myModel.Teams.FirstOrDefault(t => t.Name == team.Name);

            //var teamD = _dbContext.Teams.FirstOrDefault(t => t.Name == team.Name);
            var team = _dbContext.Teams.FirstOrDefault(t=>t.Id.Equals(id));
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

        public IActionResult Delete(int id)
        {
            var team = _dbContext.Teams.FirstOrDefault(t => t.Id.Equals(id));
            return View(team);
        }
        [HttpPost]
        public IActionResult DeleteTeam(int id)
        {
            var team = _dbContext.Teams.FirstOrDefault(t => t.Id.Equals(id));
            _dbContext.Teams.Remove(team);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            var team = _dbContext.Teams.FirstOrDefault(t => t.Id.Equals(id));
            return View(team);
        }
        [HttpPost]
        public ActionResult UpdateTeam(Team team)
        {
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
