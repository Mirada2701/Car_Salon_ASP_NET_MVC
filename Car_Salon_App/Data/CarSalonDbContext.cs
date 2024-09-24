using Car_Salon_App.Entities;
using Microsoft.EntityFrameworkCore;

namespace Car_Salon_App.Data
{
    public class CarSalonDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public CarSalonDbContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=LEGION5\SQLEXPRESS;
                Initial Catalog = CarSalon;
                Integrated Security=True;
                Connect Timeout=30;Encrypt=False;
                Trust Server Certificate=False;
                Application Intent=ReadWrite;
                Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Brand>().HasData(new List<Brand>()
            {
                new Brand(){Id = 1, Name = "Audi" },
                new Brand(){Id = 2, Name = "BMW" },
                new Brand(){Id = 3, Name = "Mercedes-Benz" },
                new Brand(){Id = 4, Name = "Jaguar" },
                new Brand(){Id = 5, Name = "Volkswagen" },
                new Brand(){Id = 6, Name = "Mazda" },
                new Brand(){Id = 7, Name = "Dodge" },
                new Brand(){Id = 8, Name = "Renault" },
                new Brand(){Id = 9, Name = "Volvo" },
                new Brand(){Id = 10, Name = "Toyota" }
            });
            modelBuilder.Entity<Category>().HasData(new List<Category>()
            {
                 new Category(){Id = 1, Name = "SUV" },
                 new Category(){Id = 2, Name = "Coupe" },
                 new Category(){Id = 3, Name = "Sedan" },
                 new Category(){Id = 4, Name = "Station wagon" },
                 new Category(){Id = 5, Name = "Hatchback" }
            });
            modelBuilder.Entity<Car>().HasData(new List<Car>(){
                new Car(){Id = 1, BrandId = 1 , Model = "Q5", Engine = "2.0 TDI", Year = new DateTime(2016,5,6), Price = 21000,Discount = 10, Quantity = 5, CategoryId = 1 },
                new Car(){Id = 2, BrandId = 2 , Model = "CLS", Engine = "5.5 T", Year = new DateTime(2013,1,6), Price = 30000,Discount = 5, Quantity = 2, CategoryId = 2 },
                new Car(){Id = 3, BrandId = 3 , Model = "525I", Engine = "2.5 TDI", Year = new DateTime(2003,4,12), Price = 5500,Discount = 15, Quantity = 10, CategoryId = 4 },

            });

            modelBuilder.Entity<Car>().Property(c => c.Description).HasMaxLength(500);

            modelBuilder.Entity<Car>().HasOne(c => c.Brand).WithMany(b => b.Cars).HasForeignKey(c => c.BrandId);
            modelBuilder.Entity<Car>().HasOne(c => c.Category).WithMany(b => b.Cars).HasForeignKey(c => c.CategoryId);
        }
    }
}
