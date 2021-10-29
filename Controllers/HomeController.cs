﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using smartmat.Data;
using smartmat.Models;

namespace smartmat.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ApplicationDbContext _db;
        
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
        
        public IActionResult Recipes(string search)
        {
            string[] ingredients = search.Split(", ");  //for å kunne søke på flere ingredienser
            var recipes = _db.Recipes.ToList();
            
            foreach (var i in ingredients)
            {
               var list = searchfor(recipes, i);
               recipes = list;
            }
            
            return PartialView("_RecipesPartial", recipes.ToList());
        }

        private List<Recipe> searchfor(List<Recipe> list, string i)
        {
            
            var result = list.Where(a => a.Ingredients.ToLower().Contains(i.ToLower()));
            return result.ToList();
        }
    }
}