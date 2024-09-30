using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public int BrandId { get; set; }        
        public string? ImageUrl { get; set; }
        public Brand? Brand { get; set; }
        public string Model { get; set; }
        public int EngineId { get; set; }
        public Engine? Engine { get; set; }
        public DateTime Year { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}