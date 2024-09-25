using System.ComponentModel.DataAnnotations;

namespace Car_Salon_App.Entities
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public int BrandId { get; set; }
        [Url]
        public string? ImageUrl { get; set; }
        public Brand? Brand { get; set; }
        [Required]
        public string Model { get; set; }
        public string Engine { get; set; }
        public DateTime Year { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}