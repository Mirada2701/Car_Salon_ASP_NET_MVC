using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CarSalonDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Car> Cars { get; set; }
        public CarSalonDbContext(DbContextOptions options):base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=LEGION5\SQLEXPRESS;Initial Catalog = CarSalon;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
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
            modelBuilder.Entity<Engine>().HasData(new List<Engine>()
            {
                 new Engine(){Id = 1, Capacity = 2.0, Type = "Diesel" },
                 new Engine(){Id = 2, Capacity = 2.0, Type = "Petrol"},
                 new Engine(){Id = 3, Capacity = 3.0, Type = "Diesel"},
                 new Engine(){Id = 4, Capacity = 3.0, Type = "Petrol"},
                 new Engine(){Id = 5, Capacity = 5.0, Type = "Petrol"},
                 new Engine(){Id = 6, Capacity = 2.5, Type = "Petrol"},
                 new Engine(){Id = 7, Capacity = 2.5, Type = "Diesel"},
                 new Engine(){Id = 8, Capacity = 1.4, Type = "Petrol"},
                 new Engine(){Id = 9, Capacity = 1.6, Type = "Diesel"},
                 new Engine(){Id = 10, Capacity = 5.0, Type = "Diesel"},
                 new Engine(){Id = 11, Capacity = 2.2, Type = "Diesel"},
                 new Engine(){Id = 12, Capacity = 2.7, Type = "Petrol"},
                 new Engine(){Id = 13, Capacity = 1.8, Type = "Petrol"},
                 new Engine(){Id = 14, Capacity = 1.9, Type = "Diesel"},
                 new Engine(){Id = 15, Capacity = 5.5, Type = "Petrol"},
                 new Engine(){Id = 16, Capacity = 4.7, Type = "Petrol"}
            });
            modelBuilder.Entity<Car>().HasData(new List<Car>(){
                new Car(){Id = 1, BrandId = 1 , Model = "Q5", EngineId = 1, Year = new DateTime(2016,5,6), Price = 21000,Discount = 10, Quantity = 5, CategoryId = 1,ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSVPmQmyQY3Y5l_OU-xBQ7gGe2TXtKLX5pFPA&s" },
                new Car(){Id = 2, BrandId = 3 , Model = "CLS", EngineId = 15, Year = new DateTime(2013,1,6), Price = 30000,Discount = 5, Quantity = 2, CategoryId = 2,ImageUrl ="https://cdn3.riastatic.com/photosnew/auto/photo/mercedes-benz_cls-class__486325818f.jpg" },
                new Car(){Id = 3, BrandId = 2 , Model = "525I", EngineId = 6, Year = new DateTime(2003,4,12), Price = 5500,Discount = 15, Quantity = 10, CategoryId = 4, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTqzKVeLR9AsFHMTk35UJYKqspSYu8t1NyjCg&s"},

            });

            modelBuilder.Entity<Car>().Property(c => c.Description).HasMaxLength(500);

            modelBuilder.Entity<Car>().HasOne(c => c.Brand).WithMany(b => b.Cars).HasForeignKey(c => c.BrandId);
            modelBuilder.Entity<Car>().HasOne(c => c.Category).WithMany(b => b.Cars).HasForeignKey(c => c.CategoryId);
            modelBuilder.Entity<Car>().HasOne(c => c.Engine).WithMany(b => b.Cars).HasForeignKey(c => c.EngineId);
        }
    }
}
