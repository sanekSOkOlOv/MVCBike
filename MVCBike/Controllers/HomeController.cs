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
    }
}