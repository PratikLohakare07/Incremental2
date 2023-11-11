using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    
    public class TeamController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayerController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        // [Route("Index")]
        public IActionResult List()
        {
            var data=_context.Teams.ToList();
            return View(data);
        }

        public IActionResult DisplayAllPlayers(int id)
        {
            var data=_context.Teams.Find(id);
            return View(data);
        }
       [HttpGet]
    //    [Route("create")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        
        public IActionResult Create(Team team)

        {
            if(ModelState.IsValid)
            {

            
            var data=_context.Teams.Add(team);

            _context.SaveChanges();
            return RedirectToAction("List");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var data=_context.Players.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit (Team team)
        {
            Team p=_context.Players.Find(team.TeamId);
            p.TeamName=team.TeamName;
           
            _context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var data=_context.Players.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed (int id)
        {
            
            var data=_context.Players.Find(id);
            _context.Players.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("List");
      
        }
    }
}

