using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.ViewModels.Home;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public IActionResult Index(int id)
        {
            var viewModel = new IndexViewModel();
            viewModel.Id = id;
            viewModel.Name = "Dane";
            viewModel.ProcessorCount = Environment.ProcessorCount;
            viewModel.Year = DateTime.UtcNow.Year;
            viewModel.UsersCount = dbContext.Users.Count();


            ////podavane na danni s ViewData (dobre e da go izblqgvame)
            ////Dictionary<string, dynamic>
            ////Dictionary<string, object>
            //this.ViewData["Year"] = 2020;
            //this.ViewData["Name"] = "Dane";
            //this.ViewData["UsersCount"] = this.dbContext.Users.Count();

            ////podavane na danni s ViewBag (toi e izcqlo dynamic)
            ////rqdko se izpolzva v praktikata (dori e po losho ot ViewData),
            ////zashtoto dynamic predrazpolaga kum losh i nekachestven kod, koito ne e tipiziran
            ////dynamic
            ////dynamic e mnogo blizko do proemnlivite v JS (ne sa tipizirani)
            //this.ViewBag.Name = "Dannncho";
            //this.ViewBag.Year = 2020;
            //this.ViewBag.UsersCount = this.dbContext.Users.Count();


            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View("Index", new IndexViewModel());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
