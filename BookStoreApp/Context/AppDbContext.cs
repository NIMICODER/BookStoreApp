using BookStoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options) 
        {
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("employees");
            modelBuilder.Entity<Book>().ToTable("books");
            modelBuilder.Entity<Store>().HasNoKey();
        }
    }
}
