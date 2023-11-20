using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var data = _context.Players.ToList();
            return View(data);
        }


        public IActionResult DisplayAllPlayers(int id)
        {
            var data = _context.Players.Find(id);
            return View(data);
        }
        //    [HttpGet]
        //    [Route("create")]
        public IActionResult Create()
        {
            ViewBag.TeamId = new SelectList(_context.Teams, "Id", "TeamName");
            return View();
        }


        [HttpPost]

        public IActionResult Create(Player player)

        {

            _context.Players.Add(player);

            _context.SaveChanges();
            return RedirectToAction("Index");

            ViewBag.TeamId = new SelectList(_context.Teams, "Id", "TeamName");

        }

  
        public IActionResult Edit(int id){
            var data=_context.Players.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Player p){
           // if(ModelState.IsValid)
           {
                Player pl = new Player(); // Initialize the pl object

        
        if (p != null)
        {
               pl.Name = p.Name;
                Player pl=_context.Players.Find(p.Id);
                pl.Name=p.Name;
                
                pl.Category=p.Category;
                pl.BiddingAmount=p.BiddingAmount;
                _context.SaveChanges();
                               
                return RedirectToAction("Index");
            }
           return View();
        }
        public IActionResult Delete(int id){
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Player p){
            var data=_context.Players.Find(p.Id);
            _context.Players.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
         public IActionResult DeleteConfirmed(int id){
            var data=_context.Players.Find(id);
            _context.Players.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

