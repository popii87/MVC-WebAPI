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
            ViewModel myModel = new ViewModel();
            myModel.Teams = _dbContext.Teams.ToList();
            myModel.Players = _dbContext.Players.ToList();
            myModel.Team = myModel.Teams.FirstOrDefault(t => t.Id.Equals(id)); 

            
            return View(myModel);
        }

        public IActionResult Create()
        {
             return View();
        }
        [HttpPost]
        public IActionResult Create(Team team)
        {
            
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
        public IActionResult DeleteTeam(Team team)
        {           
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
           
        

        }
      
        [HttpPost]
        public IActionResult CreatePlayer(Player player, Team team )
        {
            var team1 = _dbContext.Teams.FirstOrDefault(t => t.Id.Equals(team.Id));
            team1.TeamPlayers.Add(player);
            _dbContext.SaveChanges();
            return RedirectToAction("TeamDetails", new {id = team.Id });
        }
    }
}
