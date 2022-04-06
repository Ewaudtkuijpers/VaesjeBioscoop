using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using VaesjeBioscoop.Models;
using VaesjeBioscoop.Database;

namespace VaesjeBioscoop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
                // alle producten ophalen
                var rows = DatabaseConnector.GetRows("select * from product");

                // lijst maken om alle namen in te stoppen
                List<string> names = new List<string>();

                foreach (var row in rows)
                {
                    // elke naam toevoegen aan de lijst met namen
                    names.Add(row["naam"].ToString());
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
