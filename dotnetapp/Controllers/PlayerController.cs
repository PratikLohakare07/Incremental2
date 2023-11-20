﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    
    [Route("/[controller]")]
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext context;

        public PlayerController(ApplicationDbContext _context)
        {
            context = _context;
        }
        [Route("create")]
        public IActionResult Create(){

            return  View();
        }
        
        [HttpPost]
        public IActionResult Create(Player p){
            // if(ModelState.IsValid){
            
                context.Players.Add(p);
                context.SaveChanges();
                return RedirectToAction("Index");
            // }
            // return View();
        }
        [Route("index")]
        [HttpGet]
        public IActionResult Index(){
            
            var data=context.Players.ToList();
            return View(data);
        }
        
        
      [HttpGet]
        public IActionResult Edit(int id){
            var data=context.Players.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Player p){
           // if(ModelState.IsValid)
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
        [HttpDelete("")]
        public IActionResult Delete(Player p){
            var data=context.Players.Find(p.Id);
            context.Players.Remove(data);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpDelete("{{id}}")]
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
