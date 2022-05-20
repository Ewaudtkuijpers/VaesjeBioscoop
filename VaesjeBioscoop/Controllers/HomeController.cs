using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using VaesjeBioscoop.Models;
using VaesjeBioscoop.Database;
using System;

namespace VaesjeBioscoop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public List<film> GetAllfilm() { 

            var rows = DatabaseConnector.GetRows("select * from film");

            List<film> films = new List<film>();

            foreach (var row in rows)
            {
                film f = new film();
                f.titel = row["titel"].ToString();
                f.beschijving = row["beschijving"].ToString();
                f.leeftijd = Convert.ToInt32(row["leeftijd"]);
                f.poster = row["poster"].ToString();
                f.id = Convert.ToInt32(row["id"]);

                films.Add(f);
            }

            return films;
        }




        public IActionResult Index()
        {
            
                // alle titels ophalen
                var rows = DatabaseConnector.GetRows("select * from film");

                // lijst maken om alle namen in te stoppen
                List<string> names = new List<string>();

                foreach (var row in rows)
                {
                    // elke naam toevoegen aan de lijst met namen
                    names.Add(row["poster"].ToString());
                }

                // de lijst met namen in de html stoppen
                return View(names);
            
            return View();
        }

        [Route("contact")]
        public IActionResult Contact()
        {
           
            return View();
        }
        
        [HttpPost]
        [Route("contact")]        
        public IActionResult Contact(Person person)
        {
            if (ModelState.IsValid)
            {
                return Redirect("/succes");
            }

            return View(person);
        }

        [Route("Films")]
        public IActionResult Films()
        {
            return View();
        }

        [Route("Bioscopen")]
        public IActionResult Bioscopen()
        {
            return View();
        }

        [Route("Detail")]
        public IActionResult Detail()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
