using Data;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Data.Entities;

namespace Car_Salon_App.Services
{
    public class OrderService : IOrderService
    {
        private readonly CarSalonDbContext context;

        public OrderService(CarSalonDbContext context)
        {
            this.context = context;
        }
        public Order Create(string id, ICartService cartService)
        {
            var order = new Order()
            {
                CreatedAt = DateTime.Now,
                UserId = id,
                Cars = cartService.GetCarsEntity()
            };

            context.Orders.Add(order);
            context.SaveChanges();
            return order;
        }

        public List<Order> GetOrders(string CurrentUserId)
        {
            return context.Orders.Include(u => u.User).Where(u => u.UserId == CurrentUserId).ToList();
        }
    }
}
