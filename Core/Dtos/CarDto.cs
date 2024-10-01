using Data.Entities;
using Microsoft.AspNetCore.Http;

namespace Core.Dtos
{
    public class CarDto
    {
        public int? Id { get; set; }
        public int BrandId { get; set; }
        public string? BrandName { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? Image { get; set; }
        public string? Model { get; set; }
        public int? Hp { get; set; }
        public int EngineId { get; set; }
        public string? EngineDisplay { get; set; }
        public DateTime Year { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Color { get; set; }
    }
}
