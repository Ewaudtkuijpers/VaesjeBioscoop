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

        public List<Film> GetAllfilm() { 

            var rows = DatabaseConnector.GetRows("select * from film");

            List<Film> films = new List<Film>();

            foreach (var row in rows)
            {
                Film f = new Film();
                f.titel = row["titel"].ToString();
                f.beschrijving = row["beschrijving"].ToString();
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

        [Route("success")]
        public IActionResult Success()
        {
           
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
                DatabaseConnector.ExecuteQuery($"INSERT INTO `contact` (`id`, `voornaam`, `achternaam`, `email`, `telefoonnummer`, `bericht`) VALUES (NULL, '{person.Firstname}', '{person.Lastname}', '{person.Email}', '{person.Phone}', '{person.Message}');");
                return Redirect("/successContact");
            }

            return View(person);
        }

        [Route("successcontact")]
        public IActionResult SuccessContact()
        {
            if (ModelState.IsValid)
            {
                DatabaseConnector.ExecuteQuery($"INSERT INTO `contact` (`id`, `voornaam`, `achternaam`, `email`, `telefoonnummer`, `bericht`) VALUES (NULL, '{person.Firstname}', '{person.Lastname}', '{person.Email}', '{person.Phone}', '{person.Message}');");
                return Redirect("/successContact");
            }

            return View();
        }


        [Route("Films")]
        public IActionResult Films()
        {
            var films = GetAllfilm();
            return View(films);
        }

        [Route("Bioscopen")]
        public IActionResult Bioscopen()
        {
            return View();
        }

        [Route("Detail/{filmId}")]
        public IActionResult Detail(int filmId)

        {
            List<Film> films = GetAllfilm();
            foreach (Film film in films)
            {
                if (film.id == filmId) 
                { return View(film);

                }

            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
