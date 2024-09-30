using Core.Interfaces;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Car_Salon_App.Controllers
{
    public class OrdersController : Controller
    {
        private readonly CarSalonDbContext context;
        private readonly ICartService cartService;

        private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        public OrdersController(CarSalonDbContext context,ICartService cartService)
        {
            this.context = context;
            this.cartService = cartService;
        }
        public IActionResult Index()
        {
            var orders = context.Orders.Include(u => u.User).Where(u => u.UserId == UserId).ToList();
            return View(orders);
        }
        public IActionResult Create()
        {
            var order = new Order()
            {
                CreatedAt = DateTime.Now,
                UserId = UserId,
                Cars = cartService.GetCarsEntity()
            };

            context.Orders.Add(order);
            context.SaveChanges();

            cartService.Clear();
            return RedirectToAction("Index");
        }
    }
}
