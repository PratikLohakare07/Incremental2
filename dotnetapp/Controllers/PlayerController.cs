using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayerController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [Route("Index")]
        public IActionResult Index()
        {
            var data=_context.Players.ToList();
            return View(data);
        }

        public IActionResult DisplayAllPlayers(int id)
        {
            var data=_context.Players.Find(id);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        
        public IActionResult Create(Player player)

        {
            if(ModelState.IsValid)
            {

            
            var data=_context.Players.Add(player);

            _context.SaveChanges();
            return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult(int id)
        {
            var data=_context.Players.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult (Player player)
        {
            Player p=_context.Players.Add(player.Id);
            p.Name=player.Name;
            p.BiddingAmount=player.BiddingAmount;
            p.Category=player.Category;
        }

        public IActionResult (int id)
        {
            if(ModelState.IsValid)
            {
            var data=_context.Players.Find(id);
            _context.Players.Remove(data);
            return RedirectToAction("Index");
            }
        return View();
        }
    }
}

