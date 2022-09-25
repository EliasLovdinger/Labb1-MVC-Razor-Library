using Microsoft.EntityFrameworkCore;

namespace Labb1_MVC_Razor.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<RentBook> RentBooks { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<RentBookDetail> RentBookDetails { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(new Book { BookId = 1, Title = "Hobbit 1", Description = "En saga", Amount = 10 });
            modelBuilder.Entity<Book>().HasData(new Book { BookId = 2, Title = "Hobbit 2", Description = "En saga om", Amount = 5 });
            modelBuilder.Entity<Book>().HasData(new Book { BookId = 3, Title = "Hobbit 3", Description = "En saga om något", Amount = 10 });


        }
    }
}
