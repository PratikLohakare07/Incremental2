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


    }
}

