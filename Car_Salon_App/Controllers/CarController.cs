using Car_Salon_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Car_Salon_App.Controllers
{
    public class CarsController : Controller
    {
        List<Car> cars;

        public CarsController()
        {
            cars = new List<Car>()
            {
                new Car { Id = 1,Brand = "Audi", Model = "Q5", Engine = "2.0 TDI", Year = new DateTime(2016,7,5),Price = 21000,Discount = 0, Quantity = 10  },
                new Car { Id = 2,Brand = "Jaguar", Model = "F-Pace", Engine = "2.0 T", Year = new DateTime(2020,1,4),Price = 32000,Discount = 5, Quantity = 1  },
                new Car { Id = 3,Brand = "BMW", Model = "X5", Engine = "3.0 TFSI", Year = new DateTime(2022,11,4),Price = 65000,Discount = 10, Quantity = 0  }
            };
        }
        public IActionResult Index()
        {
            return View(cars);
        }
    }
}
