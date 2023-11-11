using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    // [ApiController]
    // [Route("[/controller]")]
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayerController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        // [Route("Index")]
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
    //    [HttpGet]
    //    [Route("create")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        
        public IActionResult Create(Player player)

        {
            if(ModelState.IsValid)
            {

            
            _context.Players.Add(player);

            _context.SaveChanges();
            return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var data=_context.Players.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit (Player player)
        {
            Player p=_context.Players.Find(player.Id);
            p.Name=player.Name;
            p.BiddingAmount=player.BiddingAmount;
            p.Category=player.Category;
            _context.SaveChanges();
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
      
        }
    }
}

