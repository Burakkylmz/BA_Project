using BAProject.Model.Model.Entities.Concrete;
using Microsoft.EntityFrameworkCore;


namespace BAProject.DAL.DAL.Context
{
    public class BAProjeContext:DbContext
    {
        public BAProjeContext(DbContextOptions<BAProjeContext> options):base(options) //UI - Startup içerisinde ve appsettings.json dosyasına tanımlama yapılmalıdır.
        {
            //Db init stratejileri core'da biraz değişti, isteyen, https://docs.microsoft.com/tr-tr/ef/core/managing-schemas/migrations/  dökümanını inceleyebilir.
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        //OnModelCreating ve SaveChanges burada override edilebilir.

    }
}
