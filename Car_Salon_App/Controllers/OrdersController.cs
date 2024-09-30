using Core.Interfaces;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Car_Salon_App.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly CarSalonDbContext context;
        private readonly ICartService cartService;
        private readonly IOrderService orderService;

        private string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        public OrdersController(CarSalonDbContext context,ICartService cartService,IOrderService orderService)
        {
            this.context = context;
            this.cartService = cartService;
            this.orderService = orderService;
        }
        public IActionResult Index()
        {            
            return View(orderService.GetOrders(CurrentUserId));
        }
        
        public IActionResult Create()
        {
            orderService.Create(CurrentUserId,cartService);
            cartService.Clear();
            return RedirectToAction("Index");
        }
    }
}
