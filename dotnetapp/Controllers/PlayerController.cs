﻿
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dotnetapp.Controllers
{
   
//    [Route("/[controller]")]
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext context;
 
        public PlayerController(ApplicationDbContext _context)
        {
            context = _context;
        }
 
       [Route("")]
        public IActionResult Index(){
           
            var data=context.Players.ToList();
            return View(data);
        }
        
        [Route("create")]
       public IActionResult Create()
{
    ViewBag. = new SelectList(context.Teams, "TeamId", "TeamName");
    return View();
}

[HttpPost]
public IActionResult Create(Player p)
{
    if (ModelState.IsValid)
    {
        try
        {
            context.Players.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.InnerException.Message);
        }
    }
    ViewBag.TeamList = new SelectList(context.Teams, "TeamId", "TeamName", p.TeamId);
    return View(p);
}
       
     
         public IActionResult Edit(int id){
             var data=context.Players.Find(id);
             return View(data);
         }
        [HttpPut]
        public IActionResult Edit(Player p){
           {
               
                Player pl=context.Players.Find(p.Id);
                pl.Name=p.Name;
               
                pl.Category=p.Category;
                pl.BiddingAmount=p.BiddingAmount;
                context.SaveChanges();
                               
                return RedirectToAction("Index");
            }
           // return View();
        }
        public IActionResult Delete(int id){
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Player p){
            var data=context.Players.Find(p.Id);
            context.Players.Remove(data);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
         public IActionResult DeleteConfirmed(int id){
            var data=context.Players.Find(id);
            context.Players.Remove(data);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        // public IActionResult DisplayAllPlayers(){
           
        // }
    }
}