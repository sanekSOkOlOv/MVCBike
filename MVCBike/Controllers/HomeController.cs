using Microsoft.AspNetCore.Mvc;
using MVCBike.Models;
using System.Diagnostics;
using System.Text.Json;
using System.IO;

namespace MVCBike.Controllers
{
    public class HomeController : Controller
    {
        private const string FilePath = "bikes.json";
        private const string ScootersFilePath = "scooters.json";
        private const string SkatePath = "skate.json";
        public IActionResult Index()
        {
            List<Bike> bikes = LoadBikes();
            return View(bikes);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Bike bike)
        {
            List<Bike> bikes = LoadBikes();
            bike.Id = bikes.Count + 1;
            bikes.Add(bike);
            SaveBikes(bikes);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            List<Bike> bikes = LoadBikes();
            var bikeToRemove = bikes.FirstOrDefault(b => b.Id == id);

            if (bikeToRemove != null)
            {
                bikes.Remove(bikeToRemove);
                SaveBikes(bikes);
            }

            return RedirectToAction("Index");
        }


        private List<Bike> LoadBikes()
        {
            if (System.IO.File.Exists(FilePath))
            {
                string json = System.IO.File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<List<Bike>>(json);
            }
            return new List<Bike>();
        }

        private void SaveBikes(List<Bike> bikes)
        {
            string json = JsonSerializer.Serialize(bikes);
            System.IO.File.WriteAllText(FilePath, json);
        }

        public IActionResult Scooters()
        {
            List<Scooter> scooters = LoadScooters();
            return View(scooters);
        }

        [HttpGet]
        public IActionResult AddScooter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddScooter(Scooter scooter)
        {
            List<Scooter> scooters = LoadScooters();
            scooter.Id = scooters.Count + 1;
            scooters.Add(scooter);
            SaveScooters(scooters);

            return RedirectToAction("Scooters");
        }

        [HttpPost]
        public IActionResult DeleteScooter(int id)
        {
            List<Scooter> scooters = LoadScooters();
            var scooterToRemove = scooters.FirstOrDefault(s => s.Id == id);

            if (scooterToRemove != null)
            {
                scooters.Remove(scooterToRemove);
                SaveScooters(scooters);
            }

            return RedirectToAction("Scooters");
        }

        private List<Scooter> LoadScooters()
        {
            if (System.IO.File.Exists(ScootersFilePath))
            {
                string json = System.IO.File.ReadAllText(ScootersFilePath);
                return JsonSerializer.Deserialize<List<Scooter>>(json);
            }
            return new List<Scooter>();
        }

        private void SaveScooters(List<Scooter> scooters)
        {
            string json = JsonSerializer.Serialize(scooters);
            System.IO.File.WriteAllText(ScootersFilePath, json);
        }

        public IActionResult Skateboards()
        {
            List<Skateboard> skateboards = LoadSkateboards();
            return View("Skateboards", skateboards);
        }

        [HttpGet]
        public IActionResult AddSkateboard()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSkateboard(Skateboard skateboard)
        {
            List<Skateboard> skateboards = LoadSkateboards();
            skateboard.Id = skateboards.Count + 1;
            skateboards.Add(skateboard);
            SaveSkateboards(skateboards);

            return RedirectToAction("Skateboards");
        }

        [HttpPost]
        public IActionResult DeleteSkateboard(int id)
        {
            List<Skateboard> skateboards = LoadSkateboards();
            var skateboardToRemove = skateboards.FirstOrDefault(s => s.Id == id);

            if (skateboardToRemove != null)
            {
                skateboards.Remove(skateboardToRemove);
                SaveSkateboards(skateboards);
            }

            return RedirectToAction("Skateboards");
        }

        private List<Skateboard> LoadSkateboards()
        {
            if (System.IO.File.Exists(SkatePath))
            {
                string json = System.IO.File.ReadAllText(SkatePath);
                return JsonSerializer.Deserialize<List<Skateboard>>(json);
            }
            return new List<Skateboard>();
        }

        private void SaveSkateboards(List<Skateboard> skateboards)
        {
            string json = JsonSerializer.Serialize(skateboards);
            System.IO.File.WriteAllText(SkatePath, json);
        }
    }
}