using Core.Interfaces;
using Core.Models;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
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
        private readonly IEmailSender emailSender;
        private readonly IViewRender viewRender;

        private string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        private string CurrentUserEmail => User.FindFirstValue(ClaimTypes.Email)!;

        public OrdersController(CarSalonDbContext context,ICartService cartService,IOrderService orderService,IEmailSender emailSender,IViewRender viewRender)
        {
            this.context = context;
            this.cartService = cartService;
            this.orderService = orderService;
            this.emailSender = emailSender;
            this.viewRender = viewRender;
        }
        public IActionResult Index()
        {            
            return View(orderService.GetOrders(CurrentUserId));
        }
        
        public async Task<IActionResult> Create()
        {
            var order = orderService.Create(CurrentUserId,cartService);

            //send email of order to the client
            var totalPrice = order.Cars!.Sum(x => x.Price);

            var html = viewRender.Render("MailTemplates/OrderSummary", new OrderSummaryModel
            {
                OrderNumber = order.Id,
                UserName = CurrentUserEmail,
                Cars = cartService.GetCars(),
                TotalPrice = totalPrice
            });

            await emailSender.SendEmailAsync(CurrentUserEmail, $"New Order #{order.Id}",html);

            cartService.Clear();
            return RedirectToAction("Index");
        }
    }
}
